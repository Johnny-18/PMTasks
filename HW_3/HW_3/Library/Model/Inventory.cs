namespace Library.Model
{
    public class Inventory
    {
        public string ProductId { get; }
        public string Location { get; }
        public int Balance { get; }

        public Inventory(string productId, string location, int balance)
        {
            ProductId = productId;
            Location = location;
            Balance = balance;
        }

        public override string ToString()
        {
            return Location + " " + Balance;
        }
    }
}