
using System.Collections.Generic;


namespace WindowsFormsApplication1.classes
{
    class Company
    {
        public string name { get; set; }
        List<Realtor> realtors = new List<Realtor>();
        List<RealEstate> realEstates = new List<RealEstate>();

        public void SetRealtor (Realtor realtor)
        {
            realtors.Add(realtor);
        }
        public int GetRealtorsCount()
        {
            return realtors.Count;
        }
        public string GetRealtor(int index)
        {
            return realtors[index].name;
        }
        public void SetRealEstate(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }
        public int GetRealEstatesCount()
        {
            return realEstates.Count;
        }
        public string GetRealEstate(int index)
        {
            return realEstates[index].address;
        }
        public List<RealEstate> GetRealEstates()
        {
            return realEstates;
        }
    }
}
