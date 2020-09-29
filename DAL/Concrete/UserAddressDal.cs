//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAL.Interfaces;
//using DTO;

//namespace DAL.Concrete
//{
//    public class UserAddressDal : IUserAddressDal
//    {

//        private string connectionString;

//        public UserAddressDal(string connectionString)
//        {
//            this.connectionString = connectionString;
//        }

     
//        public UserAddressDTO CreateUserAddress(UserAddressDTO user)
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "insert into UserAddress (UserId, Country, City, PostalCode) output INSERTED.Id values (@UserId, @Country, @City, @PostalCode)";
//                comm.Parameters.Clear();
//                comm.Parameters.AddWithValue("@UserId", user.UserId);
//                comm.Parameters.AddWithValue("@Country", user.Country);
//                comm.Parameters.AddWithValue("@City", user.City);
//                comm.Parameters.AddWithValue("@PostalCode", user.PostalCode);
//                conn.Open();

//                user.Id = Convert.ToInt32(comm.ExecuteScalar());
//                return user;
//            }
//        }

//        public List<UserAddressDTO> GetAllUserAddress()
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "select * from UserAddress";
//                conn.Open();
//                SqlDataReader reader = comm.ExecuteReader();

//                List<UserAddressDTO> users = new List<UserAddressDTO>();
//                while (reader.Read())
//                {
//                    users.Add(new UserAddressDTO
//                    {
//                        Id = (long) reader["Id"],
//                        UserId = (long) reader["UserId"],
//                        City = (int)reader["City"],
//                        Country = (int)reader["Country"],
//                        PostalCode = (long)reader["PostalCode"],

//                    });
//                }

//                return users;
//            }
//        }

//        public void DeleteUserAddress(long id)
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "delete from UserAddress where Id = @id";
//                comm.Parameters.Clear();
//                comm.Parameters.AddWithValue("@id", id);
//                conn.Open();

//                comm.ExecuteNonQuery();
//            }
//        }

//        UserAddressDTO IUserAddressDal.GetUserAddressById(long id)
//        {
//            throw new NotImplementedException();
//        }

      

//        public UserAddressDTO UpdateUserAddress(UserAddressDTO user)
//        {
//            throw new NotImplementedException();
//        }

//    }


//}
