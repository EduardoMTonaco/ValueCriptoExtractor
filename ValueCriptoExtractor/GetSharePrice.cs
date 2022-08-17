using System.Net;

namespace ValueCriptoExtractor
{
    public class GetSharePrice : IFindValue
    {
        private IRegexExtrator RegexTools { get; set; }
        private string Url { get; set; }
        public GetSharePrice(IRegexExtrator regexTools, string url)
        {
            RegexTools = regexTools;
            Url = url;
        }
        public string DownloadWebPageString()
        {
            try
            {
                var webClient = new WebClient();
                return webClient.DownloadString(Url);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"no internet connection or invalid url. Error: {ex.Message}");
            }
        }
        public double FindValue(Format format)
        {
            if (format == Format.Standart)
            {
                return Convert.ToDouble(RegexTools.GetRegex(DownloadWebPageString()).Replace(",", ""));
            }
            return Convert.ToDouble(RegexTools.GetRegex(DownloadWebPageString()).Replace(",", "").Replace(".", ","));
        }
    }
}