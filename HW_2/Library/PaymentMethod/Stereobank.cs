using Library.AbstractClasses;

namespace Library.PaymentMethod
{
    public class Stereobank : Bank
    {
        public Stereobank()
        {
            Name = "Stereobank";
            AvailableCards = new string[]{"Black", "White", "Iron"};
        }
    }
}