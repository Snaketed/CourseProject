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
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class UserCardInfoDalTest : ServicedComponent
    {
        IMapper mapper = SetupMapper();

        [Test]
        public void UpdateTest()
        {
            int id = 2;
            UserCardInfoDalEf dal = new UserCardInfoDalEf(mapper);
            var result = dal.GetUserCardInfoById(id);
            result.UserId = 2;
            result.CardNumber = "2222 2222 2222";
            result.ValidMonth = "11";
            result.ValidYear = "22";
            result.CVC = "255";
            dal.UpdateUserCardInfo(result);

            var resultAgain = dal.GetUserCardInfoById(id);

            Assert.AreEqual(resultAgain.Id, id);
            Assert.AreEqual(resultAgain.CVC, "255");


        }

        [Test]
        public void DeleteTest()
        {
            UserCardInfoDalEf dal = new UserCardInfoDalEf(mapper);
            dal.DeleteUserCardInfo(2);
            var user = dal.GetUserCardInfoById(2);
            Assert.IsNull(user);
        }

        [Test]
        public void CreateTest()
        {
            UserCardInfoDalEf dal = new UserCardInfoDalEf(mapper);
            var result = dal.CreateUserCardInfo(new UserCardInfoDTO
            {
                UserId = 2,
                CardNumber = "2222 2222 2222",
                ValidMonth = "11",
                ValidYear = "22",
                CVC = "255",

        });
            Assert.IsTrue(result.Id != 0, "returned ID should be more than zero");

        }



        [Test]
        public void GetAllTest()
        {

            UserCardInfoDalEf dal = new UserCardInfoDalEf(mapper);
            var users = dal.GetAllUserCardInfo();
            Assert.AreEqual(1, users.Count(x => x.CVC == "666"));

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
                cfg => cfg.AddMaps(typeof(UserCardInfoDalEf).Assembly)
            );

            return conf.CreateMapper();
        }
    }
}
