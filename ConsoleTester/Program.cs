using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleTester.Menu;
using DalEf.Concrete;
using DTO;


namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IMapper mapper = SetupMapper();

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("type 'u' to open User menu");
                Console.WriteLine("type 'a' to open User Address menu");
                Console.WriteLine("type 'c' to open User Card Info menu");
                Console.WriteLine("type 'q' to quit");

                char c = char.Parse(Console.ReadLine());

                switch (c)
                {
                    case 'u':
                        UserMenu u = new UserMenu(mapper);
                        u.Menu();
                        break;
                    case 'a':
                        UserAddressMenu a = new UserAddressMenu(mapper);
                        a.Menu();
                        break;
                    case 'c':
                        UserCardInfoMenu i = new UserCardInfoMenu(mapper);
                        i.Menu();
                        break;
                    case 'q':
                        return;
                }
            }


        }


      

       
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(UserAddressDalEf).Assembly, typeof(UserDalEf).Assembly, typeof(CountryDalEf).Assembly, typeof(CityDalEf).Assembly)
            );

            return conf.CreateMapper();
        }
        
    }
}
