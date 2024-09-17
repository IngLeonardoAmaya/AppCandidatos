using AppCandidatos.Data;
using AppCandidatos.Models;
using AppCandidatos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCandidatos.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar candidatos
        public async Task<IActionResult> Index()
        {
            var candidates = await _context.Candidates
                .Include(c => c.CandidateExperiences)
                .ToListAsync();
            return View(candidates);
        }

        // Crear candidato (GET)
        public IActionResult Create()
        {
            var viewModel = new CandidateViewModel
            {
                CandidateExperiences = new List<CandidateExperienceViewModel> { new CandidateExperienceViewModel() }
            };
            return View(viewModel);
        }

        // Crear candidato (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var candidate = new Candidate
                {
                    Name = viewModel.Name,
                    Surname = viewModel.Surname,
                    Birthdate = viewModel.Birthdate,
                    Email = viewModel.Email,
                    InsertDate = DateTime.Now,
                    CandidateExperiences = viewModel.CandidateExperiences.Select(e => new CandidateExperience
                    {
                        Company = e.Company,
                        Job = e.Job,
                        Description = e.Description == null ? "" : e.Description,
                        Salary = e.Salary,
                        BeginDate = e.BeginDate,
                        EndDate = e.EndDate,
                        InsertDate = DateTime.Now

                    
                    }).ToList()
                };

                _context.Add(candidate);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Candidato creado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel); 
        }

        // Editar candidato (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var candidate = await _context.Candidates
                .Include(c => c.CandidateExperiences)
                .FirstOrDefaultAsync(c => c.IdCandidate == id);

            if (candidate == null)
            {
                return NotFound();
            }

            var viewModel = new CandidateViewModel
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthdate = candidate.Birthdate,
                Email = candidate.Email,
                CandidateExperiences = candidate.CandidateExperiences.Select(e => new CandidateExperienceViewModel
                {
                    IdCandidateExperience = e.IdCandidateExperience,
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate
                }).ToList()
            };

            return View(viewModel); 
        }

        // Editar candidato (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CandidateViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var candidate = await _context.Candidates
                    .Include(c => c.CandidateExperiences)
                    .FirstOrDefaultAsync(c => c.IdCandidate == id);

                if (candidate == null)
                {
                    return NotFound();
                }

                // Actualizamos los datos del candidato
                candidate.Name = viewModel.Name;
                candidate.Surname = viewModel.Surname;
                candidate.Birthdate = viewModel.Birthdate;
                candidate.Email = viewModel.Email;
                candidate.ModifyDate = DateTime.Now;

                // Actualizamos las experiencias del candidato
                candidate.CandidateExperiences.Clear();
                candidate.CandidateExperiences = viewModel.CandidateExperiences.Select(e => new CandidateExperience
                {
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description == null ? "" : e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate,
                    InsertDate = DateTime.Now
                }).ToList();

                _context.Update(candidate);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Candidato editado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel); 
        }

        // Eliminar candidato
        public async Task<IActionResult> Delete(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Candidato eliminado exitosamente";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(c => c.IdCandidate == id);
        }
    }
}
