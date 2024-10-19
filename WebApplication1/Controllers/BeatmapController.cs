using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BeatmapController : Controller
    {
        // GET: BeatmapController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7165/api/beatmap";
            List<BeatMaps> beatMaps = new List<BeatMaps>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                beatMaps = JsonConvert.DeserializeObject<List<BeatMaps>>(result);
            }

                return View(beatMaps);
        }

        // GET: BeatmapController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BeatmapController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeatmapController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BeatMaps beatMaps)
        {
            string apiUrl = "https://localhost:7165/api/beatmap";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(beatMaps),
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                                            
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(beatMaps);
        }

        // GET: BeatmapController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeatmapController/Edit/5
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

        // GET: BeatmapController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BeatmapController/Delete/5
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
