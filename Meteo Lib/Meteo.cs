using System;
using System.IO;
using System.Net;
using System.Text;

namespace Meteo_Lib
{
    public class Meteo
    {
        #region Private functions

        string resolve(Coordinates coord, string urlBeg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(urlBeg);
            sb.Append(@"NALL=");
            sb.Append(coord.NALL);
            sb.Append(@"&EALL=");
            sb.Append(coord.EALL);

            var uri = new Uri(sb.ToString());

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.ResponseUri.ToString();
        }

        string resolveUM(Coordinates coord)
        {
            return resolve(coord, @"http://www.meteo.pl/um/php/mgram_search.php?");
        }

        string resolveCOAMPS(Coordinates coord)
        {
            return resolve(coord, @"http://www.meteo.pl/php/mgram_search.php?");
        }

        string getImgUri(string meteoUri)
        {
            if (!meteoUri.Contains(@"row=") || !meteoUri.Contains(@"col="))
            {
                throw new ResolveException();
            }

            string substring = meteoUri.Substring(meteoUri.IndexOf('?'));

            StringBuilder sb = new StringBuilder();
            sb.Append(@"http://www.meteo.pl/um/metco/mgram_pict.php");
            sb.Append(substring);

            return sb.ToString();
        }

        #endregion

        #region Public functions

        MemoryStream UM(Coordinates coord)
        {
            string um = resolveUM(coord);
            string img = getImgUri(um);
            return new MemoryStream(new WebClient().DownloadData(img));
        }

        MemoryStream COAMPS(Coordinates coord)
        {
            string coamps = resolveCOAMPS(coord);
            string img = getImgUri(coamps);
            return new MemoryStream(new WebClient().DownloadData(img));
        }

        #endregion
    }
}
