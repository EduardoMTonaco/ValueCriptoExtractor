using System.Text.RegularExpressions;

namespace ValueCriptoExtractor
{
    public class RegexExtrator : IRegexExtrator
    {
        public RegexExtrator(string regExpression, string firstExpression, string endExpression)
        {
            RegExpression = regExpression;
            FirstExpression = firstExpression;
            EndExpression = endExpression;
            FullExpression = FirstExpression + RegExpression + EndExpression;
        }
        public RegexExtrator(string regExpression, string firstExpression)
        {
            RegExpression = regExpression;
            FirstExpression = firstExpression;
            EndExpression = "";
            FullExpression = FirstExpression + RegExpression + EndExpression;
        }
        public RegexExtrator(string regExpression)
        {
            RegExpression = regExpression;
            FirstExpression = "";
            EndExpression = "";
            FullExpression = FirstExpression + RegExpression + EndExpression;
        }
        private string RegExpression { get; set; }
        private string FirstExpression { get; set; }
        private string EndExpression { get; set; }
        private string FullExpression { get; set; }
        public string GetRegex(string text)
        {
            try
            {
                string resultRegex = new Regex(FullExpression).Match(text).ToString();
                resultRegex = resultRegex.Replace(FirstExpression, "");
                resultRegex = resultRegex.Replace(EndExpression, "");
                return resultRegex.ToString();
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Expression not found, Error: {ex.Message}");
            }
        }
    }
}
