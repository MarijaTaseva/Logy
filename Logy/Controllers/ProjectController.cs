using Microsoft.AspNetCore.Mvc;

namespace Logy.Controllers
{
    public class ProjectController : Controller
    {
        public ProjectsController p;
        
        public IActionResult Index()
        {
            return View();
       // p.PostProject();
        }

        public ActionResult GetAction()
        {
            return View();
        }

        // GET: Project/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            return View();
        }
    }
}