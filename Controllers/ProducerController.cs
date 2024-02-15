using eCommerceApp.Data;
using eCommerceApp.Data.Services;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //GET Request : Producer/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(new Producer());
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: Producer/Edit/id-1
        public async Task<IActionResult> Edit(int id)
        {
            //Before we show the data to the user we are going to check if the producer with this id exist 
            var producerDetails = await _service.GetByIdAsync(id);
            if(producerDetails == null)
            {
                return View("Not Found");
            }
            return View(producerDetails);
        }

        [HttpPost]
        //This method will be having 2 parameters 
        // The 1st parameter is going to be the ID of the producer, which is going to come from the requestURL
        // and we are going to compare the request URL ID with the bind ID whithin the bidn method
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(new Producer());
            }
            //to check if the ID coming from the url is equal to the producer ID
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        //GET: Producer/Delete/id-1
        public async Task<IActionResult> Delete(int id)
        {
            //Before we show the data to the user we are going to check if the producer with this id exist 
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not Found");
            }
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);
            if(ProducerDetails == null)
            {
                return View("Not Found");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
