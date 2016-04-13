using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicArt.Util.Spatial
{
    public static class Geography
    {
        public static readonly int CoordinateSystemId = 4326;

        public static DbGeography CreateFromLatLng(double latitude, double longitude)
        {
            return DbGeography.FromText($"POINT({latitude} {longitude})", CoordinateSystemId);
        }
    }
}
