using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiController.Controllers
{
    public class HelloWorld : Controller
    {
        // GET: HelloWorld
        [HttpGet]
        [Route("Hello World")]
        public ActionResult Index()
        {

            return Ok(new
            {
                message = "Hello World"
            }) ;
        }

        // GET: HelloWorld/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HelloWorld/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HelloWorld/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HelloWorld/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HelloWorld/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HelloWorld/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HelloWorld/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
