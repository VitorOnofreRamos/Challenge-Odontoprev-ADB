using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Odontoprev_ADB.Controllers
{
    [Route("Appointment")]
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

            var appointmentsDTOs = appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                Status = a.Status,
                Address_Street = a.Address_Street,
                Address_City = a.Address_City,
                Address_State = a.Address_State,
                AppointmentDate = a.AppointmentDate,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                TreatmentsId = a.Treatments.Select(t => t.Id).ToList(),
                AppointmentReason = a.AppointmentReason
            }).ToList();

            return View(appointmentsDTOs); //View para listar todos os appointments
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
            var dto = new AppointmentDTO
            {
                Id = appointment.Id,
                Status = appointment.Status,
                Address_Street = appointment.Address_Street,
                Address_City = appointment.Address_City,
                Address_State = appointment.Address_State,
                AppointmentDate = appointment.AppointmentDate,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                TreatmentsId = appointment.Treatments.Select(t => t.Id).ToList(),
                AppointmentReason = appointment.AppointmentReason
            };
            return View(dto); // Passando AppointmentDTO para a View
        }

        // GET: /appointment/create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /appointments/create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentDTO dto)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    Status = dto.Status,
                    Address_Street = dto.Address_Street,
                    Address_City = dto.Address_City,
                    Address_State = dto.Address_State,
                    AppointmentDate = dto.AppointmentDate,
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    AppointmentReason = dto.AppointmentReason,
                    Treatments = dto.TreatmentsId.Select(id => new Treatment { Id = id }).ToList()
                };

                await _unitOfWork.Appointment.AddAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: /appointments/delete/{id}
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _unitOfWork.Appointment.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(new AppointmentDTO { Id = appointment.Id}); // View para confirmar a exclusão
        }

        // POST: /appointments/delete/{id}
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Appointment.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
