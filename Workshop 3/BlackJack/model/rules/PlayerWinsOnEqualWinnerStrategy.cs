using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinsOnEqualWinnerStrategy : IWinnerStrategy
    {
        public bool GetWinner(int a_dealerScore, int a_playerScore)
        {
            if (a_dealerScore > a_playerScore)
                return true;

            return false;
        }
    }
}
