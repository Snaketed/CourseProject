using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DalEf.Concrete;
using NUnit.Framework;
using System.Runtime.InteropServices;
using DTO;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew),ComVisible(true)]
    public class UserDalTests : ServicedComponent
    {
        IMapper mapper = SetupMapper();

        [Test]
        public void UpdateTest()
        {
            int id = 2;
            UserDalEf dal = new UserDalEf(mapper);
            var result = dal.GetUserById(id);
            result.FirstName = "Maks Test2";
            result.LastName = "Bahlai";
            result.Email = "maks44753@gmail.com";
            result.PhoneNumber = "380680025266";
            result.Gender = "Male";
            result.Password = Encoding.ASCII.GetBytes("dasdfas");
            result.RowInsertTime = DateTime.UtcNow;
            dal.UpdateUser(result);

            var resultAgain = dal.GetUserById(id);

            Assert.AreEqual(resultAgain.Id, id);
            Assert.AreEqual(resultAgain.FirstName, "Maks Test2");


        }

        [Test]
        public void DeleteTest()
        {
            UserDalEf dal = new UserDalEf(mapper);
            dal.DeleteUser(15);
            var user = dal.GetUserById(15);
            Assert.IsNull(user);
        }



        [Test]
        public void GetAllTest()
        {
               
            UserDalEf dal = new UserDalEf(mapper);
            var users = dal.GetAllUsers();
            Assert.AreEqual(1, users.Count(x => x.FirstName == "Maksym"));

        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(UserDalEf).Assembly)
            );

            return conf.CreateMapper();
        }
    }
}
