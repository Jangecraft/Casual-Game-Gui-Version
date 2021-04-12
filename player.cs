using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class player
    {
        //string name = "Name Player";
        //string lastName = "";
        //string lv = "0";

        //public string Name { get => name; set => name = value; }
        //public string Lv { get => lv; set => lv = value; }

        public DataPlayer Lv_up(int maxexp, int exp, int expl, int plv)
        {
            DataPlayer Dp = new DataPlayer();
            maxexp = plv * 100;
            if (exp >= maxexp)
            {
                expl = exp;
                while (expl >= maxexp)
                {
                    maxexp = plv * 100;

                    expl = expl - maxexp;
                    plv += 1;
                }
                exp = expl;
            }
            Dp.Lv = plv.ToString();
            Dp.Exp = exp.ToString();
            Dp.MaxExp = maxexp.ToString();

            return Dp;
        }
    }
}
