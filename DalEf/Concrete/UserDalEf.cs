using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity.Migrations;

namespace DalEf.Concrete
{
    public  class UserDalEf : IUsersDal
    {
        private readonly IMapper _mapper;
        public UserDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }


        public UsersDTO GetUserById(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.Users.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<UsersDTO>(m);
            }
        }

        public List<UsersDTO> GetAllUsers()
        {
            using (var e = new CompanyEntities())
            {
                return _mapper.Map<List<UsersDTO>>(e.Users.ToList());

            }
        }

        public void UpdateUser(UsersDTO user)
        {
            using (var entity = new CompanyEntities())
            {
                
                User m = _mapper.Map<User>(user);
                entity.Users.AddOrUpdate(m);
                entity.SaveChanges();
            }
        }

        public UsersDTO CreateUser(UsersDTO user)
        {
            using (var entities = new CompanyEntities())
            {
                User m = _mapper.Map<User>(user);
                entities.Users.Add(m);
                entities.SaveChanges();

                return _mapper.Map<UsersDTO>(m);
            }
        }

        public void DeleteUser(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.Users.SingleOrDefault(mm => mm.Id == id);

                if (m == null)
                {
                    return;
                }
                
                entities.Users.Remove(m);
                entities.SaveChanges();
            }
        }
    }
}
