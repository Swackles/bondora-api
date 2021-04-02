namespace bondora_api.Models
{
    public abstract class AbstractEquipmentType
    {
        public float OneTimeFee { get; } = 100;
        public float PremiumFee { get; } = 60;
        public float RegularFee { get; } = 40;
        public abstract byte LoyaltyPoints { get; }

        /// <summary>
        /// Calculates the price for the equipment
        /// </summary>
        /// <param name="daysRented">how many days the item will be rented for</param>
        /// <returns>Returns the price of the rental</returns>
        public abstract float CalculatePrice(int daysRented);
    }
}
