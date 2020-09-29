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
    public class UserCardInfoMenu
    {
        private static UserCardInfoDalEf  _dal;
        public UserCardInfoMenu(IMapper mapper)
        {
            _dal = new UserCardInfoDalEf(mapper);
           
        }

        public void Menu()
        {
            while (true)
            {

                Console.WriteLine("type 'l' to get list of Users Card Info");
                Console.WriteLine("type 'c' to create User Card Info");
                Console.WriteLine("type 'd' to delete User Card Info");
                Console.WriteLine("type 'u' to update User Card Info");
                Console.WriteLine("type 'q' to quit");

                char c = char.Parse(Console.ReadLine());

                switch (c)
                {
                    case 'l':
                        ShowAllUserCardInfo(_dal);
                        break;
                    case 'c':
                        CreateUserCardInfo(_dal);
                        break;
                    case 'd':
                        DeleteUserCardInfo(_dal);
                        break;
                    case 'u':
                        UpdateUserCardInfo(_dal);
                        break;
                    case 'q':
                        return;
                }
            }
        }

        private static void UpdateUserCardInfo(UserCardInfoDalEf dal)
        {


            Console.Write("Enter User Id to update : ");
            long id = Convert.ToInt64(Console.ReadLine());
            var m = dal.GetUserCardInfoById(id);
            Console.Write("Enter your new User Id : ");
            m.UserId = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter your new Card Number : ");
            m.CardNumber = Console.ReadLine();
            Console.Write("Enter new Valid Month : ");
            m.ValidMonth = Console.ReadLine();
            Console.Write("Enter new ValidYear : ");
            m.ValidYear = Console.ReadLine();
            Console.Write("Enter new CVC : ");
            m.CVC = Console.ReadLine();
            dal.UpdateUserCardInfo(m);
            Console.WriteLine();

        }
        private static void CreateUserCardInfo(UserCardInfoDalEf dal)
        {


            UserCardInfoDTO m = new UserCardInfoDTO();
            Console.Write("Enter your User Id : ");
            m.UserId =Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter your Card Number : ");
            m.CardNumber = Console.ReadLine();
            Console.Write("Enter Valid Month : ");
            m.ValidMonth = Console.ReadLine();
            Console.Write("Enter  ValidYear : ");
            m.ValidYear = Console.ReadLine();
            Console.Write("Enter CVC : ");
            m.CVC = Console.ReadLine();
            m = dal.CreateUserCardInfo(m);
            Console.WriteLine();

        }
        private static void ShowAllUserCardInfo(UserCardInfoDalEf dal)
        {
            foreach (var user in dal.GetAllUserCardInfo())
            {
                Console.WriteLine($"Id: {user.Id}\t User Id:{user.UserId}\t Card number: {user.CardNumber}\t Valid Month/Year" +
                                  $"{user.ValidMonth}/{user.ValidYear}\t CVC: {user.CVC}");
            }

            Console.WriteLine();
        }

        private static void DeleteUserCardInfo(UserCardInfoDalEf dal)
        {
            Console.Write("Enter User Id to delete : ");
            long id = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Deleting User ID: {id}");
            dal.DeleteUserCardInfo(id);
        }
    }
}

    