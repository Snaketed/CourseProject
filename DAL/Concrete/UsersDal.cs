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
//    public class UsersDal : IUsersDal
//    {
//        private string connectionString;

//        public UsersDal(string connectionString)
//        {
//            this.connectionString = connectionString;
//        }

//        public UsersDTO CreateUser(UsersDTO user)
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "insert into Users (FirstName, LastName, Email, PhoneNumber, Gender,Password) output INSERTED.Id values (@FirstName, @LastName, @Email, @PhoneNumber, @Gender, @Password)";
//                comm.Parameters.Clear();
//                comm.Parameters.AddWithValue("@FirstName", user.FirstName);
//                comm.Parameters.AddWithValue("@LastName", user.LastName);
//                comm.Parameters.AddWithValue("@Email", user.Email);
//                comm.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
//                comm.Parameters.AddWithValue("@Gender", user.Gender);
//                comm.Parameters.AddWithValue("@Password", user.Password);
//                conn.Open();

//                user.Id = Convert.ToInt32(comm.ExecuteScalar());
//                return user;
//            }
//        }

//        public void DeleteUser(long id)
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "delete from Users where Id = @id";
//                comm.Parameters.Clear();
//                comm.Parameters.AddWithValue("@id", id);
//                conn.Open();

//                comm.ExecuteNonQuery();
//            }
//        }

//        public List<UsersDTO> GetAllUsers()
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "select * from Users";
//                conn.Open();
//                SqlDataReader reader = comm.ExecuteReader();

//                List<UsersDTO> users = new List<UsersDTO>();
//                while (reader.Read())
//                {
//                    users.Add(new UsersDTO
//                    {
//                        Id = (long)reader["Id"],
//                        FirstName = reader["FirstName"].ToString(),
//                        LastName = reader["LastName"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        PhoneNumber = reader["PhoneNumber"].ToString(),
//                        Gender = reader["Gender"].ToString(),
//                        Password = Encoding.ASCII.GetBytes(reader["Password"].ToString()),
//                    });
//                }

//                return users;
//            }
//        }

//        public UsersDTO GetUserById(long id)
//        {
//            throw new NotImplementedException();
//        }

//        public UsersDTO UpdateUser(UsersDTO movie)
//        {
//            throw new NotImplementedException();
//        }

//    }
//}
