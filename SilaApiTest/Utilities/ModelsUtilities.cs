using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilaApiTest
{
    public class ModelsUtilities
    {
        public static Header createHeader()
        {
            Header header = new Header("user.silamoney.eth");
            header.created = 1234567890;
            return header;
        }

        public static HeaderMsg createHeaderMessage()
        {
            return new HeaderMsg("user.silamoney.eth", DefaultConfig.appHandle);
        }

        public static Address createAddress()
        {
            return new Address(createUser());
        }

        public static Identity createIdentity()
        {
            return new Identity(createUser());
        }

        public static Contact createContact()
        {
            return new Contact(createUser());
        }

        public static CryptoEntry createCryptoEntry()
        {
            return new CryptoEntry(createUser());
        }

        public static Entity createEntity()
        {
            return new Entity(createUser());
        }

        public static EntityMsg createEntityMessage()
        {
            return new EntityMsg(createUser(), DefaultConfig.appHandle);
        }

        public static GetAccountsMsg createGetAccountsMessage()
        {
            return new GetAccountsMsg("user.silamoney.eth", DefaultConfig.appHandle);
        }

        public static IssueMsg createIssueMessage()
        {
            return new IssueMsg("user.silamoney.eth", 1000, DefaultConfig.appHandle, "default");
        }

        public static LinkAccountMsg createLinkAccountMessage()
        {
            return new LinkAccountMsg("public-xxx-xxx", "Custom Account Name", DefaultConfig.appHandle, "default");
        }

        public static TransferMsg createTransferMessage()
        {
            return new TransferMsg("user.silamoney.eth", 13, "user2.silamoney.eth", DefaultConfig.appHandle);
        }

        public static RedeemMsg createRedeemMessage()
        {
            return new RedeemMsg("user.silamoney.eth", 1000, DefaultConfig.appHandle, "default");
        }

        public static SearchFilters createSearchFilters()
        {
            return new SearchFilters("transaction Id", "reference Id",
                new SearchFilters.StatusesEnum[(int)SearchFilters.StatusesEnum.Complete],
                new SearchFilters.TransactionTypesEnum[(int)SearchFilters.TransactionTypesEnum.Issue], 0, 0, 0, 0, 0, 0,
                true, true);
        }

        public static GetTransactionsMsg createGetTransationsMessage()
        {
            return new GetTransactionsMsg(createHeader(), createSearchFilters());
        }

        public static User createUser()
        {
            return new User("user.silamoney.eth", "Example", "User", "Example User", "123452222", "1234567890", "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", "0x65a796a4bD3AaF6370791BefFb1A86EAcfdBc3C1", new DateTime(1990, 05, 19));
        }
    }
}
