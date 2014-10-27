using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            IEnumerable<Card> hand = a_dealer.GetHand();

            if (a_dealer.CalcScore() == 17)
            {
                foreach (var card in hand)
                {
                    if (card.GetValue() == Card.Value.Ace)
                    {
                        return true;
                    }
                }
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
