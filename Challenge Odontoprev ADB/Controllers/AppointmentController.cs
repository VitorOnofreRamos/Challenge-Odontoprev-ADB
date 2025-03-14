using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Application.Services;
using Challenge_Odontoprev_ADB.Views.ViewModels;
using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Odontoprev_ADB.Controllers
{
    [Route("Appointment")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConsultaService _consultaService;
        private readonly PacienteService _patientService;
        private readonly DentistaService _dentistaService;
        private readonly HistoricoService _historicoService;

		public AppointmentController(
            IUnitOfWork unitOfWork, 
            ConsultaService consultaService, 
            PacienteService patientService, 
            DentistaService dentistaService, 
            HistoricoService historicoService
        ){
			_unitOfWork = unitOfWork;
			_consultaService = consultaService;
			_patientService = patientService;
			_dentistaService = dentistaService;
			_historicoService = historicoService;
		}



		// GET: /appointments
		[HttpGet]
        public async Task<IActionResult> Index() 
        {
            var consultas = await _consultaService.GetAllConsultasAsync();

            var appointmentsDTOs = consultas.Select(a => new ConsultaDTO
            {
				Id = a.Id,
				Data_Consulta = a.Data_Consulta,
				ID_Dentista = a.ID_Dentista,
				ID_Paciente = a.ID_Paciente,
				Status = a.Status
			}).ToList();

            return View(appointmentsDTOs); //View para listar todos os appointments
        }

        // GET: /appointments/details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            var dentista = await _dentistaService.GetDentistaByIdAsync(consulta.ID_Dentista);
            var paciente = await _patientService.GetPacienteByIdAsync(consulta.ID_Paciente);
            var historico = await _historicoService.GetHistoricoByIdAsync(consulta.HistoricoId);

            var viewModel = new AppointmentViewModel
            {
                ID_Consulta = consulta.Id,
                Data_Consulta = consulta.Data_Consulta,
                Status = consulta.Status,
                ID_Paciente = paciente.Id,
                Nome_Paciente = paciente.Nome
            }

            return View(viewModel);
        }

        // GET: /appointment/create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            var doctors = await _dentistaService.GetAllDoctorsAsync();
            var treatments =  await _historicoService.GetAllTreatmentsAsync();

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
        public async Task<IActionResult> Create(ConsultaDTO dto)
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
                return Redirect("~/");
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
            var doctors = await _dentistaService.GetAllDoctorsAsync();
            var treatments = await _historicoService.GetAllTreatmentsAsync();

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;
            ViewBag.Treatments = treatments;

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
            return View(new ConsultaDTO { Id = appointment.Id}); // View para confirmar a exclusão
        }

        // Delete: /appointments/delete/{id}
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.RemoveAppointmentAsync(id);
            return Redirect("~/");
        }

        // GET: /appointments/edit/{id}
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var dto = new ConsultaDTO
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

            var patients = await _patientService.GetAllPatientsAsync();
            var doctors = await _dentistaService.GetAllDoctorsAsync();
            var treatments = await _historicoService.GetAllTreatmentsAsync();

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;
            ViewBag.Treatments = treatments;

            return View(dto);
        }

        // Post: /appointments/edit/{id}
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConsultaDTO dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                // Atualiza os dados do agendamento
                appointment.AppointmentDate = dto.AppointmentDate;
                appointment.Address_Street = dto.Address_Street;
                appointment.Address_City = dto.Address_City;
                appointment.Address_State = dto.Address_State;
                appointment.AppointmentReason = dto.AppointmentReason;
                appointment.Status = dto.Status;
                appointment.PatientId = dto.PatientId;
                appointment.DoctorId = dto.DoctorId;
                appointment.TreatmentId = dto.TreatmentId;

                // Salva as mudanças
                await _appointmentService.UpdateAppointmentAsync(appointment);

                return Redirect("~/"); // Redireciona para a lista de agendamentos
            }

            // Caso o ModelState não seja válido, recarregue os dados e mostre o erro
            var patients = await _patientService.GetAllPatientsAsync();
            var doctors = await _dentistaService.GetAllDoctorsAsync();
            var treatments = await _historicoService.GetAllTreatmentsAsync();

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;
            ViewBag.Treatments = treatments;

            return View(dto); // Retorna a mesma View com os erros
        }
    }
}
