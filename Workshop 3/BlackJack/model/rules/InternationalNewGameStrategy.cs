using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Dealer a_dealer, Player a_player) //-deck
        {
            a_dealer.DrawCard(a_player, true);
            a_dealer.DrawCard(a_dealer, true);
            a_dealer.DrawCard(a_player, true);

            return true;
        }
    }
}
