using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlatManagerLog.Models;

namespace FlatManagerLog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FMLContext _context;


    public HomeController(ILogger<HomeController> logger, FMLContext context)
    {
        _logger = logger;
        _context = context;
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

//Buildings/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public IActionResult Buildings()
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        List<Buildings> list = _context.Buildings.ToList();
        return View(list);
    }

    public async Task<IActionResult> AddBuildings(Buildings buildings)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }

        if (buildings.Id == 0)
        {
            await _context.AddAsync(buildings);
        }
        else
        {
            _context.Update(buildings);
        }


        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(buildings));
    }

    public async Task<IActionResult> DeleteBuildings(int? Id)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        Buildings buildings = await _context.Buildings.FindAsync(Id);
        _context.Remove(buildings);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Buildings));
    }

    public async Task<IActionResult> BuildingsDetails(int Id)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        var buildings = await _context.Buildings.FindAsync(Id);
        return Json(buildings);
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///ToDos
    
    
    public IActionResult ToDos()
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        List<ToDos> list = _context.ToDos.ToList();
        return View(list);
    }

    public async Task<IActionResult> AddToDos(ToDos todos)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }

        if (todos.Id == 0)
        {
            await _context.AddAsync(todos);
        }
        else
        {
            _context.Update(todos);
        }


        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(todos));
    }

    public async Task<IActionResult> DeleteToDos(int? Id)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        ToDos todos = await _context.ToDos.FindAsync(Id);
        _context.Remove(todos);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ToDos));
    }

    public async Task<IActionResult> ToDosDetails(int Id)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        var todos = await _context.ToDos.FindAsync(Id);
        return Json(todos);
    }
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////77
/// </summary>
/// <returns></returns>//BU boşlukta yukarıdaki TODOSLAR TENANATS OLARAK DEĞİŞTİRLECEK büyük küçük uyumuyla
    
    

    public IActionResult Tenants()
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }
        List<Tenants> list = _context.Tenants.ToList();
        return View(list);
    }

    public async Task<IActionResult> AddTenants(Tenants tenants)
    {
        if (!HttpContext.Session.GetInt32("id").HasValue)
        {
            return RedirectToAction(nameof(Login));

        }

        if (tenants.Id == 0)
        {
            await _context.AddAsync(tenants);
        }
        else
        {
            _context.Update(tenants);
        }


        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(tenants));
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
    


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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


}
