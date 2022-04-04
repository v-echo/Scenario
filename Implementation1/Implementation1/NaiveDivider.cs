using SharedLibrary;

namespace Implementation1
{
    // Included for reference. Not actually used.
    public class NaiveDivider : IDivider
    {
        string FirstName { get; }
        string LastName { get; }

        public NaiveDivider(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string Divide(int value)
        {
            if (value % 3 == 0 && value % 5 == 0)
                return $"{FirstName} {LastName}";

            if (value % 3 == 0)
                return FirstName;

            if (value % 5 == 0)
                return LastName;

            return value.ToString();
        }
    }
}
