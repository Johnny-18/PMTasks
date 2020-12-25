using Library.Enum;

namespace Library.Interfaces
{
    public interface IPlayer
    {
        int Age { get; }
        string FirstName { get; }
        string LastName { get; }
        PlayerRank Rank { get; }
    }
}