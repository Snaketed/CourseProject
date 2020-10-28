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
    public class RegistManagerTest
    {
        private Mock<IUsersDal> userDal;
        private RegistManager manager;


        [SetUp]
        public void Setup()
        {
            userDal = new Mock<IUsersDal>(MockBehavior.Strict);

            manager = new RegistManager(userDal.Object);
        }
        [Test]
        public void ForgotPassTest()
        {

            
            string keyword = "keyword";
            string email = "email";
            string firstName = "Maks";
            string lastName = "Bahlai";
            string phoneNumber = "2232131233";
            string gender = "Male";
            string password = "pass";

            UsersDTO userOut = new UsersDTO
            {
                Id = 1
            };
            userDal.Setup(d => d.CreateUser(firstName, lastName, email, phoneNumber, password, gender, keyword)).Returns(userOut);


            var res = manager.CreateUser(firstName, lastName, email, phoneNumber, password, gender, keyword);
            Assert.IsNotNull(res);
            Assert.AreEqual(userOut.Id, res.Id);
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
