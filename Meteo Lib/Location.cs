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

        internal Location(Uri um, Uri coamps)
        {
            this.um = um;
            this.coamps = coamps;
        }

        public async Task<MemoryStream> Get(Model model)
        {
            switch (model)
            {
                case Model.UM:
                    return await Meteo.Download(um);
                case Model.COAMPS:
                    return await Meteo.Download(coamps);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
