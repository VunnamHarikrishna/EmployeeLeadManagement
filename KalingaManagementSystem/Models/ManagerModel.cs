using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BussinessLogic;
using Entities;



namespace KalingaManagementSystem.Models
{
    public class ManagerModel
    {
       static BussinessLogicBL BlObj = new BussinessLogicBL();
        static StudentEntity Enobj = new StudentEntity();
        static LeadEntity LeadObj = new LeadEntity();
        public int AddStudent(Student Data)
        {
            Enobj.StudentName = Data.StudentName;
            Enobj.DOJ = Data.DOJ;
            Enobj.ContactNumber = Data.ContactNumber;
            Enobj.Address = Data.Address;
            Enobj.LeadId = Data.LeadId;

            return BlObj.AddStudent(Enobj);
        }

        internal IEnumerable<Student> GetStudentByLeadID(int id)
        {
            List<Student> StudentData = new List<Student>();
            IEnumerable<StudentEntity> ListOfStudentsData = BlObj.GetStudentDataByLeadId(id);
            foreach (StudentEntity temp in ListOfStudentsData)
            {
                Student stutemp = new Student();
                stutemp.LeadId = temp.LeadId;
                stutemp.StudentName = temp.StudentName;
                stutemp.DOJ = temp.DOJ;
                stutemp.ContactNumber = temp.ContactNumber;
                stutemp.Address = temp.Address;
                stutemp.StudentId = temp.StudentId;
                StudentData.Add(stutemp);
            }

            return StudentData;
        }

        internal IEnumerable<Student> GetStudentData()
        {
            List<Student> StudentData = new List<Student>();
         IEnumerable<StudentEntity> ListOfStudentsData= BlObj.GetStudentData();
            foreach(StudentEntity temp in ListOfStudentsData)
            {
                Student stutemp = new Student();
                stutemp.LeadId = temp.LeadId;
                stutemp.StudentName = temp.StudentName;
                stutemp.DOJ = temp.DOJ;
                stutemp.ContactNumber = temp.ContactNumber;
                stutemp.Address = temp.Address;
                stutemp.StudentId = temp.StudentId;
                StudentData.Add(stutemp);
            }

            return StudentData;
        }

        internal bool UpddateLead(Student Data)
        {
            Enobj.StudentId = Data.StudentId;
            Enobj.StudentName = Data.StudentName;
            Enobj.DOJ = Data.DOJ;
            Enobj.ContactNumber = Data.ContactNumber;
            Enobj.Address = Data.Address;
            Enobj.LeadId = Data.LeadId;
            
            if (BlObj.UpdateLead(Enobj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal IEnumerable<Lead> GetLeadData()
        {
            List<Lead> LeadData = new List<Lead>();
            IEnumerable<LeadEntity> ListOfLeadData = BlObj.GetLeadData(); 

            foreach(LeadEntity temp in ListOfLeadData)
            {
                Lead TempObj = new Lead();
                TempObj.LeadID = temp.LeadID;
                TempObj.Name = temp.Name;
                TempObj.ContactNumber = temp.ContactNumber;
                TempObj.CatogeryId = temp.CatogeryId;
                LeadData.Add(TempObj);
            }

            return LeadData;
        }

        internal int AddLead(Lead lead)
        {
            LeadObj.Name = lead.Name;
            LeadObj.ContactNumber = lead.ContactNumber;
            LeadObj.CatogeryId = lead.CatogeryId;
            return BlObj.AddLead(LeadObj);
        }

        internal IEnumerable<CatageryModel> GetCatageryData()
        {
            List<CatageryModel> CatageryData = new List<CatageryModel>();

            IEnumerable<CatageryEnitity> Catagerys=   BlObj.GetCatageryData();
            foreach (CatageryEnitity temp in Catagerys)
            {
                CatageryModel TempObj = new CatageryModel();
                TempObj.CatageryID = temp.CatageryID;
                TempObj.CatageryName = temp.CatageryName;
                CatageryData.Add(TempObj);
            }

            return CatageryData;
        }

        internal bool UpdateStudentDetails(Student student)
        {
            Enobj.StudentId = student.StudentId;
            Enobj.StudentName = student.StudentName;
            Enobj.DOJ = student.DOJ;
            Enobj.ContactNumber = student.ContactNumber;
            Enobj.Address = student.Address;
            Enobj.LeadId = student.LeadId;

            if (BlObj.UpdateStudentDetails(Enobj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal Student GetStudentById(int id)
        {
            ManagerModel managerModel = new ManagerModel();
            IEnumerable<Student> students = managerModel.GetStudentData();
            return students.ToList().Find(X => X.StudentId==id);
            //employees.Find(employee => employee.IsManager == true);
        }

        internal bool RemoveStudent(int id)
        {
            if (BlObj.RemoveStudent(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}