using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt_DotNet6.Classes.Enums
{
    [Flags]
    public enum CollarColor
    {
        None = 0,
        Red = 1,
        Blue = 2,
        Green = 4,
        Orange = 8,
        Purple = 16,
        Indigo = 32,
        Violet = 64,
        Pink = 128,
        White = 256,
        Black = 512
    }
}
