using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;
using DTO;

namespace DalEf.Concrete
{
    public class UserAddressDalEf : IUserAddressDal
    {

        private readonly IMapper _mapper;
        public UserAddressDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserAddressDTO GetUserAddressById(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.UserAddresses.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<UserAddressDTO>(m);
            }
        }

       
        public List<UserAddressDTO> GetAllUserAddress()
        {
            using (var e = new CompanyEntities())
            {
                return _mapper.Map<List<UserAddressDTO>>(e.UserAddresses.ToList());

            }
        }

        public void UpdateUserAddress(UserAddressDTO user)
        {
            using (var entity = new CompanyEntities())
            {

                UserAddress m = _mapper.Map<UserAddress>(user);
                entity.UserAddresses.AddOrUpdate(m);
                entity.SaveChanges();
            }
        }

        public UserAddressDTO CreateUserAddress(UserAddressDTO user)
        {
            using (var entities = new CompanyEntities())
            {
                UserAddress m = _mapper.Map<UserAddress>(user);
                entities.UserAddresses.Add(m);
                entities.SaveChanges();

                return _mapper.Map<UserAddressDTO>(m);
            }
        }

        public void DeleteUserAddress(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.UserAddresses.SingleOrDefault(mm => mm.Id == id);

                if (m == null)
                {
                    return;
                }

                entities.UserAddresses.Remove(m);
                entities.SaveChanges();
            }
        }
    }
}
