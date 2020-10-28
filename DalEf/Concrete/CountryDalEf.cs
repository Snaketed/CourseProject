using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;
using DTO;

namespace DalEf.Concrete
{
    public class CountryDalEf : ICountryDal
    {
        private readonly IMapper _mapper;
        public CountryDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<CountryDTO> GetAllCountry()
        {
            using (var e = new CompanyEntities())
            {
                return _mapper.Map<List<CountryDTO>>(e.Countries.ToList());

            }
        }

        public CountryDTO GetCountryById(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.Countries.SingleOrDefault(mm => mm.CountryId == id);

                return _mapper.Map<CountryDTO>(m);
            }
        }
    }
}
