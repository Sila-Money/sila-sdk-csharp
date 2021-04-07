using SilaAPI.silamoney.client.refactored.domain;

namespace SilaAPI.silamoney.client.refactored.endpoints.entities.register
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