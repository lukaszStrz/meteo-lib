using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Meteo_Lib
{
    public class Meteo
    {
        /// <summary>
        /// Downloads an image from given URI.
        /// </summary>
        private async Task<MemoryStream> DownloadImgAsync(Uri uri)
        {
            var client = new WebClient();
            var data = await client.DownloadDataTaskAsync(uri);
            return new MemoryStream(data);
        }

        /// <summary>
        /// Downloads the UM model for given location.
        /// </summary>
        /// <param name="coord">Coordinates</param>
        public async Task<MemoryStream> UM(Coordinates coord)
        {
            var uri = await ResolveAsyncUM(coord);
            var result = await DownloadImgAsync(GetImgUri(uri));
            return result;
        }

        /// <summary>
        /// Downloads the COAMPS model for given location.
        /// </summary>
        /// <param name="coord">Coordinates</param>
        public async Task<MemoryStream> COAMPS(Coordinates coord)
        {
            var uri = await ResolveAsyncCOAMPS(coord);
            var result = await DownloadImgAsync(GetImgUri(uri));
            return result;
        }

        #region URI from coordinates

        /// <summary>
        /// Returns URI with row and col for given location.
        /// </summary>
        /// <param name="coord">Coordinates</param>
        /// <param name="uriBeg">UM/COAMPS search uri</param>
        private async Task<string> ResolveAsync(Coordinates coord, string uriBeg)
        {
            var sb = new StringBuilder();
            sb.Append(uriBeg);
            sb.Append(@"NALL=");
            sb.Append(coord.NALL);
            sb.Append(@"&EALL=");
            sb.Append(coord.EALL);

            var uri = new Uri(sb.ToString());

            var request = (HttpWebRequest)WebRequest.Create(uri);
            var response = await request.GetResponseAsync();
            return ((HttpWebResponse)response).ResponseUri.ToString();
        }

        /// <summary>
        /// Returns UM model URI with row and col for given location.
        /// </summary>
        /// <param name="coord">Coordinates</param>
        private async Task<string> ResolveAsyncUM(Coordinates coord)
        {
            var result = await ResolveAsync(coord, @"http://www.meteo.pl/um/php/mgram_search.php?");
            return result;
        }

        /// <summary>
        /// Returns COAMPS model URI with row and col for given location.
        /// </summary>
        /// <param name="coord">Coordinates</param>
        private async Task<string> ResolveAsyncCOAMPS(Coordinates coord)
        {
            var result = await ResolveAsync(coord, @"http://www.meteo.pl/php/mgram_search.php?");
            return result;
        }

        /// <summary>
        /// Returns model image URI.
        /// </summary>
        /// <param name="meteoUri">Model URI</param>
        private Uri GetImgUri(string meteoUri)
        {
            if (!meteoUri.Contains(@"row=") || !meteoUri.Contains(@"col="))
            {
                throw new ResolveException();
            }

            string substring = meteoUri.Substring(meteoUri.IndexOf('?'));

            return new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php" + substring);
        }

        #endregion
    }
}
