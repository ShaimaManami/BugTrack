using BugTrack.Models;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;


namespace BugTrack.Controllers
{
    
    
        public partial class KanbanController : Controller
        {

            public IActionResult Index()
            {
                ViewBag.data = new KanbanDataModel().KanbanTasks();
                return View();
            }
        }
    }
