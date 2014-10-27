using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.view;
using BlackJack.model;

namespace BlackJack.controller
{
    class PlayGame : ICardListener
    {
        IView m_view;
        model.Game m_game;

        public PlayGame(IView a_view, model.Game a_game)
        {
            m_view = a_view;
            m_game = a_game;
        }

        public bool Play()
        {
            RenderGame();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
            
            switch (m_view.GetMenuChoice())
            {
                case MenuChoices.PlayGame:
                    m_game.NewGame();
                    break;
                case MenuChoices.Hit:
                    m_game.Hit();
                    break;
                case MenuChoices.Stay:
                    m_game.Stand();
                    break;
                case MenuChoices.Quit:
                    return false;
            }

            return true;
        }

        public void CardListener()
        {
            System.Threading.Thread.Sleep(1000);
            RenderGame();
        }

        public void RenderGame()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}