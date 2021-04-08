using SilaAPI.Silamoney.Client.Refactored.Domain;

namespace SilaAPI.Silamoney.Client.Refactored.Endpoints.Entitiesregister
{
    public class RegisterRequest
    {
        public string UserHandle { get; set; }
        public Address Address { get; set; }
        public Identity Identity { get; set; }
        public Contact Contact { get; set; }
        public CryptoEntry CryptoEntry { get; set; }
        public Entity Entity { get; set; }
        public Device Device { get; set; }
    }
}