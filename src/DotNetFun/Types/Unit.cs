using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBase.Types
{
    class Unit
    {
        private Unit()
        {
            
        }

        public static Unit Value()
        {
            return new Unit();
        }
    }
}
