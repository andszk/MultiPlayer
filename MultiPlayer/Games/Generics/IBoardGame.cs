﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPlayer
{
    public interface IBoardGame
    {
        Board BoardState { get; set; }
    }
}