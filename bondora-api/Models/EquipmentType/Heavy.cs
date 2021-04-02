namespace bondora_api.Models.EquipmentType
{
    public class Heavy : AbstractEquipmentType
    {
        public override byte LoyaltyPoints { get; } = 1;

        public override float CalculatePrice(int daysRented)
        {
            if (daysRented < 1) return 0;

            return OneTimeFee + (daysRented * PremiumFee);
        }
    }
}
