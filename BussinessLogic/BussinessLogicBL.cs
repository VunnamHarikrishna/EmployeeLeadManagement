using System;
using System.Collections.Generic;
using DataLogic;
using Entities;

namespace BussinessLogic
{
    public class BussinessLogicBL
    {
        static DataLogicDL DLobj = new DataLogicDL();
        public int AddStudent(StudentEntity enobj)
        {
            return DLobj.AddStudentData(enobj);
        }
        public IEnumerable<StudentEntity> GetStudentData()
        {
            return DLobj.GetStudentData();
        }

        public int AddLead(LeadEntity leadObj)
        {
            return DLobj.AddLead(leadObj);
        }

        public IEnumerable<LeadEntity> GetLeadData()
        {
            return DLobj.GetLeadData();
        }

        public bool UpdateLead(StudentEntity enobj)
        {
            
            if (DLobj.UpdateLead(enobj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<StudentEntity> GetStudentDataByLeadId(int id)
        {
            return DLobj.GetStudentDataByLeadId(id);
        }

        public IEnumerable<CatageryEnitity> GetCatageryData()
        {
            return DLobj.GetCatageryData();
        
        }



        public bool RemoveStudent(int id)
        {
            if (DLobj.RemoveStudent(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateStudentDetails(StudentEntity enobj)
        {
            if (DLobj.UpdateStudentDetails(enobj))
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
