using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class ExamController : Controller
    {
        private readonly DbContextApp _adb;
        public ExamController(DbContextApp adb)
        {
            _adb = adb;
        }
        public IActionResult Index()
        {
            ViewBag.Qustion = _adb.QuizQUS.ToList();
            return View();
        }
        public IActionResult Login()
        {
         
            
            return View();
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public ActionResult Login(string UserName, string password)
        {
         

            if (ModelState.IsValid)
            {
               
                var data = _adb.Table.Where(s => s.UserName.Equals(UserName) && s.password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                  
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Tag"] = "Login failed";
               
                    return RedirectToAction("Login");
                 
                }
            }
        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<ActionResult> Index_post(IFormCollection Listqustion)
        {

            List<Quiz> QustionList = _adb.QuizQUS.ToList();
            int count = 0;
         

            foreach (Quiz Qustion in QustionList) {
               
                ViewData["Answer" + Qustion.id] = Listqustion["" + Qustion.id];

         
                    await _adb.SaveChangesAsync();
               
               
                String s = Listqustion["" + Qustion.id];
               
                if (Qustion.answer.Trim().Equals(s.Trim()))
                {
                    ViewData["Correct Answer " + Qustion.id] = "true";
                    count++;
                }
                else {
                    ViewData["Correct Answer " + Qustion.id] = Qustion.answer;
                }
                
         
            }
            ViewData["mark"] = count;
            ViewData["form"] = QustionList.Count;
            ViewBag.Qustion= _adb.QuizQUS.ToList();

            return View();
        }



    }
}