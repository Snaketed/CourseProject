using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DalEf.Concrete;
using DTO;

namespace ConsoleTester.Menu
{
    public class UserAddressMenu
    {
        private static UserAddressDalEf _dal;
        private static CountryDalEf _dalCountry;
        private static CityDalEf _dalCity;
        public UserAddressMenu(IMapper mapper)
        {

            _dalCountry = new CountryDalEf(mapper);
            _dalCity = new CityDalEf(mapper);
            _dal = new UserAddressDalEf(mapper);
            
        }

        public void Menu()
        {
            while (true)
            {

                Console.WriteLine("type 'l' to get list of User address");
                Console.WriteLine("type 'c' to create User address");
                Console.WriteLine("type 'd' to delete User address");
                Console.WriteLine("type 'u' to update User address");
                Console.WriteLine("type 'q' to quit");

                char c = char.Parse(Console.ReadLine());

                switch (c)
                {
                    case 'l':
                        ShowAllUserAddress(_dal);
                        break;
                    case 'c':

                        CreateUserAddress(_dal, _dalCountry, _dalCity);
                        break;
                    case 'd':
                        DeleteUserAddress(_dal);
                        break;
                    case 'u':

                        UpdateUserAddress(_dal, _dalCountry, _dalCity);
                        break;
                    case 'q':
                        return;
                }
            }
        }
        private static void CreateUserAddress(UserAddressDalEf dal, CountryDalEf dalCountry, CityDalEf dalCity)
        {

           
            UserAddressDTO m = new UserAddressDTO();
            Console.Write("Enter your UserId : ");
            m.UserId = Convert.ToInt64(Console.ReadLine());
            foreach (var country in dalCountry.GetAllCountry())
            {
                Console.WriteLine($"{country.CountryId} : {country.Country1}");
            }
            Console.Write("Enter your Country Id : ");
            m.Country = Convert.ToInt32(Console.ReadLine());

            foreach (var city in dalCity.GetAllCity())
            {
                Console.WriteLine($"{city.CityId} : {city.City1}");
            }
            Console.Write("Enter your City Id : ");
            m.City = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Postal Code : ");
            m.PostalCode = Convert.ToInt64(Console.ReadLine());
            m = dal.CreateUserAddress(m);
            Console.WriteLine();

        }

        private static void UpdateUserAddress(UserAddressDalEf dal, CountryDalEf dalCountry, CityDalEf dalCity)
        {


            Console.Write("Enter User Id to update : ");
            long id = Convert.ToInt64(Console.ReadLine());
            var m = dal.GetUserAddressById(id);
            Console.Write("Enter your new UserId : ");
            m.UserId = Convert.ToInt64(Console.ReadLine());
            foreach (var country in dalCountry.GetAllCountry())
            {
                Console.WriteLine($"{country.CountryId} : {country.Country1}");
            }
            Console.Write("Enter your new Country Id : ");
            m.Country = Convert.ToInt32(Console.ReadLine());

            foreach (var city in dalCity.GetAllCity())
            {
                Console.WriteLine($"{city.CityId} : {city.City1}");
            }
            Console.Write("Enter your new City Id : ");
            m.City = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your new Postal Code : ");
            m.PostalCode = Convert.ToInt64(Console.ReadLine());
            dal.UpdateUserAddress(m);
            Console.WriteLine();

        }
        private static void ShowAllUserAddress(UserAddressDalEf dal)
        {

            foreach (var user in dal.GetAllUserAddress())
            {
                Console.WriteLine($"Id: {user.Id}\tUser Id: {user.UserId}\tCounty Id: {user.Country}\tCity Id: {user.City}\t Postal code: {user.PostalCode}");
            }
        }

        private static void DeleteUserAddress(UserAddressDalEf dal)
        {
            Console.Write("Enter User Address Id to delete : ");
            long id = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Deleting User Address ID: {id}");
            dal.DeleteUserAddress(id);
        }

    }
}
