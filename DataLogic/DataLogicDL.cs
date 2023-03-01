using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DataLogicDL
    {
      static  DBconnection Con = new DBconnection();
        public int AddStudentData(StudentEntity enobj)
        {
            Con.OpenConnection();
            SqlCommand cmd = new SqlCommand("AddStudentData", Con.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue() @Name,@DOJ,@ContactNumber,@Address,@LeadId
            cmd.Parameters.AddWithValue("@Name", enobj.StudentName);
            cmd.Parameters.AddWithValue("@DOJ", enobj.DOJ);
            cmd.Parameters.AddWithValue("@ContactNumber", enobj.ContactNumber);
            cmd.Parameters.AddWithValue("@Address", enobj.Address);
            cmd.Parameters.AddWithValue("@LeadId", enobj.LeadId);
            cmd.ExecuteNonQuery();
            Con.CloseConnection();
            return 1;
        }

        public bool UpdateLead(StudentEntity enobj)
        {
            Con.OpenConnection();

            SqlCommand cmd = new SqlCommand("UpdateLead", Con.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LeadId", enobj.LeadId);
            cmd.Parameters.AddWithValue("@Id", enobj.StudentId);
            //cmd.Parameters.AddWithValue("@ContactNumber", leadObj.ContactNumber);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Con.CloseConnection();
                return false;
            }
            

            Con.CloseConnection();
            return true;
        }

        public bool UpdateStudentDetails(StudentEntity enobj)
        {
            Con.OpenConnection();

            SqlCommand cmd = new SqlCommand("UpdateStudentData", Con.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", enobj.StudentName);
            cmd.Parameters.AddWithValue("@DOJ", enobj.DOJ);
            cmd.Parameters.AddWithValue("@ContactNumber", enobj.ContactNumber);
            cmd.Parameters.AddWithValue("@Address", enobj.Address);
            cmd.Parameters.AddWithValue("@LeadId", enobj.LeadId);
            cmd.Parameters.AddWithValue("@Id", enobj.StudentId);
            //cmd.Parameters.AddWithValue("@ContactNumber", leadObj.ContactNumber);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Con.CloseConnection();
                return false;
            }


            Con.CloseConnection();
            return true;
        }

        public IEnumerable<StudentEntity> GetStudentDataByLeadId(int id)
        {
            Con.OpenConnection();
            SqlCommand cmd = new SqlCommand("GetStudentDataByLeadId", Con.getConnection());
            List<StudentEntity> ReturnData = new List<StudentEntity>();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeadId", id);

            SqlDataReader Data = cmd.ExecuteReader();
            while (Data.Read())
            {
                StudentEntity temp = new StudentEntity();
                temp.StudentId = Data.GetInt32(0);
                temp.StudentName = Data.GetString(1);
                temp.DOJ = Data.GetString(2);
                temp.ContactNumber = Data.GetString(3);
                temp.Address = Data.GetString(4);
                temp.LeadId = Data.GetInt32(5);
                ReturnData.Add(temp);
            }
            Con.CloseConnection();
            return ReturnData;
        }

        public bool RemoveStudent(int id)
        {
            Con.OpenConnection();

            SqlCommand cmd = new SqlCommand("RemoveStudent", Con.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);
            //cmd.Parameters.AddWithValue("@ContactNumber", leadObj.ContactNumber);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Con.CloseConnection();
                return false;
            }


            Con.CloseConnection();
            return true;
        }

        //UpdateLead

        public int AddLead(LeadEntity leadObj)
        {
            Con.OpenConnection();
            SqlCommand cmd = new SqlCommand("AddLeadData", Con.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", leadObj.Name);
            cmd.Parameters.AddWithValue("@CatogeryId", leadObj.CatogeryId);
            cmd.Parameters.AddWithValue("@ContactNumber", leadObj.ContactNumber);

            cmd.ExecuteNonQuery();

            Con.CloseConnection();
            return 1;
        }

        public IEnumerable<StudentEntity> GetStudentData()
        {
            Con.OpenConnection();
            SqlCommand cmd = new SqlCommand("GetStudentData", Con.getConnection());
            List<StudentEntity> ReturnData = new List<StudentEntity>();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader Data = cmd.ExecuteReader();
            while (Data.Read())
            {
                StudentEntity temp = new StudentEntity();
                temp.StudentId = Data.GetInt32(0);
                temp.StudentName = Data.GetString(1);
                temp.DOJ = Data.GetString(2);
                temp.ContactNumber = Data.GetString(3);
                temp.Address = Data.GetString(4);
                temp.LeadId = Data.GetInt32(5);
                ReturnData.Add(temp);
            }
            Con.CloseConnection();
            return ReturnData;
        }

        public IEnumerable<LeadEntity> GetLeadData()
        {
            Con.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetLeadData", Con.getConnection());
            List<LeadEntity> ReturnData = new List<LeadEntity>();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader Data = cmd.ExecuteReader();
            while (Data.Read())
            {
                LeadEntity temp = new LeadEntity();
                temp.LeadID = Data.GetInt32(0);
                temp.Name = Data.GetString(1);
                temp.ContactNumber = Data.GetString(3);
                temp.CatogeryId = Data.GetInt32(2);
                ReturnData.Add(temp);
            }
            Con.CloseConnection();
            return ReturnData;
        }
        public IEnumerable<CatageryEnitity> GetCatageryData()
        {
            Con.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetCatageryData", Con.getConnection());
            List<CatageryEnitity> ReturnData = new List<CatageryEnitity>();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader Data = cmd.ExecuteReader();
            while (Data.Read())
            {
                CatageryEnitity temp = new CatageryEnitity();
                temp.CatageryID = Data.GetInt32(0);
                temp.CatageryName = Data.GetString(1);
                
                ReturnData.Add(temp);
            }
            Con.CloseConnection();
            return ReturnData;
        }
    }
}
