using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class Company
    {
        public string name;
        public List<Realtor> realtors = new List<Realtor>();
        public List<RealEstate> realEstates = new List<RealEstate>();
    }
}
