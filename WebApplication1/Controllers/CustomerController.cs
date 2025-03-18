using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly WebApplication1Context _context;

        // Constructor
        public CustomerController(WebApplication1Context context)
        {
            _context = context;
        }

        // Index: Menampilkan daftar semua customer
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _context.CustomerTbs.ToListAsync();
            return View(customers);
        }

        // Create: Menampilkan form untuk menambah customer
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create: Menyimpan data customer baru
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerTb customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // Edit: Menampilkan form untuk mengedit data customer
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.CustomerTbs.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // Edit: Menyimpan perubahan data customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerTb customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // DELETE: Directly delete customer without confirmation
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.CustomerTbs.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Delete the customer
            _context.CustomerTbs.Remove(customer);
            await _context.SaveChangesAsync();

            // Redirect back to the Index page after deletion
            return RedirectToAction(nameof(Index));
        }



        // Cek apakah customer ada dalam database
        private bool CustomerExists(int id)
        {
            return _context.CustomerTbs.Any(e => e.CustomerId == id);
        }
    }
}
