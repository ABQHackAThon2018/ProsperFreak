using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApp.Data;
using CoreApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreApp.Controllers
{
    [Authorize]
    public class ApplicantModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicantModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicantModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicantModel.ToListAsync());
        }

        // GET: ApplicantModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.ApplicantModel
                .SingleOrDefaultAsync(m => m.PersonID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            return View(applicantModel);
        }

        // GET: ApplicantModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicantModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobID,Landscaping,Housework,Construction,Foodprep,AutoMechanic,CustomerService,Administrative,AvailableNow,StartTime,EndTime,ID,LastName,FirstName,PhoneNumber,Email")] ApplicantModel applicantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicantModel);
        }

        // GET: ApplicantModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.ApplicantModel.SingleOrDefaultAsync(m => m.PersonID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }
            return View(applicantModel);
        }

        // POST: ApplicantModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobID,Landscaping,Housework,Construction,Foodprep,AutoMechanic,CustomerService,Administrative,AvailableNow,StartTime,EndTime,ID,LastName,FirstName,PhoneNumber,Email")] ApplicantModel applicantModel)
        {
            if (id != applicantModel.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantModelExists(applicantModel.PersonID))
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
            return View(applicantModel);
        }

        // GET: ApplicantModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.ApplicantModel
                .SingleOrDefaultAsync(m => m.PersonID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            return View(applicantModel);
        }

        // POST: ApplicantModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicantModel = await _context.ApplicantModel.SingleOrDefaultAsync(m => m.PersonID == id);
            _context.ApplicantModel.Remove(applicantModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantModelExists(int id)
        {
            return _context.ApplicantModel.Any(e => e.PersonID == id);
        }
    }
}
