using System.ComponentModel.DataAnnotations;

namespace SharedLibrary
{
    public class CalculatorInput
    {
        public CalculatorInput(string first, string last, int start = 1, int end = 100, int minDelaySeconds = 20, int maxDelaySeconds = 60)
        {
            First = first;
            Last = last;
            Start = start;
            End = end;
            MinDelaySeconds = minDelaySeconds;
            MaxDelaySeconds = maxDelaySeconds;
        }

        [Required]
        [MinLength(1)]
        public string First { get; set; }

        [Required]
        [MinLength(1)]
        public string Last { get; set; }

        [Range(0, 49999)]
        public int Start { get; set; }

        [Range(1, 50000)]
        public int End { get; set; }

        [Range(0, 59)]
        public int MinDelaySeconds { get; set; }

        [Range(1, 60)]
        public int MaxDelaySeconds { get; set; }
    }
}
