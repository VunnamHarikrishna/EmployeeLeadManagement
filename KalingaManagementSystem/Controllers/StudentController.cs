using KalingaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KalingaManagementSystem.Controllers
{
    public class StudentController : Controller
    {
       static  ManagerModel Modelobj = new ManagerModel();

       
        /// <summary>
        /// this method is create the new student data
        /// </summary>
        /// <returns></returns>
        // GET: Student/Create
        public ActionResult Create()
        {
            IEnumerable<Lead> LeadData = Modelobj.GetLeadData();
            TempData["LeadData"] = LeadData;

            return View();
        }
        /// <summary>
        /// what ever the student enter the data that will taken by this 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult SubmitCreate(Student Data)
        {

            //IEnumerable<Lead> LeadData = Modelobj.GetLeadData();
            //TempData["LeadData"] = LeadData;
            //int id= Data.LeadId;
            
            try
            {
                if (ModelState.IsValid)
                {
                    int row = Modelobj.AddStudent(Data);
                    if (row > 0)
                    {
                        ViewBag.message = "Data inserted";

                    }
                }
               
            }
            catch
            {
                ViewBag.message = "Data not inserted";
            }
            return RedirectToAction("Sucess");
            //return View("Create");

        }

        /// <summary>
        /// assign lead
        /// </summary>
        /// <returns></returns>
        public ActionResult AssginLead()
        {
            Student StudentObj = new Student();
            

            IEnumerable<Student> StudentData = Modelobj.GetStudentData();
            IEnumerable<Lead> LeadData = Modelobj.GetLeadData();


            TempData["StudentData"] = StudentData;
            TempData["LeadData"] = LeadData;


            return View();
        }
        /// <summary>
        /// get the id value
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public ActionResult AssginLead(Student student)
        {
            IEnumerable<Student> StudentData = Modelobj.GetStudentData();
            IEnumerable<Lead> LeadData = Modelobj.GetLeadData();


            TempData["StudentData"] = StudentData;
            TempData["LeadData"] = LeadData;

            int o=student.StudentId;
            // int r = lead.LeadID;
            

            if(Modelobj.UpddateLead(student))
            {
                ViewBag.message = "Lead is Updated";
            }
            else
            {
                ViewBag.message = "somting went wrong";
            }
           
            return View();
        }


        /// <summary>
        ///   this is navigate sucess page
        /// </summary>
        /// <returns></returns>

        public ActionResult Sucess()
        {
            return View();
        }

      /// <summary>
      /// this method is to display the all the students data
      /// </summary>
      /// <returns></returns>
        // show the data
        public ActionResult Show()
        {

            IEnumerable<Student> students = Modelobj.GetStudentData();

            return View(students);
        }

        /// <summary>
        ///  edit the student details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       
        public ActionResult Edit(int id)
        {
            //IEnumerable<Student> students = Modelobj.GetStudentData();

            Student student = Modelobj.GetStudentById(id);

            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (Modelobj.UpdateStudentDetails(student))
            {
                ViewBag.Message="Student Details Updated Sucessfully";
            }
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult EditLead(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("AssginLead");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        ///  this is for remove data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {

            if (Modelobj.RemoveStudent(id))
            {
                ViewBag.message = "student Data deleted";
            }
            else
            {
                ViewBag.message = "somting went wrong";
            }

           
            return RedirectToAction("Sucess");
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = Modelobj.GetStudentById(id);

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}












/*
 * 
 * 
 *  // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
 // POST: Student/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Student collection,int i)
        //{


        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Sucess");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Student/Edit/5
*/