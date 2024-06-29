using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlatManagerLog.Models;
using Microsoft.EntityFrameworkCore;

namespace FlatManagerLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FMLContext _context;

        public HomeController(ILogger<HomeController> _logger, FMLContext _context)
        {
            this._logger = _logger;
            this._context = _context;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction(nameof(Login));
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Buildings, ToDos ve Rooms ile ilgili metodlar aynı şekilde kalıyor

        // Tenants
public async Task<IActionResult> Tenants()
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }

    var tenants = await _context.Tenants.ToListAsync();

    foreach (var tenant in tenants)
    {
        var payments = await _context.Payments
            .Where(p => p.TenantId == tenant.Id && p.Date.Month == DateTime.Now.Month && p.Date.Year == DateTime.Now.Year)
            .ToListAsync();

        tenant.IsRentPaidForCurrentMonth = payments.Any();
    }

    return View(tenants);
}


public async Task<IActionResult> AddTenants(Tenants tenants)
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }

    if (tenants.Id == 0)
    {
        tenants.RentPayed = tenants.RentPayed ?? "Not Payed"; // Ensure RentPayed is not null
        await _context.AddAsync(tenants);
    }
    else
    {
        tenants.RentPayed = tenants.RentPayed ?? "Not Payed"; // Ensure RentPayed is not null
        _context.Update(tenants);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Tenants));
}



        public async Task<IActionResult> DeleteTenants(int? Id)
        {
            if (!HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction(nameof(Login));
            }
            Tenants tenants = await _context.Tenants.FindAsync(Id);
            _context.Remove(tenants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Tenants));
        }

        public async Task<IActionResult> TenantsDetails(int Id)
        {
            if (!HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction(nameof(Login));
            }
            var tenants = await _context.Tenants.FindAsync(Id);
            return Json(tenants);
        }

        // Payments
        public async Task<IActionResult> GetPayments(int tenantId)
        {
            if (!HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction(nameof(Login));
            }
            var payments = await _context.Payments.Where(p => p.TenantId == tenantId).ToListAsync();
            return Json(payments);
        }

        [HttpPost]
public async Task<IActionResult> AddPayment(Payments payment)
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }

    payment.Date = DateTime.Now;
    await _context.Payments.AddAsync(payment);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Tenants));
}

        [HttpPost]
        public async Task<IActionResult> DeletePayment(int paymentId)
        {
            if (!HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction(nameof(Login));
            }
            Payments payment = await _context.Payments.FindAsync(paymentId);
            _context.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Tenants));
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginKontrol(string Email, string Password)
        {
            var Manager = _context.Manager.FirstOrDefault(w => w.Email == Email && w.Password == Password);
            if (Manager == null)
            {
                return RedirectToAction(nameof(Login));
            }

            HttpContext.Session.SetInt32("id", Manager.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction(nameof(Login));
        }

    //TODOS CRUD:

    // ToDos
public async Task<IActionResult> ToDos()
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }
    var list = await _context.ToDos.ToListAsync();
    return View(list);
}

public async Task<IActionResult> AddToDo(ToDos toDo)
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }

    if (toDo.Id == 0)
    {
        await _context.AddAsync(toDo);
    }
    else
    {
        _context.Update(toDo);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(ToDos));
}

public async Task<IActionResult> DeleteToDo(int? Id)
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }

    var toDo = await _context.ToDos.FindAsync(Id);
    if (toDo == null)
    {
        return NotFound();
    }

    _context.Remove(toDo);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(ToDos));
}

public async Task<IActionResult> ToDoDetails(int Id)
{
    if (!HttpContext.Session.GetInt32("id").HasValue)
    {
        return RedirectToAction(nameof(Login));
    }

    var toDo = await _context.ToDos.FindAsync(Id);
    if (toDo == null)
    {
        return NotFound();
    }

    return Json(toDo);
}


//ROOMS CRUD:

// Rooms




//BUİLDINGS CRUD:




    }
}