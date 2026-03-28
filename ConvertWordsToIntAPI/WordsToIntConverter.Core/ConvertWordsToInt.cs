namespace WordsToIntConverter.Core
{
    public class ConvertWordsToInt : IConvertWordsToInt
    {
        private static readonly Dictionary<string, int> NumberTable = new(StringComparer.OrdinalIgnoreCase)
        {
            {"zero",0}, {"one",1}, {"two",2}, {"three",3}, {"four",4}, {"five",5},
            {"six",6}, {"seven",7}, {"eight",8}, {"nine",9}, {"ten",10},
            {"eleven",11}, {"twelve",12}, {"thirteen",13}, {"fourteen",14},
            {"fifteen",15}, {"sixteen",16}, {"seventeen",17}, {"eighteen",18},
            {"nineteen",19}, {"twenty",20}, {"thirty",30}, {"forty",40},
            {"fifty",50}, {"sixty",60}, {"seventy",70}, {"eighty",80}, {"ninety",90}
        };

        private static readonly Dictionary<string, int> Modifiers = new(StringComparer.OrdinalIgnoreCase)
        {
            {"hundred", 100}, {"thousand", 1000}, {"million", 1000000}
        };

        public int ConvertWordsToIntMethod(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            try
            {
                var words = input.Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                long total = 0;
                long currentRangeValue = 0;

                foreach (var word in words)
                {
                    if (word.Equals("and", StringComparison.OrdinalIgnoreCase)) continue;

                    if (NumberTable.TryGetValue(word, out int number))
                    {
                        currentRangeValue += number;
                    }
                    else if (Modifiers.TryGetValue(word, out int modifier))
                    {
                        if (currentRangeValue == 0 && modifier >= 100)
                        {
                            currentRangeValue = 1;
                        }

                        if (modifier == 100)
                        {
                            currentRangeValue *= modifier;
                        }
                        else
                        {
                            total += currentRangeValue * modifier;
                            currentRangeValue = 0;
                        }
                    }
                    else
                    {
                        // Error: Word is not a number, a modifier, or "and"
                        throw new FormatException($"The word '{word}' is not a recognized number or modifier.");
                    }
                }

                long finalResult = total + currentRangeValue;

                // Error: Result exceeds the capacity of an integer
                if (finalResult > int.MaxValue || finalResult < int.MinValue)
                    throw new OverflowException("The converted value is too large for a 32-bit integer.");

                return (int)finalResult;
            }
            catch (Exception)
            {

                throw new Exception("Unexpected Error Occured, please try again!");
            }            
        }
    }
}
