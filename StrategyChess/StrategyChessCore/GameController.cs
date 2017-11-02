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
        private BoardHandler _boardHandler;
        private Team _currentTeam;

        private int _maxUnits;
        private int _maxCamps;

        public GameState State { get; set; }

        public Team CurrentTeam
        {
            get { return _currentTeam; }
        }

        public GameController(int width, int height, int maxUnits, int maxCamps)
        {            
            _boardHandler = new BoardHandler(new Board(width, height));

            _maxUnits = maxUnits;
            _maxCamps = maxCamps;
            State = GameState.Init;
        }

        public bool StartGame()
        {
            if (_boardHandler.LowerTeam.Ready && _boardHandler.UpperTeam.Ready)
            {
                State = GameState.Playing;
                _currentTeam = _boardHandler.LowerTeam;
                _currentTeam.ActionableUnits.AddRange(TeamHandler.GetUnits(_currentTeam));
                _currentTeam.CanMoveUnit = true;
                return true;
            }

            return false;
        }

        public bool Register(string teamName)
        {
            if (_boardHandler.UpperTeam == null)
            {
                _boardHandler.UpperTeam = new Team { Name = teamName };
                return true;
            }
            else if (_boardHandler.LowerTeam == null && teamName != _boardHandler.UpperTeam.Name)
            {   
                _boardHandler.LowerTeam = new Team { Name = teamName };
                return true;
            }
            else
                return false;
        }

        public Team GetTeamByName(string name)
        {
            return _boardHandler.GetTeamByName(name);
        }

        public List<Block> GetInitArea(Team team)
        {
            return _boardHandler.GetInitArea(team);
        }

        public bool Ready(Team team)
        {
            if ((TeamHandler.GetCamps(team).Count == _maxCamps) && (TeamHandler.GetUnits(team).Count == _maxUnits))
            {
                team.Ready = true;
                return true;
            }   
            return false;
        }

        public bool PlaceUnit(string teamName, IUnit unit, int row, int col)
        {
            var team = _boardHandler.GetTeamByName(teamName);
            if (team != null)
            {
                var availBlocks = _boardHandler.GetInitArea(team);
                if (availBlocks.Exists(b => b.Column == col && b.Row == row))                     
                {
                    if (((unit is Camp) && TeamHandler.GetCamps(team).Count < _maxCamps) ||
                        (!(unit is Camp) && TeamHandler.GetUnits(team).Count < _maxUnits))
                    {
                        unit.Row = row;
                        unit.Column = col;
                        unit.Team = team;
                        team.Units.Add(unit);
                        return true;
                    }
                }   
            }

            return false;
        }

        public IUnit GetUnitAt(int row, int col)
        {
            return _boardHandler.GetUnitAt(row, col);
        }

        public List<Block> GetEmptyGroundBlocksWithinDistance(Block orgBlock, int distance)
        {
            return _boardHandler.GetEmptyGroundBlocksWithinDistance(orgBlock, distance);
        }

        public List<Block> GetMovableBlocks(IUnit unit)
        {            
            return _boardHandler.GetEmptyGroundBlocksWithinDistance(_boardHandler.Board[unit.Row, unit.Column] , unit.Speed);
        }

        public List<Block> GetMovableBlocks(IUnit unit, int row, int col)
        {
            var logic = CreateLogic(unit);
            return logic.GetAllMovableBlocks(row, col);
        }

        public List<IUnit> GetEnemyAround(IUnit unit, int row, int col)
        {
            var logic = CreateLogic(unit);
            return logic.GetAllTargets(row, col);
        }

        public List<IUnit> GetEnemyAround(IUnit unit)
        {
            var logic = CreateLogic(unit);
            return logic.GetAllTargets();
        }

        public bool RemoveUnitAt(int row, int col)
        {
            if (_boardHandler.Board[row, col] != null)
            {
                var unit = _boardHandler.GetUnitAt(row, col);
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
            return _boardHandler.Board[row, col];
        }

        private BaseLogic CreateLogic(IUnit unit)
        {
            BaseLogic logic;
            if (unit is Tanker) { logic = new TankerLogic(unit as Tanker, _boardHandler); }
            else if (unit is Ranger) { logic = new RangerLogic(unit as Ranger, _boardHandler); }
            else logic = new AmbusherLogic(unit as Ambusher, _boardHandler);

            return logic;
        }
        
        public bool MakeAMove(IUnit unit, int row, int col)
        {
            // check if the game is still on going
            if (State != GameState.Playing)
                return false;

            // check if the current turn is unit's team
            if (_currentTeam.Name != unit.Team.Name)
                return false;

            // check if unit is available to move (in action list)
            if (!unit.Team.ActionableUnits.Contains(unit))
                return false;

            // select the right logic for the unit
            var logic = CreateLogic(unit);
            logic.OnCampDestroyed = CampDestroyed;
            
            if (_boardHandler.GetUnitAt(row, col) == null)
            {
                // AOE attack
                if (row == -1 && col == -1 && unit is Tanker)
                {
                    if (unit.CurrentCoolDown == 0)
                    {
                        _currentTeam.ActionableUnits.Clear();
                        logic.Attack(row, col);
                        return true;
                    }
                    else return false;
                }
                else
                {
                    if (_currentTeam.CanMoveUnit) // move
                    {
                        var moveSuccess = logic.Move(row, col);
                        if (moveSuccess)
                        {
                            var enemyUnits = GetEnemyAround(unit);
                            var cnt = enemyUnits != null ? enemyUnits.Count : 0;
                            if (cnt == 0)
                                _currentTeam.ActionableUnits.Clear();
                            else
                                _currentTeam.ActionableUnits = _currentTeam.ActionableUnits.Where(u => u.Id == unit.Id).ToList();

                            _currentTeam.CanMoveUnit = false;
                            return true;
                        }
                        return moveSuccess;
                    }
                    else return false;
                }
            }
            else // attack single target
            {
                if (unit.CurrentCoolDown == 0)
                {
                    _currentTeam.ActionableUnits.Clear();
                    return logic.Attack(row, col);
                }
                else return false;
            }
        }

        private void CampDestroyed(Team team)
        {
            State = GameState.CampDestroyed;
        }

        public Team GetTeamByInitAreaLocation(int row, int column)
        {
            if (_boardHandler.UpperTeam == null &&
                _boardHandler.LowerTeam == null)
                return null;

            if (_boardHandler.GetInitArea(_boardHandler.UpperTeam).Exists(b => b.Row == row && b.Column == column)) return _boardHandler.UpperTeam;
            else if (_boardHandler.GetInitArea(_boardHandler.LowerTeam).Exists(b => b.Row == row && b.Column == column)) return _boardHandler.LowerTeam;
            else return null;
        }

        private void UpdateCooldown()
        {
            for (int i = 0; i < _boardHandler.UpperTeam.Units.Count; i++)
            {
                if (_boardHandler.UpperTeam.Units[i].CurrentCoolDown > 0)
                    _boardHandler.UpperTeam.Units[i].CurrentCoolDown--;
            }

            for (int i = 0; i < _boardHandler.LowerTeam.Units.Count; i++)
            {
                if (_boardHandler.LowerTeam.Units[i].CurrentCoolDown > 0)
                    _boardHandler.LowerTeam.Units[i].CurrentCoolDown--;
            }
        }

        public void NextTeam()
        {
            UpdateCooldown();
            _currentTeam.ActionableUnits.Clear();
            _currentTeam.CanMoveUnit = false;

            if (_currentTeam.Name == _boardHandler.UpperTeam.Name) _currentTeam = _boardHandler.LowerTeam;
            else _currentTeam = _boardHandler.UpperTeam;

            // refresh
            _currentTeam.CanMoveUnit = true;
            _currentTeam.ActionableUnits.Clear();
            _currentTeam.ActionableUnits.AddRange(_currentTeam.Units.Where(u => !(u is Camp)));
        }
    }
}
