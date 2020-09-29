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
    public class UserAddressDalTest : ServicedComponent
    {
        IMapper mapper = SetupMapper();

            [Test]
            public void UpdateTest()
            {
                int id = 4;
                UserAddressDalEf dal = new UserAddressDalEf(mapper);
                var result = dal.GetUserAddressById(id);
                result.Country = 2;
                result.City = 1;
                result.UserId = 2;
                result.PostalCode = 241242;

                dal.UpdateUserAddress(result);

                var resultAgain = dal.GetUserAddressById(id);

                Assert.AreEqual(resultAgain.Id, id);
                Assert.AreEqual(resultAgain.City, 1);


            }

            [Test]
            public void DeleteTest()
            {
                UserAddressDalEf dal = new UserAddressDalEf(mapper);
                dal.DeleteUserAddress(4);
                var user = dal.GetUserAddressById(4);
                Assert.IsNull(user);
            }

            [Test]
            public void CreateTest()
            {
                UserAddressDalEf dal = new UserAddressDalEf(mapper);
                var result = dal.CreateUserAddress(new UserAddressDTO
                {
                   UserId = 2,
                   Country = 2,
                   City = 2,
                   PostalCode = 241242,

                });
                Assert.IsTrue(result.Id != 0, "returned ID should be more than zero");

            }



            [Test]
            public void GetAllTest()
            {

                UserAddressDalEf dal = new UserAddressDalEf(mapper);
                var users = dal.GetAllUserAddress();
                Assert.AreEqual(3, users.Count(x => x.Country == 2));

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
                    cfg => cfg.AddMaps(typeof(UserAddressDalEf).Assembly)
                );

                return conf.CreateMapper();
            }
        }
}
