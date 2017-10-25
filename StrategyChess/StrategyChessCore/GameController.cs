using StrategyChessCore.Definitions;
using StrategyChessCore.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore
{
    public class GameController
    {
        private BoardHandler _gameHandler;
        private Team _currentTeam;

        private int _maxUnits;
        private int _maxCamps;

        private bool _isGameStart;

        public Team CurrentTeam
        {
            get { return _currentTeam; }
        }

        public GameController(int size, int maxUnits, int maxCamps)
        {            
            _gameHandler = new BoardHandler(new Board(size));
            _currentTeam = _gameHandler.LowerTeam;

            _maxUnits = maxUnits;
            _maxCamps = maxCamps;
            _isGameStart = false;
        }

        public bool StartGame()
        {
            if (_gameHandler.LowerTeam.Ready && _gameHandler.UpperTeam.Ready)
            {
                _isGameStart = true;
                _currentTeam = _gameHandler.LowerTeam;
                return true;
            }

            return false;
        }

        public bool Register(string teamName)
        {
            if (_gameHandler.UpperTeam == null)
            {
                _gameHandler.UpperTeam = new Team { Name = teamName };
                return true;
            }
            else if (_gameHandler.LowerTeam == null && teamName != _gameHandler.UpperTeam.Name)
            {   
                _gameHandler.LowerTeam = new Team { Name = teamName };
                return true;
            }
            else
                return false;
        }

        public List<Block> GetInitArea(Team team)
        {
            return _gameHandler.GetInitArea(team);
        }

        public bool Ready(Team team)
        {
            if ((team.Units.Count(u => u is Camp) == _maxCamps) && (team.Units.Count == _maxUnits + _maxCamps))
            {
                team.Ready = true;
                foreach (var unit in team.Units)
                {
                    if (!(unit is Camp))
                        team.ActionableUnits.Add(unit);
                }

                return true;
            }   
            return false;
        }

        public bool PlaceUnit(string teamName, IUnit unit, int row, int col)
        {
            var team = _gameHandler.GetTeamByName(teamName);
            if (team != null)
            {
                var availBlocks = _gameHandler.GetInitArea(team);
                if (availBlocks.Exists(b => b.Column == col && b.Row == row) && team.Units.Count < _maxUnits + _maxCamps)
                {
                    unit.Row = row;
                    unit.Column = col;
                    team.Units.Add(unit);
                    return true;
                }   
            }

            return false;
        }

        public List<Block> GetEmptyGroundBlocksWithinDistance(Block orgBlock, int distance)
        {
            return _gameHandler.GetEmptyGroundBlocksWithinDistance(orgBlock, distance);
        }

        public List<Block> GetMovableBlocks(IUnit unit)
        {            
            return _gameHandler.GetEmptyGroundBlocksWithinDistance(_gameHandler.Board[unit.Row, unit.Column] , unit.Speed);
        }

        public List<IUnit> GetEnemyAround(IUnit unit, int radius)
        {
            return _gameHandler.GetEnemyAround(unit, radius);
        }

        public bool RemoveUnitAt(int row, int col)
        {
            if (_gameHandler.Board[row, col] != null)
            {
                var unit = _gameHandler.GetUnitAt(row, col);
                if (unit != null)
                {
                    var team = unit.Team;
                    team.Units.Remove(unit);
                    return true;
                }
            }   
            return false;
        }

        public Block GetBlockAt(int row, int col)
        {
            return _gameHandler.Board[row, col];
        }
        
        public bool MakeAMove(IUnit unit, int row, int col)
        {
            // check if the game is still on going
            if (_gameHandler.GetWinner() != null || !_isGameStart)
                return false;

            // check if the current turn is unit's team
            var team = unit.Team;
            if (_currentTeam.Name != team.Name)
                return false;

            // check if unit is available to move (in action list)
            if (!team.ActionableUnits.Contains(unit))
                return false;

            // select the right logic for the unit
            BaseLogic logic;
            if (unit is Tanker) { logic = new TankerLogic(unit as Tanker, _gameHandler); }
            else if (unit is Ranger) { logic = new RangerLogic(unit as Ranger, _gameHandler); }
            else logic = new AmbusherLogic(unit as Ambusher, _gameHandler);
            
            if (_gameHandler.GetUnitAt(row, col) == null)
            {
                // AOE attack
                if (row == -1 && col == -1 && unit is Tanker)
                {
                    _currentTeam.ActionableUnits.Clear();
                    logic.Attack(row, col);
                    return true;
                }
                else
                {
                    if (_currentTeam.CanMoveUnit) // move
                    {
                        var cnt = _gameHandler.GetEmptyBlocksAround(GetBlockAt(row, col), unit.Range, true).Count;
                        if (cnt == unit.Range * unit.Range - 1)
                            _currentTeam.ActionableUnits.Clear();
                        else
                            _currentTeam.ActionableUnits = _currentTeam.ActionableUnits.Where(u => u.Id == unit.Id).ToList();

                        _currentTeam.CanMoveUnit = false;
                        return logic.Move(row, col);
                    }
                    else return false;
                }
                
            }
            else // attack single target
            {
                _currentTeam.ActionableUnits.Clear();
                return logic.Attack(row, col);
            }
        }

        public Team GetTeamByInitAreaLocation(int row, int column)
        {
            if (_gameHandler.GetInitArea(_gameHandler.UpperTeam).Exists(b => b.Row == row && b.Column == column)) return _gameHandler.UpperTeam;
            else if (_gameHandler.GetInitArea(_gameHandler.LowerTeam).Exists(b => b.Row == row && b.Column == column)) return _gameHandler.LowerTeam;
            else return null;
        }

        private void UpdateCooldown()
        {
            for (int i = 0; i < _gameHandler.UpperTeam.Units.Count; i++)
            {
                if (_gameHandler.UpperTeam.Units[i].CoolDown > 0)
                    _gameHandler.UpperTeam.Units[i].CoolDown--;
            }

            for (int i = 0; i < _gameHandler.LowerTeam.Units.Count; i++)
            {
                if (_gameHandler.LowerTeam.Units[i].CoolDown > 0)
                    _gameHandler.LowerTeam.Units[i].CoolDown--;
            }
        }

        public void NextTeam()
        {
            UpdateCooldown();
            _currentTeam.Units.Clear();
            _currentTeam.CanMoveUnit = false;

            if (_currentTeam.Name == _gameHandler.UpperTeam.Name) _currentTeam = _gameHandler.LowerTeam;
            else _currentTeam = _gameHandler.UpperTeam;

            // refresh
            _currentTeam.CanMoveUnit = true;
            foreach (var unit in _currentTeam.Units)
            {
                if (!(unit is Camp))
                    _currentTeam.ActionableUnits.Add(unit);
            }
        }
    }
}
