using System;
using System.Collections;
using System.Collections.Generic;


namespace TestEnumerator
{
    public class CustomStringEnumerator : IEnumerable<string>
    {
        private readonly IEnumerable<string> _collection;
        private readonly EnumeratorConfig _config;

        public CustomStringEnumerator(IEnumerable<string> collection, EnumeratorConfig config)
        {
            _collection = collection ?? throw new ArgumentNullException();
            _config = config ?? throw new ArgumentNullException();
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
            foreach (var stringValue in _collection)
            {
                if (_config.MinLength != -1)
                {
                    if (string.IsNullOrEmpty(stringValue) || stringValue!.Length < _config.MinLength)
                        continue;
                }

                if (!string.IsNullOrEmpty(stringValue))
                {
                    if (_config.StartWithCapitalLetter)
                    {
                        if (!char.IsUpper(stringValue, 0))
                            continue;
                    }
                    else
                    {
                        if (char.IsUpper(stringValue, 0))
                            continue;
                    }

                    if (_config.StartWithDigit)
                    {
                        if (!char.IsDigit(stringValue, 0))
                            continue;
                    }
                    else
                    {
                        if (char.IsDigit(stringValue, 0))
                            continue;
                    }

                    if (_config.MaxLength != -1)
                    {
                        if (stringValue.Length > _config.MaxLength)
                            continue;
                    }

                } 
                yield return stringValue;
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
