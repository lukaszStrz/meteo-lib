using System;
using System.IO;
using System.Threading.Tasks;

namespace Meteo_Lib
{
    public class Location
    {
        Uri um;
        Uri coamps;

        /// <summary>
        /// Location coordinates
        /// </summary>
        public Coordinates Coords { get; private set; }

        private Location() { }

        internal Location(Coordinates coords, Uri um, Uri coamps)
        {
            this.Coords = coords;
            this.um = um;
            this.coamps = coamps;
        }

        public async Task<MemoryStream> Get(Model model)
        {
            switch (model)
            {
                case Model.UM:
                    {
                        var result = await Meteo.Download(um);
                        return result;
                    }
                case Model.COAMPS:
                    {
                        var result = await Meteo.Download(coamps);
                        return result;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
