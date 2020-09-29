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
    public class UserCardInfoDalEf : IUserCardInfoDal
    {

        private readonly IMapper _mapper;
        public UserCardInfoDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserCardInfoDTO GetUserCardInfoById(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.UserCardInfoes.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<UserCardInfoDTO>(m);
            }
        }

        public List<UserCardInfoDTO> GetAllUserCardInfo()
        {
            using (var e = new CompanyEntities())
            {
                return _mapper.Map<List<UserCardInfoDTO>>(e.UserCardInfoes.ToList());

            }
        }

        public void UpdateUserCardInfo(UserCardInfoDTO user)
        {
            using (var entity = new CompanyEntities())
            {

                UserCardInfo m = _mapper.Map<UserCardInfo>(user);
                entity.UserCardInfoes.AddOrUpdate(m);
                entity.SaveChanges();
            }
        }

        public UserCardInfoDTO CreateUserCardInfo(UserCardInfoDTO user)
        {

            using (var entities = new CompanyEntities())
            {
                UserCardInfo m = _mapper.Map<UserCardInfo>(user);
                entities.UserCardInfoes.Add(m);
                entities.SaveChanges();

                return _mapper.Map<UserCardInfoDTO>(m);
            }
        }

        public void DeleteUserCardInfo(long id)
        {
             using (var entities = new CompanyEntities())
             {
                 var m = entities.UserCardInfoes.SingleOrDefault(mm => mm.Id == id);

                 if (m == null)
                 {
                     return;
                 }
                
                 entities.UserCardInfoes.Remove(m);
                 entities.SaveChanges();
             }
        }
    }
}
