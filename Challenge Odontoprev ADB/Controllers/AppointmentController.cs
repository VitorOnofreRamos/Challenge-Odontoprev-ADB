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
        private readonly _IService<Paciente> _servicePaciente;
        private readonly _IService<Dentista> _serviceDentista;
        private readonly _IService<Consulta> _serviceConsulta;
        private readonly _IService<HistoricoConsulta> _serviceHistorico;

        public AppointmentController(
            IUnitOfWork unitOfWork, 
            _IService<Paciente> servicePaciente, 
            _IService<Dentista> serviceDentista, 
            _IService<Consulta> serviceConsulta, 
            _IService<HistoricoConsulta> serviceHistorico
        ){
            _unitOfWork = unitOfWork;
            _servicePaciente = servicePaciente;
            _serviceDentista = serviceDentista;
            _serviceConsulta = serviceConsulta;
            _serviceHistorico = serviceHistorico;
        }

        // GET: /appointments
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var consultas = await _serviceConsulta.GetAll();

            var appointmentsDTOs = consultas.Select(a => new ConsultaReadDTO
            {
                ID = a.ID,
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
            var consulta = await _serviceConsulta.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }

            var paciente = await _servicePaciente.GetById(consulta.ID_Paciente);
            var dentista = await _serviceDentista.GetById(consulta.ID_Dentista);

            var viewModel = new AppointmentViewModel
            {
                ID_Consulta = consulta.ID,
                Data_Consulta = consulta.Data_Consulta,
                Status = consulta.Status,

                ID_Paciente = paciente.ID,
                Nome_Paciente = paciente.Nome,
                Data_Nascimento = paciente.Data_Nascimento,
                CPF = paciente.CPF,
                Endereco = paciente.Endereco,
                Telefone_Paciente = paciente.Telefone,
                Carteirinha = paciente.Carteirinha,

                ID_Dentista = dentista.ID,
                Nome_Dentista = dentista.Nome,
                CRO = dentista.CRO,
                Especialidade = dentista.Especialidade,
                Telefone_Dentista= dentista.Telefone
            };

            return View(viewModel);
        }

        // GET: /appointment/create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var pacientes = await _servicePaciente.GetAll();
            var dentistas = await _serviceDentista.GetAll();;

            // Adicione um log para verificar os pacientes, médicos e tratamentos
            Console.WriteLine($"Pacientes: {pacientes.Count()}, Dentistas: {dentistas.Count()}");

            ViewBag.Patients = pacientes;
            ViewBag.Doctors = dentistas;

            return View();
        }

        // POST: /appointments/create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsultaCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var consulta = new Consulta
                {
                    Data_Consulta = dto.Data_Consulta,
                    Status = dto.Status,
                    ID_Paciente = dto.ID_Paciente,
                    ID_Dentista = dto.ID_Dentista
                };

                // Adicione logs para verificar os dados do agendamento
                Console.WriteLine($"Criando Consulta ->\nData da Consulta: {dto.Data_Consulta}, Status da Consulta: {dto.Status}, ID do Paciente: {dto.ID_Paciente}, ID do Dentista: {dto.ID_Dentista}");

                await _serviceConsulta.Insert(consulta);
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
            var pacientes = await _servicePaciente.GetAll();
            var dentistas = await _serviceDentista.GetAll();

            ViewBag.Patients = pacientes;
            ViewBag.Doctors = dentistas;

            return View(dto);
        }

        // GET: /appointments/delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _serviceConsulta.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(new ConsultaReadDTO { ID = consulta.ID}); // View para confirmar a exclusão
        }

        // Delete: /appointments/delete/{id}
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceConsulta.Delete(id);
            return Redirect("~/");
        }

        // GET: /appointments/edit/{id}
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var consulta = await _serviceConsulta.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }

            var dto = new ConsultaReadDTO
            {
                ID = consulta.ID,
                Data_Consulta = consulta.Data_Consulta,
                ID_Paciente = consulta.ID_Paciente,
                ID_Dentista = consulta.ID_Dentista
            };

            var pacientes = await _servicePaciente.GetAll();
            var dentistas = await _serviceDentista.GetAll();

            ViewBag.Patients = pacientes;
            ViewBag.Doctors = dentistas;

            return View(dto);
        }

        // Post: /appointments/edit/{id}
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConsultaReadDTO dto)
        {
            if (id != dto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var consulta = await _serviceConsulta.GetById(id);
                if (consulta == null)
                {
                    return NotFound();
                }

                // Atualiza os dados do agendamento
                consulta.Data_Consulta = dto.Data_Consulta;
                consulta.Status = dto.Status;
                consulta.ID_Paciente = dto.ID_Paciente;
                consulta.ID_Dentista = dto.ID_Dentista;

                // Salva as mudanças
                await _serviceConsulta.Update(consulta);

                return Redirect("~/"); // Redireciona para a lista de agendamentos
            }

            // Caso o ModelState não seja válido, recarregue os dados e mostre o erro
            var pacientes = await _servicePaciente.GetAll();
            var dentistas = await _serviceDentista.GetAll();

            ViewBag.Patients = pacientes;
            ViewBag.Doctors = dentistas;

            return View(dto); // Retorna a mesma View com os erros
        }
    }
}
