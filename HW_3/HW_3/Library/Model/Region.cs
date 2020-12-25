using Library.Interfaces;

namespace Library.Model
{
    public class Region : IRegion
    {
        public string Brand { get; }
        public string Country { get; }

        public Region(string brand, string country)
        {
            Brand = brand;
            Country = country;
        }

        public override string ToString()
        {
            return $"[{Brand}],[{Country}] =";
        }

        public override int GetHashCode()
        {
            return Brand.GetHashCode() ^ Country.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Region regObj = (Region) obj;
            
            if (this == regObj)
                return true;
            
            return regObj != null && string.Equals(Brand, regObj.Brand) && string.Equals(Country, regObj.Country);
        }
    }
}