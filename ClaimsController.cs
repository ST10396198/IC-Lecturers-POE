namespace ContractMonthlyClaimSystem
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.IO;
    using System.Threading.Tasks;



    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Claims/Submit
        public IActionResult Submit()
        {
            return View();
        }

        // POST: Claims/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit([Bind("HoursWorked,HourlyRate,SupportingDocuments")] Claim claim, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (file != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    claim.SupportingDocuments = file.FileName;
                }

                claim.Status = "Pending";
                claim.SubmittedDate = DateTime.Now;

                _context.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to claim list
            }
            return View(claim);
        }

        // List all claims
        public async Task<IActionResult> Index()
        {
            return View(await _context.Claims.Include(c => c.Lecturer).ToListAsync());
        }

        // Approve or Reject a claim
        public async Task<IActionResult> ApproveReject(int? id, string action)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            if (action == "Approve")
                claim.Status = "Approved";
            else if (action == "Reject")
                claim.Status = "Rejected";

            _context.Update(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}
