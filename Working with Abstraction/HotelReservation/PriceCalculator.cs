namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay, int days, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal totalPrice = pricePerDay * days * multiplier * (1 - discountMultiplier);

            return totalPrice;
        }
    }
}
