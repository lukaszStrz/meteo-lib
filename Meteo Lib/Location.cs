using System;
using System.IO;
using System.Threading.Tasks;

namespace Meteo_Lib
{
    public class Location
    {
        public string UM { get; private set; }
        public string COAMPS { get; private set; }

        /// <summary>
        /// Location coordinates
        /// </summary>
        public Coordinates Coords { get; private set; }

        private Location() { }

        internal Location(Coordinates coords)
        {
            this.Coords = coords;
            UM = string.Empty;
            COAMPS = string.Empty;
        }

        //internal Location(Coordinates coords, string um, string coamps)
        //{
        //    this.Coords = coords;
        //    this.UM = um;
        //    this.COAMPS = coamps;
        //}

        public async Task<MemoryStream> Get(Model model)
        {
            switch (model)
            {
                case Model.UM:
                    {
                        if (string.IsNullOrEmpty(UM))
                        {
                            UM = await Meteo.Redirect(Coords, Model.UM);
                            UM = Meteo.Image(UM, Model.UM);
                        }
                        var result = await Meteo.Download(UM);
                        return result;
                    }
                case Model.COAMPS:
                    {
                        if (string.IsNullOrEmpty(COAMPS))
                        {
                            COAMPS = await Meteo.Redirect(Coords, Model.COAMPS);
                            COAMPS = Meteo.Image(COAMPS, Model.COAMPS);
                        }
                        var result = await Meteo.Download(COAMPS);
                        return result;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
