namespace Library.Model
{
    public class Tag
    {
        public string ProductId { get; }
        public string Value { get; }

        public Tag(string productId, string value)
        {
            ProductId = productId;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}