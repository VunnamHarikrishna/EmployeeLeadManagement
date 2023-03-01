using KalingaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KalingaManagementSystem.Controllers
{
    public class LeadController : Controller
    {
        static ManagerModel Modelobj = new ManagerModel();

        // GET: Lead
        public ActionResult Index()
        {
           
            return View(); 
        }

            // GET: Lead/Details/5
   
        public ActionResult Details(int id)
        {

            IEnumerable<Student> StudentData = Modelobj.GetStudentByLeadID(id);

            return View(StudentData);
        }

        // GET: Lead/Create
        public ActionResult Create()
        {
            IEnumerable<CatageryModel> CatageryData = Modelobj.GetCatageryData();
            TempData["CatageryData"] = CatageryData;
            
            return View();
        }


      


        // show the data
        public ActionResult Show()
        {
            IEnumerable<Lead> Leads = Modelobj.GetLeadData();

            return View(Leads);
        }

        [HttpPost]
        public ActionResult SubmitCreate(Lead lead)
        {
            IEnumerable<CatageryModel> CatageryData = Modelobj.GetCatageryData();
            TempData["CatageryData"] = CatageryData;

            try
            {
                if (ModelState.IsValid)
                {
                    int row = Modelobj.AddLead(lead);
                    if (row > 0)
                    {
                        ViewBag.message = "Data inserted";
                        // return RedirectToAction("Sucess");
                    }
                    // TODO: Add insert logic here
                }
               // return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.message = "Data not inserted";
                //return View();
            }
            return View("Create");
        }

        // POST: Lead/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Lead/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lead/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lead/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lead/Delete/5
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
