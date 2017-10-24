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
        private NetworkProcessor _connector;
        private BoardHandler _gameHandler;
        private Team _currentTeam;

        // Game logics
        private List<BaseLogic> _logics;

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
            _logics = new List<BaseLogic>();
            _logics.AddRange(new BaseLogic[]{ new TankerLogic(), new RangerLogic(), new AmbusherLogic()});

            _currentTeam = _gameHandler.LowerTeam;

            _maxUnits = maxUnits;
            _maxCamps = maxCamps;
            _isGameStart = false;
        }

        public void Run()
        {
            // _connector.OnClientRegister += Connector_OnClientRegister;
            // _connector.OnClientReady += Connector_OnClientReady;
            // _connector.OnClientMove += Connector_OnClientMove;

            _connector.Start();
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
            else if (_gameHandler.LowerTeam == null)
            {
                if (teamName == _gameHandler.UpperTeam.Name)
                    return false;
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

        public Team GetTeamByName(string teamName)
        {
            return _gameHandler.GetTeamByName(teamName);
        }

        public Team GetTeam(IUnit unit)
        {
            return _gameHandler.GetTeam(unit);
        }

        public bool PlaceUnit(string teamName, IUnit unit, int row, int col)
        {
            var team = _gameHandler.GetTeamByName(teamName);
            if (team != null)
            {
                var availBlocks = _gameHandler.GetInitArea(team);

                if (team.Units != null && team.Units.Count < _maxUnits + _maxCamps)
                {   
                    team.Units.Add(unit);
                    if (availBlocks.Exists(b => b.Column == col && b.Row == row))
                    {
                        _gameHandler.Board[row, col].Unit = unit;
                        return true;
                    }   
                    else return false;
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
            return _gameHandler.GetEmptyGroundBlocksWithinDistance(_gameHandler.Board[unit.Id], unit.Speed);
        }

        public List<IUnit> GetEnemyAround(IUnit unit, int radius)
        {
            return _gameHandler.GetEnemyAround(unit, radius);
        }

        public bool RemoveUnitAt(int row, int col)
        {
            if (_gameHandler.Board[row, col] != null)
            {
                var team = _gameHandler.GetTeam(_gameHandler.Board[row, col].Unit);
                team.Units.Remove(_gameHandler.Board[row, col].Unit);
                _gameHandler.Board[row, col].Unit = null;
                return true;
            }   
            return false;
        }

        public Block GetBlockAt(int row, int col)
        {
            return _gameHandler.Board[row, col];
        }

        private bool AOEAttack(IUnit unit, BaseLogic logic)
        {
            if (unit.CoolDown > 0) return false;

            var targets = _gameHandler.GetEnemyAround(unit, unit.Range);
            if (targets != null)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    targets[i].HP -= 1;
                    if (targets[i].HP <= 0)
                    {
                        _gameHandler.Board[targets[i].Id].Unit = null;
                        _gameHandler.GetTeam(targets[i]).Units.Remove(targets[i]);
                    }
                }

                unit.CurrentCoolDown = unit.CoolDown;
                return true;
            }
            return false;
        }

        private bool Attack(IUnit unit, BaseLogic logic, IUnit target)
        {
            if (target != null)
            {
                var targets = logic.GetAllTargets(unit);
                if (targets.Exists(t => t.Id == target.Id))
                {
                    target.HP -= 1;
                    if (target.HP <= 0)
                    {
                        _gameHandler.Board[target.Id].Unit = null;
                        _gameHandler.GetTeam(target).Units.Remove(target);
                    }
                    unit.CurrentCoolDown = unit.CoolDown;

                    return true;
                }
            }

            return false;
        }

        private bool Move(IUnit unit, BaseLogic logic, int row, int col)
        {
            var moves = logic.GetAllMoveableBlocks(unit);
            if (moves.Exists(b => b.Row == row && b.Column == col))
            {
                _gameHandler.Board[row, col].Unit = unit;
                _gameHandler.Board[unit.Id].Unit = null;
                return true;
            }
            return false;
        }

        public bool MakeAMove(IUnit unit, int row, int col)
        {
            // check if the game is still on going
            if (_gameHandler.GetWinner() != null || !_isGameStart)
                return false;

            // check if the current turn is unit's team
            var team = _gameHandler.GetTeam(unit);
            if (_currentTeam.Name != team.Name)
                return false;

            // check if unit is available to move (in action list)
            if (!team.ActionableUnits.Contains(unit))
                return false;

            // select the right logic for the unit
            BaseLogic logic;
            if (unit is Tanker) { logic = _logics.FirstOrDefault(l => l is TankerLogic); }
            else if (unit is Ranger) { logic = _logics.FirstOrDefault(l => l is RangerLogic); }
            else logic = _logics.FirstOrDefault(l => l is AmbusherLogic);
            
            if (_gameHandler.Board[row, col].Unit == null)
            {
                // AOE attack
                if (row == -1 && col == -1)
                {
                    _currentTeam.ActionableUnits.Clear();
                    return AOEAttack(unit, logic);
                }
                else
                {
                    if (_currentTeam.CanMoveUnit)
                    {
                        var cnt = _gameHandler.GetBlocksAround(_gameHandler.Board[row, col], unit.Range, true).Count;
                        if (cnt == unit.Range * unit.Range - 1)
                            _currentTeam.ActionableUnits.Clear();
                        else
                            _currentTeam.ActionableUnits = _currentTeam.ActionableUnits.Where(u => u.Id == unit.Id).ToList();

                        _currentTeam.CanMoveUnit = false;
                        return Move(unit, logic, row, col);
                    }
                    else return false;
                }
                
            }
            else
            {
                _currentTeam.ActionableUnits.Clear();
                var target = _gameHandler.Board[row, col].Unit;
                return Attack(unit, logic, target);
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
