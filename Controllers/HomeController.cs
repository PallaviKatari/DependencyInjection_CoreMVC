using DependencyInjection.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace DependencyInjection.Controllers
{
    //public class HomeController : Controller
    //{
    //    //WITHOUT DEPENDENCY INJECTION
    //    public JsonResult Index()
    //    {
    //        StudentRepository repository = new StudentRepository();
    //        List<Student> allStudentDetails = repository.GetAllStudent();
    //        return Json(allStudentDetails);
    //    }
    //    //https://localhost:44389/Home/GetStudentDetails/1
    //    public JsonResult GetStudentDetails(int Id)
    //    {
    //        StudentRepository repository = new StudentRepository();
    //        Student studentDetails = repository.GetStudentById(Id);
    //        return Json(studentDetails);
    //    }
    //}

    //When to use which Service
    //Singleton approach => We can use this for logging service, feature flag(to on and off module while deployment), and email service
    //Scoped approach => This is a better option when you want to maintain a state within a request.
    //Transient approach => Use this approach for the lightweight service with little or no state.

    //WITH DEPENDENCY INJECTION - CONSTRUCTOR INJECTION
    //PROPERTY INJECTION - USING GETTER SETTER
    public class HomeController : Controller
    {
        //Create a reference variable of IStudentRepository
        private readonly IStudentRepository? _repository = null;

        //Initialize the variable through constructor
        //If you don't configure the dependency container - default - Singleton
        public HomeController(IStudentRepository repository)
        {
            _repository = repository;
        }
        public JsonResult Index()
        {
            List<Student>? allStudentDetails = _repository?.GetAllStudent();
            return Json(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Student? studentDetails = _repository?.GetStudentById(Id);
            return Json(studentDetails);
        }

    }

}