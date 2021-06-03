namespace Common
{
    public class Country
    {
        public string Name { get; set; }
        public bool IsTelenorSupported { get; set; }

        public Country(string name, bool isSupported)
        {
            Name = name;
            IsTelenorSupported = isSupported;
        }
    }
}
