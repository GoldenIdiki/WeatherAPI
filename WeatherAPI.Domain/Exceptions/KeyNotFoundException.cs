namespace WeatherAPI.Domain.Exceptions
{
    public class KeyNotFoundException : ApplicationException
    {
        public KeyNotFoundException(string message) : base(message)
        {

        }
    }
}
