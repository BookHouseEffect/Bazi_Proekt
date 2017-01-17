using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bazi_Business;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PasswordCryptography pcr = new PasswordCryptography();
            HashedAndSaltedPassword pass =  pcr.CryptPassword("test1234");

            Console.WriteLine(pass.PasswordHash);
            Console.WriteLine(pass.PasswordSalt);
        }
    }
}
