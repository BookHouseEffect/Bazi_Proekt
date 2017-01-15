using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bazi_Repository;
using Bazi_Repository.Implementation;
using Bazi_Repository.RepositoryRequests;
using System.Collections.Generic;
using Db201617zVaProektRnabContext;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class RepositoryTest
    {

        [TestMethod]
        public void RoleTesting()
        {
            RoleManager roleManager = new RoleManager();
            RepoBaseResponse<ICollection<Ulogi>> response = roleManager.GetRoleList();

            Assert.AreEqual(HttpStatusCode.OK, response.Status);
            Assert.IsNotNull(response.ReturnedResult);

            Ulogi prva = ((List<Ulogi>)response.ReturnedResult).ToArray()[0];
            Assert.AreEqual(prva, (roleManager.GetRoleById(new RepoGetRoleByIdRequest { RoleId = prva.UlogaId })).ReturnedResult);
            Assert.AreEqual(prva, (roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = prva.UlogaIme })).ReturnedResult);
        }

        [TestMethod]
        public void AccountTest()
        {
            AccountManager acm = new AccountManager();

            RepoBaseResponse<Akaunti> response = acm.GetAccountById(new RepoGetAccountByIdRequest { Id = 1 });
            Assert.AreEqual(HttpStatusCode.OK, response.Status);

            RepoBaseResponse<Akaunti> response2 = 
                acm.ChangePassword(new RepoChangePasswordRequest { Id = 1, PasswordHash = "0", SecurityStamp = "0" });
            Assert.AreEqual(HttpStatusCode.OK, response2.Status);
            Assert.AreEqual("0", response.ReturnedResult.BezbednostnaMarka);
            Assert.AreEqual("0", response.ReturnedResult.LozinkaHash);
        }
    }
}
