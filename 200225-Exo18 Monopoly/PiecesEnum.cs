using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    public enum PIECES
    {
        NONE = 0,
        CAT = 1 << 0, //equiv 0b0001
        DOG = 1 << 1, //equiv 0b0010
        HAT = 1 << 2, //equiv 0b0100
        SHOE = 1 << 3, //equiv 0b1000
    }
}
