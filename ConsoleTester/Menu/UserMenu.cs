using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DalEf.Concrete;
using DTO;

namespace ConsoleTester.Menu
{
    public class UserMenu
    {
        private static UserDalEf _dal;
        public  UserMenu(IMapper mapper)
        {
            _dal = new UserDalEf(mapper);
        }

        public void Menu()
        {
            while (true)
            {
                
                Console.WriteLine("type 'l' to get list of Users");
                Console.WriteLine("type 'c' to create User");
                Console.WriteLine("type 'd' to delete User");
                Console.WriteLine("type 'u' to update User");
                Console.WriteLine("type 'q' to quit");

                char c = char.Parse(Console.ReadLine());

                switch (c)
                {
                    case 'l':
                        ShowAllUser(_dal);
                        break;
                    case 'c':
                        CreateUser(_dal);
                        break;
                    case 'd':
                        DeleteUser(_dal);
                        break;
                    case 'u':
                        UpdateUser(_dal);
                        break;
                    case 'q':
                        return;
                }
            }
        }
        private static void CreateUser(UserDalEf dal)
        {

            Guid salt = Guid.NewGuid();
            UsersDTO m = new UsersDTO();
            m.Salt = salt;
            Console.Write("Enter your first name : ");
            m.FirstName = Console.ReadLine();
            Console.Write("Enter your last name : ");
            m.LastName = Console.ReadLine();
            Console.Write("Enter your Email : ");
            m.Email = Console.ReadLine();
            Console.Write("Enter your phone number : ");
            m.PhoneNumber = Console.ReadLine();
            Console.Write("Enter your phone Gender : ");
            m.Gender = Console.ReadLine();
            Console.Write("Enter your phone Password : ");
            string password = Console.ReadLine();
            m.Password = hash(password, salt.ToString());
            m.RowInsertTime = DateTime.UtcNow;
            //m = dal.CreateUser(m);
            Console.WriteLine();

        }
        private static byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
        private static void ShowAllUser(UserDalEf dal)
        {
            foreach (var user in dal.GetAllUsers())
            {
                Console.WriteLine($"Id: {user.Id}\t Full Name: {user.FirstName} {user.LastName}\t Email: {user.Email}\t Phone number: {user.PhoneNumber}" +
                                  $"\tGender: {user.Gender}");
            }

            Console.WriteLine();
        }

        private static void DeleteUser(UserDalEf dal)
        {
            Console.Write("Enter User Id to delete : ");
            long id = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Deleting User ID: {id}");
            dal.DeleteUser(id);
        }

        private static void UpdateUser(UserDalEf dal)
        {
            Console.Write("Enter User Id to update : ");
            long id = Convert.ToInt64(Console.ReadLine());
            var m = dal.GetUserById(id);
            Console.Write("Enter your new first name : ");
            m.FirstName = Console.ReadLine();
            Console.Write("Enter your new last name : ");
            m.LastName = Console.ReadLine();
            Console.Write("Enter your new Email : ");
            m.Email = Console.ReadLine();
            Console.Write("Enter your new  phone number : ");
            m.PhoneNumber = Console.ReadLine();
            Console.Write("Enter your new Gender : ");
            m.Gender = Console.ReadLine();
            Console.Write("Enter your new Password : ");
            m.Password = Encoding.ASCII.GetBytes(Console.ReadLine());
            m.RowInsertTime = DateTime.UtcNow;
            dal.UpdateUser(m);
            Console.WriteLine();
        }
    }
}
