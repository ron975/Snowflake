using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Romfile.Tokenizer;

namespace Snowflake.Romfile.Naming
{
    public sealed class StructuredFilename : IStructuredFilename
    {
        /// <inheritdoc/>
        public NamingConvention NamingConvention { get; private set; }

        /// <inheritdoc/>
        public string RegionCode { get; }

        /// <inheritdoc/>
        public string Title { get; }

        /// <inheritdoc/>
        public string Year { get; }

        /// <inheritdoc/>
        public string OriginalFilename { get; }

        public StructuredFilename(string originalFilename)
        {
            OriginalFilename = Path.GetFileName(originalFilename);

            // todo: expose tokens to api
            (NamingConvention namingConvention, IEnumerable<StructuredFilenameToken> tokens) = GetBestMatch();
            Title = ParseTitle(tokens.FirstOrDefault(t => t.Type == FieldType.Title)?.Value ?? "Unknown??!?");
            NamingConvention = namingConvention;
            RegionCode = string.Join('-', tokens.Where(t => t.Type == FieldType.Country).Select(t => t.Value));
            if (string.IsNullOrEmpty(RegionCode))
            {
                RegionCode = "ZZ";
            }

            Year = tokens.FirstOrDefault(t => t.Type == FieldType.Date)?.Value.Split("-")[0] ?? "XXXX";
        }

        private (NamingConvention namingConvention, IEnumerable<StructuredFilenameToken> tokens) GetBestMatch()
        {
            var tokens = new StructuredFilenameTokenizer(OriginalFilename);
            var brackets = tokens.GetBracketTokens().ToList();
            var parens = tokens.GetParensTokens().ToList();
            var title = tokens.GetTitle();

            var goodTools = new GoodToolsTokenClassifier();
            var goodToolsTokens = goodTools.ClassifyBracketsTokens(brackets)
                .Concat(goodTools.ClassifyParensTokens(parens))
                .Concat(goodTools.ExtractTitleTokens(title)).ToList();

            var noIntro = new NoIntroTokenClassifier();
            var noIntroTokens = noIntro.ClassifyBracketsTokens(brackets)
                .Concat(noIntro.ClassifyParensTokens(parens))
                .Concat(noIntro.ExtractTitleTokens(title)).ToList();

            var tosec = new TosecTokenClassifier();
            var tosecTokens = tosec.ClassifyBracketsTokens(brackets)
                .Concat(tosec.ClassifyParensTokens(parens))
                .Concat(tosec.ExtractTitleTokens(title)).ToList();

            var aggregate = new List<(IEnumerable<StructuredFilenameToken> tokens, int uniqueDatatypes)>()
            {
                {(goodToolsTokens, GetUniqueDatatypeCount(goodToolsTokens))},
                {(noIntroTokens, GetUniqueDatatypeCount(noIntroTokens))},
                {(tosecTokens, GetUniqueDatatypeCount(tosecTokens))},
            };

            var bestMatch = aggregate.OrderByDescending(p => p.uniqueDatatypes).First().tokens;
            return (bestMatch.First().NamingConvention, bestMatch);
        }

        private static int GetUniqueDatatypeCount(IEnumerable<StructuredFilenameToken> tokens)
        {
            return tokens.Select(t => t.Type).Distinct().Count();
        }

        private static string ParseTitle(string rawTitle)
        {
            return rawTitle.WithoutLastArticle("The")
                .WithoutLastArticle("A")
                .WithoutLastArticle("Die")
                .WithoutLastArticle("De")
                .WithoutLastArticle("La")
                .WithoutLastArticle("Le")
                .WithoutLastArticle("Les")
                .ToTitleCase();
        }
    }
}
