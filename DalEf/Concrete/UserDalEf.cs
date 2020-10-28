using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;

namespace DalEf.Concrete
{
    public  class UserDalEf : IUsersDal
    {

        public bool Login(string username, string password)
        {
            using (var ent = new CompanyEntities())
            {
                User user = ent.Users.SingleOrDefault(u => u.Email == username);
                return user != null && user.Password.SequenceEqual(hash(password, user.Salt.ToString()));
            }
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
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

        public long GetId(string email)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.Users.SingleOrDefault(mm => mm.Email == email);

                return m.Id;
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

        public void ForgotPass(string keyword, string password, string email)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.Users.SingleOrDefault(mm => mm.Email == email);

                if (m.Keyword != keyword)
                {
                    throw new Exception("Incorrect keyword or email");
                }
                m.Password = hash(password, m.Salt.ToString());

                entities.Users.AddOrUpdate(m);
                entities.SaveChanges();

            }

        }
        //public UsersDTO CreateUser(UsersDTO user)
        //{
        //    using (var entities = new CompanyEntities())
        //    {
        //        User m = _mapper.Map<User>(user);
        //        entities.Users.Add(m);
        //        entities.SaveChanges();

        //        return _mapper.Map<UsersDTO>(m);
        //    }
        //}

        public UsersDTO CreateUser(string firstName,string lastName, string email,string phoneNumber, string password, string gender, string keyword)
        {
            using (var entities = new CompanyEntities())
            {
                if (entities.Users.Any(u => u.Email == email))
                {
                    throw new Exception("User already exists!");
                }

                Guid salt = Guid.NewGuid();
                var user = new User
                {
                    FirstName = firstName,
                    LastName=lastName,
                    Email = email,
                    Password = hash(password, salt.ToString()),
                    Salt = salt,
                    PhoneNumber = phoneNumber,
                    Gender = gender,
                    Keyword = keyword,
                    RowInsertTime = DateTime.UtcNow,
                   
                };

                entities.Users.Add(user);
                entities.SaveChanges();

                return _mapper.Map<UsersDTO>(user);
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
