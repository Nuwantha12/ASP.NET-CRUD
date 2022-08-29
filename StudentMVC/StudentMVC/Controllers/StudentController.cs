using StudentMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        db_testEntities dbobj = new db_testEntities();
        // GET: Student
        public ActionResult Student(tbl_Student obj)
        {   
           
            
             return View();
            
            
        }


        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            if (ModelState.IsValid)
            {
                tbl_Student obj = new tbl_Student();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.FName = model.FName;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;


                if(model.ID==0)
                {
                    dbobj.tbl_Student.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbobj.SaveChanges();
                }
                
            }
            ModelState.Clear();
            

                

            return View("Student");
        }

        public ActionResult StudentList()
        {
            
            var res = dbobj.tbl_Student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.tbl_Student.Where(x => x.ID == id).First();
            dbobj.tbl_Student.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.tbl_Student.ToList();
            return View("StudentList",list);
        }
        
    }
}