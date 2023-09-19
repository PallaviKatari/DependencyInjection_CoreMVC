using DependencyInjection.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;
namespace DependencyInjection.Controllers
{
//    Introduction
//Understanding the life cycle of Dependency Injection(DI) is very important in ASP.Net Core applications.As we know, Dependency injection(DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies.Most often, classes will declare their dependencies via their constructor, allowing them to follow the Explicit Dependencies Principle.This approach is known as "constructor injection".

//To implement dependency injection, we need to configure a DI container with classes that is participating in DI.DI Container has to decide whether to return a new instance of the service or provide an existing instance.In startup class, we perform this activity on ConfigureServices method.

//The lifetime of the service depends on when the dependency is instantiated and how long it lives.And lifetime depends on how we have registered those services.

//The below three methods define the lifetime of the services,
//    AddTransient
//    Transient lifetime services are created each time they are requested.This lifetime works best for lightweight, stateless services.


//AddScoped
//    Scoped lifetime services are created once per request.
//    AddSingleton
//Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance.
    public class DIController : Controller
    {

        private readonly ILogger<DIController> _logger;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public DIController(ILogger<DIController> logger,
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;

        }
        public IActionResult Index()
        {
            ViewBag.transient1 = _transientService1.GetOperationID().ToString();
            ViewBag.transient2 = _transientService2.GetOperationID().ToString();
            ViewBag.scoped1 = _scopedService1.GetOperationID().ToString();
            ViewBag.scoped2 = _scopedService2.GetOperationID().ToString();
            ViewBag.singleton1 = _singletonService1.GetOperationID().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationID().ToString();
            return View();
        }
    }
}
