using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Kofe2 : Kofe
    {
        public override void Vtimer()
        {
            MinusVoda = Round;    //округляем значение выше
            Voda = Voda - 2 * MinusVoda;
        }
    }
}
