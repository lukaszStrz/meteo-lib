using System;
using System.IO;
using System.Threading.Tasks;

namespace Meteo_Lib
{
    public class Location
    {
        public Uri UM { get; private set; }
        public Uri COAMPS { get; private set; }

        /// <summary>
        /// Location coordinates
        /// </summary>
        public Coordinates Coords { get; private set; }

        private Location() { }

        internal Location(Coordinates coords, Uri um, Uri coamps)
        {
            this.Coords = coords;
            this.UM = um;
            this.COAMPS = coamps;
        }

        public async Task<MemoryStream> Get(Model model)
        {
            switch (model)
            {
                case Model.UM:
                    {
                        var result = await Meteo.Download(UM);
                        return result;
                    }
                case Model.COAMPS:
                    {
                        var result = await Meteo.Download(COAMPS);
                        return result;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
