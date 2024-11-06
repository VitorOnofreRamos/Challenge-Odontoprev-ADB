using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Application.Services;
using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Odontoprev_ADB.Controllers
{
    [Route("Appointment")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppointmentService _appointmentService;
        private readonly PatientService _patientService;
        private readonly DoctorService _doctorService;
        private readonly TreatmentService _treatmentService;

        public AppointmentController(IUnitOfWork unitOfWork, AppointmentService appointmentService, PatientService patientService, DoctorService doctorService, TreatmentService treatmentService)
        {
            _unitOfWork = unitOfWork;
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _treatmentService = treatmentService;
        }

        // GET: /appointments
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

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
                TreatmentId = a.TreatmentId,
                AppointmentReason = a.AppointmentReason
            }).ToList();

            return View(appointmentsDTOs); //View para listar todos os appointments
        }

        // GET: /appointments/details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
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
                TreatmentId = appointment.TreatmentId,
                AppointmentReason = appointment.AppointmentReason
            };
            return View(dto); // Passando AppointmentDTO para a View
        }

        // GET: /appointment/create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var treatments =  await _treatmentService.GetAllTreatmentsAsync();

            // Adicione um log para verificar os pacientes, médicos e tratamentos
            Console.WriteLine($"Patients Count: {patients.Count()}, Doctors Count: {doctors.Count()}, Treatments Count: {treatments.Count()}");

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;
            ViewBag.Treatments = treatments;

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
                    TreatmentId = dto.TreatmentId,
                    AppointmentReason = dto.AppointmentReason
                };

                // Adicione logs para verificar os dados do agendamento
                Console.WriteLine($"Creating Appointment: {dto.AppointmentReason}, PatientId: {dto.PatientId}, DoctorId: {dto.DoctorId}, TreatmentId: {dto.TreatmentId}");

                await _appointmentService.AddAppointmentAsync(appointment);
                return RedirectToAction("Index", "Home");
            }

            // Se o ModelState não for válido, logue os erros
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine($"Model Error: {error.ErrorMessage}");
                }
            }

            // Se voltar para a view, também recarregue os dados
            var patients = await _patientService.GetAllPatientsAsync();
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;
            ViewBag.Treatmens = treatments;

            return View(dto);
        }

        // GET: /appointments/delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(new AppointmentDTO { Id = appointment.Id}); // View para confirmar a exclusão
        }

        // Delete: /appointments/delete/{id}
        [HttpDelete("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.RemoveAppointmentAsync(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
