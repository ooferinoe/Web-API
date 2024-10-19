using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DogPicsController : Controller
    {
        // GET: DogPicsController

        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://dog.ceo/api/breeds/image/random";
            DogPics dogPics = new DogPics();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                dogPics = JsonConvert.DeserializeObject<DogPics>(result);
            }

            return View(dogPics);
        }

        // GET: DogPicsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DogPicsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogPicsController/Create
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

        // GET: DogPicsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DogPicsController/Edit/5
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

        // GET: DogPicsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogPicsController/Delete/5
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
