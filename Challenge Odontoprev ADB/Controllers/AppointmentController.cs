using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Views.ViewModels;
using Challenge_Odontoprev_ADB.Infraestructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Controllers
{
    [Route("Appointment")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly _IRepository<Consulta> _consultaService;
        private readonly _IRepository<Paciente> _pacienteService;
        private readonly _IRepository<Dentista> _dentistaService;
        private readonly _IRepository<HistoricoConsulta> _serviceHistorico;

        public AppointmentController(IUnitOfWork unitOfWork, _IRepository<Consulta> consultaService, _IRepository<Paciente> pacienteService, _IRepository<Dentista> dentistaService, _IRepository<HistoricoConsulta> serviceHistorico)
        {
            _unitOfWork = unitOfWork;
            _consultaService = consultaService;
            _pacienteService = pacienteService;
            _dentistaService = dentistaService;
            _serviceHistorico = serviceHistorico;
        }

        // GET: /appointments
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var consultas = await _consultaService.GetAll();

            var appointmentsDTOs = consultas.Select(a => new ConsultaReadDTO
            {
                ID_Consulta = a.Id,
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
            var consulta = await _consultaService.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteService.GetById(consulta.ID_Paciente);
            var dentista = await _dentistaService.GetById(consulta.ID_Dentista);

            var viewModel = new AppointmentViewModel
            {
                ID_Consulta = consulta.Id,
                Data_Consulta = consulta.Data_Consulta,
                Status = consulta.Status,

                ID_Paciente = paciente.Id,
                Nome_Paciente = paciente.Nome,
                Data_Nascimento = paciente.Data_Nascimento,
                CPF = paciente.CPF,
                Endereco = paciente.Endereco,
                Telefone_Paciente = paciente.Telefone,
                Carteirinha = paciente.Carteirinha,

                ID_Dentista = dentista.Id,
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
            var pacientes = await _pacienteService.GetAll();
            var dentistas = await _dentistaService.GetAll();;

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

                await _consultaService.Insert(consulta);
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
            var pacientes = await _pacienteService.GetAll();
            var dentistas = await _dentistaService.GetAll();
            ViewBag.Pacientes = pacientes;
            ViewBag.Dentistas = dentistas;

            return View(dto);
        }

        // GET: /appointments/delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _consultaService.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(new ConsultaReadDTO { ID_Consulta = consulta.Id}); // View para confirmar a exclusão
        }

        // Delete: /appointments/delete/{id}
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consultaService.Delete(id);
            return Redirect("~/");
        }

        // GET: /appointments/edit/{id}
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var consulta = await _consultaService.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }

            var dto = new ConsultaReadDTO
            {
                ID_Consulta = consulta.Id,
                Data_Consulta = consulta.Data_Consulta,
                ID_Paciente = consulta.ID_Paciente,
                ID_Dentista = consulta.ID_Dentista
            };

            // Retrieve patients and dentists and ensure non-null lists
            var pacientes = await _pacienteService.GetAll() ?? new List<Paciente>();
            var dentistas = await _dentistaService.GetAll() ?? new List<Dentista>();

            ViewBag.Pacientes = pacientes;
            ViewBag.Dentistas = dentistas;

            return View(dto);
        }

        // Post: /appointments/edit/{id}
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConsultaReadDTO dto)
        {
            if (id != dto.ID_Consulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var consulta = await _consultaService.GetById(id);
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
                await _consultaService.Update(consulta);

                return Redirect("~/"); // Redireciona para a lista de agendamentos
            }

            // Caso o ModelState não seja válido, recarregue os dados e mostre o erro
            var pacientes = await _pacienteService.GetAll();
            var dentistas = await _dentistaService.GetAll();
            ViewBag.Pacientes = pacientes;
            ViewBag.Dentistas = dentistas;

            return View(dto); // Retorna a mesma View com os erros
        }
    }
}
