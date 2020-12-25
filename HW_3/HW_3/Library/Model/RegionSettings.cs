using Library.Interfaces;

namespace Library.Model
{
    public class RegionSettings : IRegionSettings
    {
        public string WebSite { get; }

        public RegionSettings(string web)
        {
            WebSite = web;
        }

        public override string ToString()
        {
            return $"[{WebSite}]";
        }
    }
}