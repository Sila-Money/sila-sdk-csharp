using Newtonsoft.Json.Converters;

namespace SilaAPI.com.silamoney.client.util
{
    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
