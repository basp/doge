namespace Doge.Web
{
    using System;
    using System.Linq;

    public class QueryParser
    {
        public SearchQuery Parse(string input)
        {
            var tokens = Tokenize(input);
            var predicates = tokens.Select(x => ParsePredicate(x));
            return new SearchQuery
            {
                Predicates = predicates.ToArray()
            };
        }

        private static SearchPredicate ParsePredicate(string s)
        {
            var chunks = s.Split(new[] { ':' });
            var path = string.Concat("/", chunks[0].Replace('.', '/'));
            return new SearchPredicate
            {
                Neg = false,
                XExp = string.Format(
                    "[data].exist({0}/text()[contains(., ''{1}'')]", 
                    path, 
                    chunks[1])
            };
        }

        private static string[] Tokenize(string input)
        {
            return input.Split(' ')
                .Select(x => x.Trim())
                .ToArray();
        }
    }
}