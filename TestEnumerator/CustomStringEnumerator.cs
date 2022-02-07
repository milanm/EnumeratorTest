using System;
using System.Collections;
using System.Collections.Generic;


namespace TestEnumerator
{
    public class CustomStringEnumerator : IEnumerable<string>
    {
        // string list 
        readonly IEnumerable<string> collection;
        readonly EnumeratorConfig config;

        public CustomStringEnumerator(IEnumerable<string> collection, EnumeratorConfig config)
        {
            if(collection == null)
            {
                throw new ArgumentNullException();
            }

            if (config == null)
            {
                throw new ArgumentNullException();
            }

            this.collection = collection;
            this.config = config;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return GetCollection().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<string> GetCollection()
        {
            foreach (var s in collection)
            {
                if (config.MinLength != -1)
                    if ((string.IsNullOrEmpty(s) && config.MinLength <= 0) || s.Length < config.MinLength)
                        continue;

                if (config.MaxLength != -1)
                    if (!string.IsNullOrEmpty(s) && s.Length > config.MaxLength)
                        continue;

                if (!string.IsNullOrEmpty(s))
                {
                    if (config.StartWithCapitalLetter)
                        if (!char.IsUpper(s, 0))
                            continue;
                    if (config.StartWithDigit)
                        if (!char.IsDigit(s, 0))
                            continue;
                
                } 
                yield return s;
            }
        }
    }

    public class EnumeratorConfig
    {
        // Specifies the minimum length of strings.
        public int MinLength { get; set; } = -1;

        // Specifies the maximum length of strings.
        public int MaxLength { get; set; } = -1;

        // Specifies that only strings that start with a capital letter.
        public bool StartWithCapitalLetter { get; set; }

        // Specifies that only strings that start with a digit.
        public bool StartWithDigit { get; set; }
    }
}
