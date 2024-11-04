using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Odontoprev_ADB.Controllers
{
    [Route("appointments")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public  AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /appointments
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var appointments = await _unitOfWork.Appointment.GetAllAsync();
            return View(appointments); //View para listar todos os appointments
        }

        // GET: /appointments/details/{id}
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _unitOfWork.Appointment.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment); //View para ver detalhes de um appointment
        }

        // GET: /appointment/create
        [HttpGet("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /appointments/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Appointment.AddAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: /appointments/delete/1
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _unitOfWork.Appointment.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment); // View para confirmar a exclusão
        }

        // POST: /appointments/delete/1
        [HttpDelete("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Appointment.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
