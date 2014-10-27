using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
        private List<ICardListener> m_subscribers;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;


        public Dealer(rules.RulesFactory a_rulesFactory, string a_name)
            :base (a_name)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_subscribers = new List<ICardListener>();
        }

        public void Register(ICardListener a_subscriber)
        {
            m_subscribers.Add(a_subscriber);
        }

        public void DrawCard(Player a_user, bool a_hidden)
        {
            Card c = m_deck.GetCard();
            c.Show(a_hidden);
            a_user.DealCard(c);

            foreach (var l in m_subscribers)
            {
                l.CardListener();
            }
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                DrawCard(a_player, true);

                return true;
            }
            return false;
        }

        public void Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
            }

            while (m_hitRule.DoHit(this))
            {
                DrawCard(this, true);
            }
        }

        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }

            return m_winnerRule.GetWinner(CalcScore(), a_player.CalcScore());//CalcScore() >= a_player.CalcScore();
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
