using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoAbstractInterface.Models
{
    internal interface IDeformable
    {
        public Figure Deform(double coefH, double coefV);
    }
}
