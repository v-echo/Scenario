using SharedLibrary;

namespace Implementation1
{
    /// <summary>
    /// Contains the division logic, but separates the inputs. Also abstracts the functionality behind an interface for DI and testability.
    /// </summary>
    public class GeneralDivider : IDivider
    {
        IReadOnlyDictionary<int, string> Dividers { get; }

        public GeneralDivider(IReadOnlyDictionary<int, string> dividers)
        {
            if (dividers is null)
                throw new ArgumentNullException(nameof(dividers));

            Dividers = dividers;
        }

        public string Divide(int value)
        {
            foreach (var divider in Dividers.Keys)
                if (value % divider == 0)
                    return Dividers[divider];

            return value.ToString();
        }
    }
}
