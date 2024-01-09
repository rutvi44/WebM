using Microsoft.AspNetCore.Mvc;
using MidTerm.Entities;
using MidTerm.Models;

namespace MidTerm.Controllers
{
    public class TimesheetsController : Controller
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public TimesheetsController(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }


        [HttpGet("/timesheets")]
        public IActionResult List()
        {
            var allTimesheets = _timesheetDbContext.Timesheets.ToList();

            var allsortedTimesheets = allTimesheets.OrderByDescending(timesheet => timesheet.ProjectDate).ToList();

            var timeSheetViewModel = new TimesheetsViewModel()
            {
                Timesheets = allsortedTimesheets
            };

            return View(timeSheetViewModel);
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            var timeSheetViewModel = new TimesheetViewModel()
            {
                ActiveTimesheet = new Timesheet(),

            };
            return View(timeSheetViewModel);
        }

        [HttpPost("/add")]
        public IActionResult Add(TimesheetViewModel TimeSheetViewModel)
        {
            if (ModelState.IsValid)
            {
                _timesheetDbContext.Timesheets.Add(TimeSheetViewModel.ActiveTimesheet);
                _timesheetDbContext.SaveChanges();

                TempData["notify"] = $"{TimeSheetViewModel.ActiveTimesheet.ProjectName} added...!";
                TempData["class"] = "success";

                return RedirectToAction("List", "Timesheets");
            }
            else
            {
                return View(TimeSheetViewModel);
            }
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var timesheet = _timesheetDbContext.Timesheets.Find(id);
            if (timesheet == null)
            {

                return NotFound();
            }

            var TimeSheetViewModel= new TimesheetViewModel()
            {
                ActiveTimesheet = timesheet,
            };

            return View(TimeSheetViewModel);
        }

        [HttpPost("/edit/{id?}")]
        public IActionResult Edit(TimesheetViewModel TimeSheetViewModel)
        {
            if (ModelState.IsValid)
            {
                _timesheetDbContext.Timesheets.Update(TimeSheetViewModel.ActiveTimesheet);
                _timesheetDbContext.SaveChanges();

                TempData["notify"] = $"{TimeSheetViewModel.ActiveTimesheet.ProjectName} updated!";
                TempData["class"] = "info";

                return RedirectToAction("List", "Timesheets");
            }
            else
            {
                return View(TimeSheetViewModel);
            }
        }

        [HttpGet("/details/{id?}")]
        public IActionResult Details(int id)
        {
            var timeSheet = _timesheetDbContext.Timesheets.FirstOrDefault(m => m.ProjectId == id);

            if (timeSheet == null)
            {
                return NotFound();
            }

            var timeSheetViewModel = new TimesheetViewModel
            {
                ActiveTimesheet = timeSheet
            };

            return View(timeSheetViewModel);
        }
    }
}
