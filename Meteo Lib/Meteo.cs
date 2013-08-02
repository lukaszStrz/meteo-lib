using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Meteo_Lib
{
    public static class Meteo
    {
        #region Public functions

        public static async Task<MemoryStream> MainCity(City city, Model model)
        {
            switch (model)
            {
                case Model.UM:
                    switch (city)
                    {
                        case City.BIALYSTOK:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=379&col=285&lang=pl"));
                        case City.BYDGOSZCZ:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=381&col=199&lang=pl"));
                        case City.GDANSK:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=346&col=210&lang=pl"));
                        case City.GORZOW_WIELKOPOLSKI:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=390&col=152&lang=pl"));
                        case City.KATOWICE:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=461&col=215&lang=pl"));
                        case City.KIELCE:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=443&col=244&lang=pl"));
                        case City.KRAKOW:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=466&col=232&lang=pl"));
                        case City.LUBLIN:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=432&col=277&lang=pl"));
                        case City.LODZ:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=418&col=223&lang=pl"));
                        case City.OLSZTYN:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=363&col=240&lang=pl"));
                        case City.OPOLE:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=449&col=196&lang=pl"));
                        case City.POZNAN:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=400&col=180&lang=pl"));
                        case City.RZESZOW:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=465&col=269&lang=pl"));
                        case City.SZCZECIN:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=370&col=142&lang=pl"));
                        case City.TORUN:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=383&col=209&lang=pl"));
                        case City.WARSZAWA:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=406&col=250&lang=pl"));
                        case City.WROCLAW:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=436&col=181&lang=pl"));
                        case City.ZIELONA_GORA:
                            return await Download(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=412&col=155&lang=pl"));
                        default:
                            throw new NotImplementedException();
                    }
                case Model.COAMPS:
                    switch (city)
                    {
                        case City.BIALYSTOK:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=125&col=106&lang=pl"));
                        case City.BYDGOSZCZ:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=126&col=81&lang=pl"));
                        case City.GDANSK:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=115&col=84&lang=pl"));
                        case City.GORZOW_WIELKOPOLSKI:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=129&col=67&lang=pl"));
                        case City.KATOWICE:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=150&col=85&lang=pl"));
                        case City.KIELCE:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=145&col=94&lang=pl"));
                        case City.KRAKOW:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=151&col=91&lang=pl"));
                        case City.LUBLIN:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=141&col=104&lang=pl"));
                        case City.LODZ:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=137&col=88&lang=pl"));
                        case City.OLSZTYN:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=120&col=93&lang=pl"));
                        case City.OPOLE:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=146&col=80&lang=pl"));
                        case City.POZNAN:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=132&col=75&lang=pl"));
                        case City.RZESZOW:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=151&col=101&lang=pl"));
                        case City.SZCZECIN:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=123&col=63&lang=pl"));
                        case City.TORUN:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=127&col=84&lang=pl"));
                        case City.WARSZAWA:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=133&col=96&lang=pl"));
                        case City.WROCLAW:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=143&col=75&lang=pl"));
                        case City.ZIELONA_GORA:
                            return await Download(new Uri(@"http://www.meteo.pl/metco/mgram_pict.php?ntype=2n&row=135&col=68&lang=pl"));
                        default:
                            throw new NotImplementedException();
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        public static async Task<Location> GetLocation(Coordinates coords)
        {
            var um = await Redirect(coords, Model.UM);
            var coamps = await Redirect(coords, Model.COAMPS);
            return new Location(coords, Image(um, Model.UM), Image(coamps, Model.COAMPS));
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Downloads an image from given URI.
        /// </summary>
        internal static async Task<MemoryStream> Download(Uri uri)
        {
            var client = new WebClient();
            var data = await client.DownloadDataTaskAsync(uri);
            return new MemoryStream(data);
        }

        /// <summary>
        /// Redirects to get row and col values.
        /// </summary>
        /// <param name="coords">Coordinates</param>
        /// <param name="model">Model</param>
        /// <returns>URI of a meteogram (page, not image!)</returns>
        private static async Task<Uri> Redirect(Coordinates coords, Model model)
        {
            var sb = new StringBuilder();

            switch (model)
            {
                case Model.UM:
                    sb.Append(@"http://www.meteo.pl/um/php/mgram_search.php?");
                    break;
                case Model.COAMPS:
                    sb.Append(@"http://www.meteo.pl/php/mgram_search.php?");
                    break;
                default:
                    throw new NotImplementedException();
            }
            sb.Append(@"NALL=");
            var lat = coords.Latitude;
            if (model == Model.COAMPS)
                lat = Math.Truncate(lat);
            sb.Append(lat);
            sb.Append(@"&EALL=");
            var lng = coords.Longitude;
            if (model == Model.COAMPS)
                lng = Math.Truncate(lng);
            sb.Append(lng);

            var uri = new Uri(sb.ToString());

            var request = (HttpWebRequest)WebRequest.Create(uri);
            var response = await request.GetResponseAsync();
            return ((HttpWebResponse)response).ResponseUri;
        }

        private static Uri Image(Uri meteogram, Model model)
        {
            var m = meteogram.ToString();
            if (!m.Contains(@"row=") || !m.Contains(@"col="))
            {
                throw new ResolveException();
            }
            string substring = m.Substring(m.IndexOf('?'));

            var sb = new StringBuilder();
            switch (model)
            {
                case Model.UM:
                    sb.Append(@"http://www.meteo.pl/um/metco/mgram_pict.php");
                    break;
                case Model.COAMPS:
                    sb.Append(@"http://www.meteo.pl/metco/mgram_pict.php");
                    break;
                default:
                    throw new NotImplementedException();
            }
            sb.Append(substring);

            return new Uri(sb.ToString());
        }

        #endregion
    }
}
