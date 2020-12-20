namespace Library.Interfaces
{
    public interface ISupportDeposit
    {
        void StartDeposit(decimal amount, string currency);
    }
}