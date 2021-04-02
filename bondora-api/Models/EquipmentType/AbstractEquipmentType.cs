namespace bondora_api.Models.EquipmentType
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

        public static bool operator ==(AbstractEquipmentType laet, AbstractEquipmentType raet)
        {
            return laet.Equals(raet);
        }

        public static bool operator !=(AbstractEquipmentType laet, AbstractEquipmentType raet)
        {
            return !laet.Equals(raet);
        }

        public override bool Equals(object obj)
        {
            AbstractEquipmentType aet = obj as AbstractEquipmentType;

            if (OneTimeFee != aet.OneTimeFee)
                return false;

            if (PremiumFee != aet.PremiumFee)
                return false;

            if (RegularFee != aet.RegularFee)
                return false;

            if (LoyaltyPoints != aet.LoyaltyPoints)
                return false;

            return true;
        }
    }
}
