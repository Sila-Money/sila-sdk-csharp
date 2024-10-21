using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SilaApiTest
{
    public static class ModelsUtilities
    {
        private static User firstUser;
        private static User secondUser;
        private static User thirdUser;
        private static User fourthUser;
        private static User fifthUser;
        private static BusinessUser businessUser;
        private static User basicUser;
        private static BusinessUser basicBusiness;
        private static User instantUser;
        private static User ckoUser;
        public static User FirstUser
        {
            get
            {
                if (firstUser == null) firstUser = CreateUser(DefaultConfig.FirstUser.UserHandle, "First", "User", DefaultConfig.FirstUser.CryptoAddress);
                return firstUser;
            }
        }
        public static User SecondUser
        {
            get
            {
                if (secondUser == null) secondUser = CreateUser(DefaultConfig.SecondUser.UserHandle, "Second", "User", DefaultConfig.SecondUser.CryptoAddress);
                return secondUser;
            }
        }
        public static User ThirdUser
        {
            get
            {
                if (thirdUser == null) thirdUser = CreateUser(DefaultConfig.ThirdUser.UserHandle, "Fail", "User", DefaultConfig.ThirdUser.CryptoAddress);
                return thirdUser;
            }
        }
        public static User FourthUser
        {
            get
            {
                if (fourthUser == null) fourthUser = CreateUser(DefaultConfig.FourthUser.UserHandle, "Fourth", "User", DefaultConfig.FourthUser.CryptoAddress);
                return fourthUser;
            }
        }
        public static User FifthUser
        {
            get
            {
                if (fifthUser == null) fifthUser = CreateUser(DefaultConfig.FifthUser.UserHandle, "Fif", "User", DefaultConfig.FifthUser.CryptoAddress);
                return fifthUser;
            }
        }
        public static BusinessUser BusinessUser
        {
            get
            {
                if (businessUser == null) businessUser = CreateBusinessUser(DefaultConfig.BusinessUser.UserHandle, "Business User", DefaultConfig.BusinessUser.CryptoAddress, DefaultConfig.BusinessTypes.First(), DefaultConfig.NaicsCategories.First().Value.First());
                return businessUser;
            }
        }
        public static User BasicUser
        {
            get
            {
                if (basicUser == null) basicUser = new User
                {
                    UserHandle = DefaultConfig.BasicUser.UserHandle,
                    FirstName = "Basic",
                    LastName = "Last",
                    CryptoAddress = DefaultConfig.BasicUser.CryptoAddress,
                };
                return basicUser;
            }
        }
        public static BusinessUser BasicBusiness
        {
            get
            {
                if (basicBusiness == null) basicBusiness = new BusinessUser
                {
                    UserHandle = DefaultConfig.BasicBusiness.UserHandle,
                    EntityName = "Basic Business",
                    CryptoAddress = DefaultConfig.BasicBusiness.CryptoAddress,
                    Type = "business",
                    BusinessTypeUuid = DefaultConfig.BusinessTypes.First().Uuid,
                    NaicsCode = DefaultConfig.NaicsCategories.First().Value.First().Code,
                    Phone = "1234567890",
                };
                return basicBusiness;
            }
        }
        public static User InstantUser
        {
            get
            {
                if (instantUser == null) instantUser = new User
                {
                    UserHandle = DefaultConfig.InstantUser.UserHandle,
                    FirstName = "Instant",
                    LastName = "User",
                    EntityName = "Instant User",
                    IdentityValue = "123458888",
                    Phone = "1234567890",
                    Email = System.Guid.NewGuid().ToString() + "instant@email.com",
                    AddressAlias = "default",
                    StreetAddress1 = "1232 Main Street",
                    City = "New City",
                    State = "OR",
                    PostalCode = "97204",
                    CryptoAddress = DefaultConfig.InstantUser.CryptoAddress,
                    CryptoAlias = "default",
                    Birthdate = new DateTime(1994, 1, 8),
                };
                return instantUser;
            }
        }

        public static User CKOUser
        {
            get
            {
                if (ckoUser == null) ckoUser = CreateCKOUser(DefaultConfig.CKOUser.UserHandle, "First", "User", DefaultConfig.CKOUser.CryptoAddress);
                return ckoUser;
            }
        }

        public static User CreateUser(string handle, string firstName, string lastName, string cryptoAddress)
        {
            return new User(handle, firstName, lastName, $"{firstName} {lastName}", "123452222", "1234567890", System.Guid.NewGuid().ToString() + "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", cryptoAddress, new DateTime(1990, 05, 19), addressAlias: "Office", cryptoAlias: "Address 1");
        }

        public static BusinessUser CreateBusinessUser(string handle, string entityName, string cryptoAddress, BusinessType businessType, NaicsSubcategory naicsSubcategory)
        {
            return new BusinessUser(handle, entityName, "123452222", "1234567890", System.Guid.NewGuid().ToString() + "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", cryptoAddress, businessType, "https://www.businesswebsite.com", "test doing business as", naicsSubcategory.Code, addressAlias: "Office", cryptoAlias: "Address 1", type: "business");
        }

        //created new-cko user-  Swati(07-09-2023)
        public static User CreateCKOUser(string handle, string firstName, string lastName, string cryptoAddress)
        {
            return new User(handle, firstName, lastName, $"{firstName} {lastName}", "123452222", "1234567890", System.Guid.NewGuid().ToString() + "@email.com", "123 Main Street",
                "", "New City", "OR", "97204", cryptoAddress, new DateTime(1990, 05, 19), addressAlias: "Office", cryptoAlias: "Address 1");
        }
    }
}
