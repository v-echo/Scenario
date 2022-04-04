namespace Implementation2.Web.Data
{
    public class GeneratorData
    {
        public int Number { get; set; }
        public string Result { get; set; }

        public GeneratorData(int number, string result)
        {
            Number = number;
            Result = result;
        }
    }
}
