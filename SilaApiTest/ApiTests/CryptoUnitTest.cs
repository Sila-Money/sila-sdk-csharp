using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.com.silamoney.client.security;

namespace SilaApiTest
{
    [TestClass]
    public class CryptoUnitTest
    {
        [TestMethod]
        public void TestHashAndSignExample1()
        {
            string privateKey = "badba7368134dcd61c60f9b56979c09196d03f5891a20c1557b1afac0202a97c";
            string message = "Sila";
            string signature = Signer.sign(message,privateKey);
            string expected = "ea3706a8d2b4c627f847c0c6bfcd59f001021d790f06924ff395e9faecb510c53c09274b70cc1d29bde630d277096d570ee7983455344915d19085cc13288b421b";
            Assert.AreEqual(expected, signature);
        }
        [TestMethod]
        public void TestHashAndSignExample2()
        {
            string privateKey = "badba7368134dcd61c60f9b56979c09196d03f5891a20c1557b1afac0202a97c";
            string message = "test";
            string signature = Signer.sign(message, privateKey);
            string expected = "f9978f3af681d3de06b3bcf5acf2181b5ebf54e0110f1d9d773d691ca2b42bdc39bf478d9ea8287bd15369fa3fd25c09b8c3c02bdbafd19f2aad043e350a037c1b";
            Assert.AreEqual(expected, signature);
        }
        [TestMethod]
        public void TestHashAndSignExample3()
        {
            string privateKey = "badba7368134dcd61c60f9b56979c09196d03f5891a20c1557b1afac0202a97c";
            string message = "{\"test\":\"message\"}";
            string signature = Signer.sign(message, privateKey);
            string expected = "835e9235dcdc03ed8928df5ace375bc70ea6f41699cd861b8801c9c617b4f2b658ff8e2cda47ea84401cab8019e5bb9daf3c0af2e7d2ab96cba6966a75e017171b";
            Assert.AreEqual(expected, signature);
        }
        [TestMethod]
        public void TestHashAndSignExample4()
        {
            string privateKey = "badba7368134dcd61c60f9b56979c09196d03f5891a20c1557b1afac0202a97c";
            string message = "{\"test\": \"message\"}";
            string signature = Signer.sign(message, privateKey);
            string expected = "2de2f5d3f778e485f234956679373b9730b717c33e628651c3371e7eb31c4a27738af1a3bf85472a2a7dfc0628ddd21f8611ff0e170ebd24003c2a34b2760d5c1c";
            Assert.AreEqual(expected, signature);
        }
    }
}
