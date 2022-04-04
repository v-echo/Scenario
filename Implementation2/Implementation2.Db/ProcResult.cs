namespace Implementation2.Db
{
    public class ProcResult
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public ProcResult(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}
