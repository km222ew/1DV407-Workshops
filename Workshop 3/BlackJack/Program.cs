using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Dealer d = new model.Dealer(new model.rules.RulesFactory(), "Croupier");
            model.Player p = new model.Player("Player");
            model.Game g = new model.Game(d, p);
            view.IView v = new view.SwedishView();//new view.SimpleView();
            controller.PlayGame ctrl = new controller.PlayGame(v, g);

            d.Register(ctrl);

            while (ctrl.Play());
        }
    }
}
