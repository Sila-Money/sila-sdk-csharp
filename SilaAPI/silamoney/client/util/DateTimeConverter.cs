using Newtonsoft.Json.Converters;

namespace SilaAPI.silamoney.client.util
{
    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
