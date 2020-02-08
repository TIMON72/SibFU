using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Result
    {
        public double x { get; set; }
        public double f { get; set; }
        public double result { get; set; }
        public int count { get; set; }

        public Result(double x, double f, double result, int count)
        {
            this.x = x;
            this.f = f;
            this.result = result;
            this.count = count;
        }
    }
}
