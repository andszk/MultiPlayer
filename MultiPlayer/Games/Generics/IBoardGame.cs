using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.Games.Generics
{
    interface IBoardGame<TBoard> where TBoard : Board
    {
        TBoard Board { get; set; }

        event EventHandler GameStateChanged;
    }
}
