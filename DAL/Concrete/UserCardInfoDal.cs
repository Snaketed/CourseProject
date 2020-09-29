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
//    public class UserCardInfoDal : IUserCardInfoDal
//    {
//        private string connectionString;

//        public UserCardInfoDal(string connectionString)
//        {
//            this.connectionString = connectionString;
//        }

//        public UserCardInfoDTO CreateUserCardInfo(UserCardInfoDTO user)
//        {


//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "insert into UserCardInfo (UserId, CardNumber, ValidMonth, ValidYear, CVC) output INSERTED.Id values (@UserId, @CardNumber," +
//                                   " @ValidMonth, @ValidYear, @CVC)";
//                comm.Parameters.Clear();
//                comm.Parameters.AddWithValue("@UserId", user.UserId);
//                comm.Parameters.AddWithValue("@CardNumber", user.CardNumber);
//                comm.Parameters.AddWithValue("@ValidMonth", user.ValidMonth);
//                comm.Parameters.AddWithValue("@ValidYear", user.ValidYear);
//                comm.Parameters.AddWithValue("@CVC", user.CVC);
//                conn.Open();

//                user.Id = Convert.ToInt32(comm.ExecuteScalar());
//                return user;
//            }
//        }
//        public List<UserCardInfoDTO> GetAllUserCardInfo()
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "select * from UserCardInfo";
//                conn.Open();
//                SqlDataReader reader = comm.ExecuteReader();

//                List<UserCardInfoDTO> users = new List<UserCardInfoDTO>();
//                while (reader.Read())
//                {
//                    users.Add(new UserCardInfoDTO
//                    {
//                        Id = (long)reader["Id"],
//                        UserId = (long)reader["UserId"],
//                        CardNumber = reader["CardNumber"].ToString(),
//                        ValidMonth = reader["ValidMonth"].ToString(),
//                        ValidYear = reader["ValidYear"].ToString(),
//                        CVC = reader["CVC"].ToString()
//                    });
//                }

//                return users;
//            }
//        }



//        public void DeleteUserCardInfo(long id)
//        {
//            using (SqlConnection conn = new SqlConnection(this.connectionString))
//            using (SqlCommand comm = conn.CreateCommand())
//            {
//                comm.CommandText = "delete from UserCardInfo where Id = @id";
//                comm.Parameters.Clear();
//                comm.Parameters.AddWithValue("@id", id);
//                conn.Open();

//                comm.ExecuteNonQuery();
//            }
//        }
//        public UserCardInfoDTO UpdateUserCardInfo(UserCardInfoDTO user)
//        {
//            throw new NotImplementedException();
//        }
//        public UserCardInfoDTO GetUserById(long id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
