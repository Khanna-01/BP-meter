using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment1.Data;
using assignment1.Models;

namespace assignment1.Controllers
{
    public class BPMeasureController : Controller
    {
        private readonly BPMeasureContext _context;

        public BPMeasureController(BPMeasureContext context)
        {
            _context = context;
        }

        // GET: BPMeasure
   public async Task<IActionResult> Index(string? sort = "desc", string? type = "systolic", string? category = null)
{    ViewData["Category"] = category ?? "";
   
    if (sort == "desc")
        ViewData["Sort"] = "asc";      
    else 
        ViewData["Sort"] = "desc";

    ViewData["SortType"] = type ?? "systolic";
    

  var bpMeasures = await _context.BPMeasureModel.Include(b => b.position).ToListAsync();
    
    var categories = bpMeasures
        .Select(b => b.Category)
        .Where(c => !string.IsNullOrWhiteSpace(c))
        .Distinct()
        .ToList();

if (!string.IsNullOrEmpty(category))
{
    bpMeasures = bpMeasures.Where(b => b.Category == category).ToList();
}
  

    
     switch (type)
    {
        case "systolic":
            bpMeasures = sort == "asc"
                ? bpMeasures.OrderBy(x => x.Systolic).ToList()
                : bpMeasures.OrderByDescending(x => x.Systolic).ToList();
            break;

        case "diastolic":
            bpMeasures = sort == "asc"
                ? bpMeasures.OrderBy(x => x.Category).ToList()
                : bpMeasures.OrderByDescending(x => x.Category).ToList();
            break;

        case "date":
            bpMeasures = sort == "asc"
                ? bpMeasures.OrderBy(x => x.MeasurementDate).ToList()
                : bpMeasures.OrderByDescending(x => x.MeasurementDate).ToList();
            break;

        default:
            break;
    }

   
  
   ViewBag.Categories = categories;
   


    return View(bpMeasures);

}
        // GET: BPMeasure/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.PositionList = new SelectList(await _context.Place.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: BPMeasure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Systolic,Diastolic,MeasurementDate,positionId")] BPMeasureModel bPMeasureModel)
        {
            // Validate position
            if (string.IsNullOrEmpty(bPMeasureModel.positionId))
            {
                ModelState.AddModelError("positionId", "You should specify a position.");
            }
       
            if (ModelState.IsValid)
            {
                _context.Add(bPMeasureModel);
                await _context.SaveChangesAsync();
              TempData["SuccessMessage"] = "Blood pressure measurement saved successfully!";
                return RedirectToAction(nameof(Index));
            }

    
            ViewBag.PositionList = new SelectList(await _context.Place.ToListAsync(), "Id", "Name");
            return View(bPMeasureModel);
        }

        // GET: BPMeasure/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasureModel = await _context.BPMeasureModel.FindAsync(id);
            if (bPMeasureModel == null)
            {
                return NotFound();
            }

            ViewBag.PositionList = new SelectList(await _context.Place.ToListAsync(), "Id", "Name", bPMeasureModel.position?.Id);
            return View(bPMeasureModel);
        }

        // POST: BPMeasure/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Systolic,Diastolic,MeasurementDate,positionId")] BPMeasureModel bPMeasureModel)
        {
            if (id != bPMeasureModel.Id)
            {
                return NotFound();
            }

            // Validate position
            if (string.IsNullOrEmpty(bPMeasureModel.positionId))
            {
                ModelState.AddModelError("positionId", "You should specify a position.");
            }
            else
            {
                bPMeasureModel.position = await _context.Place.FindAsync(bPMeasureModel.positionId);
                if (bPMeasureModel.position == null)
                {
                    ModelState.AddModelError("positionId", "Selected position does not exist.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bPMeasureModel);
                    await _context.SaveChangesAsync();
                 TempData["SuccessMessage"] = "Blood pressure measurement updated successfully!";
        }
        
                
                catch (DbUpdateConcurrencyException)
                {
                    if (!BPMeasureModelExists(bPMeasureModel.Id))
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

            // Repopulate the Position list on error
            ViewBag.PositionList = new SelectList(await _context.Place.ToListAsync(), "Id", "Name", bPMeasureModel.positionId);
            return View(bPMeasureModel);
        }

        // GET: BPMeasure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasureModel = await _context.BPMeasureModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bPMeasureModel == null)
            {
                return NotFound();
            }

            return View(bPMeasureModel);
        }

        // POST: BPMeasure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bPMeasureModel = await _context.BPMeasureModel.FindAsync(id);
            if (bPMeasureModel != null)
            {
                _context.BPMeasureModel.Remove(bPMeasureModel);
            }

            await _context.SaveChangesAsync();
             TempData["SuccessMessage"] = "Blood pressure measurement deleted successfully!";
            return RedirectToAction(nameof(Index));

        }

        private bool BPMeasureModelExists(int id)
        {
            return _context.BPMeasureModel.Any(e => e.Id == id);
        }
    }
}
