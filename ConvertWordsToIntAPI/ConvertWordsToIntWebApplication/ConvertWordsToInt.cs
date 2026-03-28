namespace ConvertWordsToIntWebApplication
{
    public class ConvertWordsToInt
    {
        public static int ConvertWordsToIntMethod(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var numberTable = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) 
            {
                {"zero",0}, 
                {"one",1}, 
                {"two",2}, 
                {"three",3}, 
                {"four",4}, 
                {"five",5}, 
                {"six",6},
                {"seven",7}, 
                {"eight",8}, 
                {"nine",9}, 
                {"ten",10}, 
                {"eleven",11}, 
                {"twelve",12},
                {"thirteen",13}, 
                {"fourteen",14}, 
                {"fifteen",15}, 
                {"sixteen",16}, 
                {"seventeen",17},
                {"eighteen",18}, 
                {"nineteen",19}, 
                {"twenty",20}, 
                {"thirty",30}, 
                {"forty",40},
                {"fifty",50}, 
                {"sixty",60}, 
                {"seventy",70}, 
                {"eighty",80}, 
                {"ninety",90}
            };

            var modifiers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) 
            {
                {"hundred", 100}, 
                {"thousand", 1000}, 
                {"million", 1000000}
            };

            int total = 0;
            int currentRangeValue = 0;

            var words = input.ToLower().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (numberTable.ContainsKey(word))
                {
                    currentRangeValue += numberTable[word];
                }
                else if (modifiers.ContainsKey(word))
                {
                    int modifier = modifiers[word];
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
            }
            return total + currentRangeValue;
        }
    }
}
