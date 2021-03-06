﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;
using DTO;

namespace DalEf.Concrete
{
    public class CityDalEf : ICityDal
    {
        private readonly IMapper _mapper;
        public CityDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<CityDTO> GetAllCity()
        {
            using (var e = new CompanyEntities())
            {
                return _mapper.Map<List<CityDTO>>(e.Cities.ToList());
            }
        }

        public CityDTO GetCityById(long id)
        {
            using (var entities = new CompanyEntities())
            {
                var m = entities.Cities.SingleOrDefault(mm => mm.CityId == id);

                return _mapper.Map<CityDTO>(m);
            }
        }


    }
}
