using System;

namespace RockPaperScissors
{
    public class BasicGameFunctionality
    {
        public BasicGameFunctionality() {}
        public BasicGameFunctionality(int rounds)
        {
        	_roundsPerGame = rounds;
        }
        public int _roundsPerGame {get; set;} = 3;
        public int _totalGamesPlayed {get;set;} = 0;
        public int _totalGamesUser1Won {get; set;} = 0;
        public int _totalGamesTied {get; set;} = 0;
        public int _roundsWon{get; set;} = 0;
        public int _roundsLost{get; set;} = 0;
        public int _roundsTied{get; set;} = 0;        
        
        public void AddNewRoundResult(int roundResults)
        {
            if(roundResults > 0)
            {
                _roundsWon++; 
            }
            else if(roundResults == 0)
            {
                _roundsTied++;
            }
            else
            {
            	_roundsLost++;
            }
        }

        public int CurrentLeader()
        {
        	return _roundsWon - _roundsLost;
        }

        public void UpdateGameTotalsWithCurrentRoundResults()
        {
        	int game_leader = CurrentLeader();
            if(game_leader > 0)
            {
                _totalGamesUser1Won++; 
            }
            else if(game_leader == 0)
            {
                _totalGamesTied++;
            }
            _totalGamesPlayed++;
        }

        public void ResetRoundTotals()
        {
        	_roundsWon = 0;
        	_roundsLost = 0;
        	_roundsTied = 0;
        }

        public void ResetGameTotals()
        {
        	_totalGamesPlayed = 0;
        	_totalGamesTied = 0;
        	_totalGamesUser1Won = 0;
        }
    }
}