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

        #region Main cities UM

        public async Task<MemoryStream> BialystokUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=379&col=285&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> BydgoszczUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=381&col=199&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> GdanskUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=346&col=210&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> GorzowUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=390&col=152&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> KatowiceUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=461&col=215&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> KielceUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=443&col=244&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> KrakowUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=466&col=232&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> LublinUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=432&col=277&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> LodzUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=418&col=223&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> OlsztynUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=363&col=240&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> OpoleUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=449&col=196&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> PoznanUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=400&col=180&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> RzeszowUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=465&col=269&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> SzczecinUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=370&col=142&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> TorunUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=383&col=209&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> WarszawaUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=406&col=250&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> WroclawUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=436&col=181&lang=pl"));
            return result;
        }

        public async Task<MemoryStream> ZielonaGoraUM()
        {
            var result = await DownloadImgAsync(new Uri(@"http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&row=412&col=155&lang=pl"));
            return result;
        }

        #endregion
    }
}
