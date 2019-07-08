namespace Ldc
{
    using System.Text.RegularExpressions;

    public class Transform : ITransform
    {
        public string Cleanup(string input)
        {
            // Note: Sequencing is important, as removal of underscores and 4s can create additional duplications
            // hence duplicates removal should be the last rule to run
            var dollarSignsInsteadOfPounds = ReplaceDollarWithPound(input);

            var noUnderscoresAnd4 = RemoveUnderscoresAnd4(dollarSignsInsteadOfPounds);

            return RemoveDuplicates(noUnderscoresAnd4);
        }

        private string RemoveDuplicates(string input)
        {
            return Regex.Replace(input, @"(.)\1+", "$1");
        }

        private string ReplaceDollarWithPound(string input)
        {
            return input.Replace('$', '£');
        }

        private string RemoveUnderscoresAnd4(string input)
        {
            return input.Replace("_", string.Empty).Replace("4", string.Empty);
        }
    }
}
