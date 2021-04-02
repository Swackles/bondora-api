namespace bondora_api.Models.EquipmentType
{
    public class Regular : AbstractEquipmentType
    {
        public override byte LoyaltyPoints { get; } = 1;

        public override float CalculatePrice(int daysRented)
        {
            if (daysRented < 1) return 0;

            float price = OneTimeFee;

            price += daysRented * PremiumFee;

            if (daysRented > 2)
                price += (daysRented - 2) * RegularFee;

            return price;
        }
    }
}
