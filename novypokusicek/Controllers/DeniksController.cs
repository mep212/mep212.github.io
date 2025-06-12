using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novypokusicek.Data;
using novypokusicek.Models;
using novypokusicek;

public class DeniksController : Controller
{
    private readonly ApplicationDbContext _context;

    public DeniksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Deniks
    public async Task<IActionResult> Index()
    {
        return View(await _context.Denik.ToListAsync());
    }

    // GET: Deniks/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var denik = await _context.Denik
            .FirstOrDefaultAsync(m => m.Id == id);
        if (denik == null)
        {
            return NotFound();
        }

        return View(denik);
    }

    // GET: Deniks/Create
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.LepsiEditor)] 
    public IActionResult Create()
    {
        return View();
    }

    // POST: Deniks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.LepsiEditor)] 
    public async Task<IActionResult> Create([Bind("Id,Jmeno,Prijmeni,Nazev,Popis,RokVydani,Nakladatelstvi,PocetStran")] Denik denik)
    {
        if (ModelState.IsValid)
        {
            _context.Add(denik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(denik);
    }

    // GET: Deniks/Edit/5
    [Authorize(Roles = UserRoles.Editor + "," + UserRoles.Admin + "," + UserRoles.LepsiEditor)] 
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var denik = await _context.Denik.FindAsync(id);
        if (denik == null)
        {
            return NotFound();
        }
        return View(denik);
    }

    // POST: Deniks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRoles.Editor + "," + UserRoles.Admin + "," + UserRoles.LepsiEditor)] 
    public async Task<IActionResult> Edit(int id, [Bind("Id,Jmeno,Prijmeni,Nazev,Popis,RokVydani,Nakladatelstvi,PocetStran")] Denik denik)
    {
        if (id != denik.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(denik);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenikExists(denik.Id))
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
        return View(denik);
    }

    // GET: Deniks/Delete/5
    [Authorize(Roles = UserRoles.Admin)] 
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var denik = await _context.Denik
            .FirstOrDefaultAsync(m => m.Id == id);
        if (denik == null)
        {
            return NotFound();
        }

        return View(denik);
    }

    // POST: Deniks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var denik = await _context.Denik.FindAsync(id);
        if (denik != null)
        {
            _context.Denik.Remove(denik);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DenikExists(int id)
    {
        return _context.Denik.Any(e => e.Id == id);
    }
}

