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

        public Team CurrentTeam
        {
            get { return _currentTeam; }
        }

        public GameController(int size, int maxUnits)
        {            
            _gameHandler = new BoardHandler(new Board(size));
            _logics = new List<BaseLogic>();
            _logics.AddRange(new BaseLogic[]{ new TankerLogic(), new RangerLogic(), new AmbusherLogic()});

            _currentTeam = _gameHandler.UpperTeam;

            _maxUnits = maxUnits;
        }

        public void Run()
        {
            // _connector.OnClientRegister += Connector_OnClientRegister;
            // _connector.OnClientReady += Connector_OnClientReady;
            // _connector.OnClientMove += Connector_OnClientMove;

            _connector.Start();
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
            else return false;
        }

        public bool PlaceUnit(string teamName, IUnit unit, int row, int col)
        {
            var team = _gameHandler.GetTeamByName(teamName);
            if (team != null)
            {
                if (team.Units != null && team.Units.Count < _maxUnits)
                {
                    team.Units.Add(unit);
                    if (_gameHandler.Board[row, col] != null && _gameHandler.Board[row, col].Unit == null)
                    {
                        _gameHandler.Board[row, col].Unit = unit;
                        return true;
                    }   
                    else return false;
                }
            }

            return false;
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

        public Block GetBlock(int row, int col)
        {
            return _gameHandler.Board[row, col];
        }

        public bool MakeAMove(IUnit unit, int row, int col)
        {
            BaseLogic logic;
            if (unit is Tanker) { logic = _logics.FirstOrDefault(l => l is TankerLogic); }
            else if (unit is Ranger) { logic = _logics.FirstOrDefault(l => l is RangerLogic); }
            else logic = _logics.FirstOrDefault(l => l is AmbusherLogic);

            if (_gameHandler.Board[row, col].Unit == null)
            {
                if (row == -1 && col == -1 && unit.CurrentCoolDown == 0)
                {
                    logic.Attack(unit, row, col);
                    unit.CurrentCoolDown = unit.CoolDown;
                    return true;
                }
                else
                {
                    var moves = logic.GetAllMoveableBlocks(unit);
                    if (moves.Exists(b => b.Row == row && b.Column == col))
                    {
                        logic.Move(unit, row, col);
                        return true;
                    }
                }
            }
            else
            {
                var targets = logic.GetAllTargets(unit);
                if (targets.Exists(t => t.Id == unit.Id) && unit.CoolDown == 0)
                {
                    logic.Attack(unit, row, col);
                    unit.CurrentCoolDown = unit.CoolDown;
                    return true;
                } 
            }

            return false;
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
            if (_currentTeam.Name == _gameHandler.UpperTeam.Name) _currentTeam = _gameHandler.LowerTeam;
            else _currentTeam = _gameHandler.UpperTeam;
        }

    }
}
