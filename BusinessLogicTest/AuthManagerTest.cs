using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Concrete;
using DAL.Interfaces;
using DTO;
using Moq;
using NUnit.Framework;

namespace BusinessLogicTest
{
    [TestFixture]
    public class AuthManagerTest
    {
        private Mock<IUsersDal> userDal;
        private AuthManager manager;
        

        [SetUp]
        public void Setup()
        {
            userDal = new Mock<IUsersDal>(MockBehavior.Strict);

            manager = new AuthManager(userDal.Object);
          

        }
        [Test]
        public void LoginUserTest()
        {
            string username = "user";
            string password = "pass";

            userDal.Setup(d => d.Login(username, password)).Returns(true);
            var res = manager.Login(username, password);

            Assert.IsTrue(res);
        }

        //[Test]
        //public void ForgotPassTest()
        //{

        //    Guid salt = new Guid();
        //    string newPassword = "passs";
        //    string keyword = "keyword";
        //    string email = "email";
        //    string firstName = "Maks";
        //    string lastName = "Bahlai";
        //    string phoneNumber = "2232131233";
        //    string gender = "Male";
        //    string password = "pass";

        //    UsersDTO userOut = new UsersDTO
        //    {
                 

        //        Keyword = "keyword",
        //        Password = hash("pass",salt.ToString()),
        //        Email = "email",
        //        FirstName = "Maks",
        //        LastName = "Bahlai",
        //        PhoneNumber = "2232131233",
        //        Gender = "Male"
        //    };
        //    userDal.Setup(d => d.CreateUser(firstName, lastName, email,phoneNumber,password,gender,keyword)).Returns(userOut);


        //    manager.ForgotPass(keyword, newPassword, email);
        //    Assert.AreEqual(userOut.Password, hash(newPassword,userOut.Salt.ToString()));

        //}

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
        
    }

}
