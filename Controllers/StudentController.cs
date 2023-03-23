using CRUD_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Controllers
{
    public class StudentController : Controller
    {


        private readonly StudentContext _Db;

        public StudentController(StudentContext studentContext) {

            _Db = studentContext;
        }


        public IActionResult StudentList()
        {



            try
            {

                var stdList = from a in _Db.tabl_Students
                              join b in _Db.tabl_Department on a.DepID equals b.ID into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {

                                  ID = a.ID,
                                  Name = a.Name,
                                  Fname = a.Fname,
                                  Mobile = a.Mobile,
                                  Email = a.Email,
                                  Description = a.Description,
                                  DepID = a.DepID,
                                  Department = b == null ? "" : b.Department

                              };


                return View(stdList);

            }


            catch (Exception ex) {

                return View();
            }

        }



        public IActionResult Create(Student obj)
        {
            loadDDL();
            return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {

            try
            {


                if(obj.ID == 0)
                    {
                        _Db.tabl_Students.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                else
                {
                    _Db.Entry(obj).State = EntityState.Modified;
                    await _Db.SaveChangesAsync();
                }
              
                
                    return RedirectToAction("StudentList");
            

            }


            catch (Exception ex) {


                return RedirectToAction("StudentList");
            }

        }


        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {

                var std = await _Db.tabl_Students.FindAsync(id);

                if(std != null)
                {
                    _Db.tabl_Students.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("StudentList");

            }
            catch (Exception ex)
            {
                return RedirectToAction("StudentList");
            }
        }

         private void loadDDL()
        {
            try
            {
                List<Departments> depList=new List<Departments>();
                depList = _Db.tabl_Department.ToList();

                depList.Insert(0, new Departments { ID = 0, Department = "Please Select" });

                ViewBag.DepList = depList;

            }
            catch (Exception ex)
            {

                
            }
        }

    }
}
