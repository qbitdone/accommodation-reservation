namespace Staycation.Api.Exceptions
{
    public class ReservationNotPossibleException:Exception
    {
        public int AccommodationId { get; set; }
        public ReservationNotPossibleException()
        {

        }

        public ReservationNotPossibleException(string message) : base(message)
        {

        }

        public ReservationNotPossibleException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public ReservationNotPossibleException(string message, int accommodationId): this(message)
        {
            AccommodationId = accommodationId;
        }
    }
}
