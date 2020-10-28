using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using DAL.Interfaces;
using DalEf.Concrete;
using DTO;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using Unity;


namespace CompanyWF
{
    static class Program
    {
        
        public static UnityContainer Container;
        public static long Id;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            bool check = true;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login lf = Container.Resolve<Login>();

            
            while (check)
            {
                lf.ShowDialog();
                if (lf.DialogResult == DialogResult.Yes)
                {

                    Application.Run(Container.Resolve<RegistrationForm>());


                }
                else if (lf.DialogResult == DialogResult.OK)
                {
                    Id = lf.GetId();
                    Application.Run(Container.Resolve<ProfileForm>());
                }
                else
                {
                    check = false;
                    Application.Exit();
                }
            }
        }


        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(UserDalEf).Assembly);
                });
            
            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container
                .RegisterType<IUserCardInfoDal, UserCardInfoDalEf>()
                .RegisterType<IUserAddressDal, UserAddressDalEf>()
                .RegisterType<IUsersDal, UserDalEf>()
                .RegisterType<ICityDal, CityDalEf>()
                .RegisterType<ICountryDal, CountryDalEf>()
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<IRegistManager, RegistManager>()
                .RegisterType<IUserInfoManager, UserInfoManager>();
        }
    }
}


