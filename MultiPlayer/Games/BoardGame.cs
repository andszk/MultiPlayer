using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPlayer
{
    public interface BoardGame
    {
        Board Board { get; set; }
    }
}