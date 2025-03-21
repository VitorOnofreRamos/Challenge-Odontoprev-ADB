using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Models;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly _IRepository<Consulta> _consultaService;
		private readonly _IRepository<Paciente> _pacienteService;
		private readonly _IRepository<Dentista> _dentistaService;

        public HomeController(ILogger<HomeController> logger, _IRepository<Consulta> consultaService, _IRepository<Paciente> pacienteService, _IRepository<Dentista> dentistaService)
        {
            _logger = logger;
            _consultaService = consultaService;
            _pacienteService = pacienteService;
            _dentistaService = dentistaService;
        }

        public async Task<IActionResult> Index()
		{
			var consultas = await _consultaService.GetAll();

			var consultasDTO = consultas.Select(a => new ConsultaReadDTO 
			{ 
				ID_Consulta = a.Id,
				Data_Consulta = a.Data_Consulta,
				ID_Paciente = a.ID_Paciente,
				ID_Dentista = a.ID_Dentista,
				Status = a.Status,
			}).ToList();

            var pacientesList = await _pacienteService.GetAll();
            var dentistasList = await _dentistaService.GetAll();
            ViewBag.Pacientes = pacientesList.ToDictionary(p => p.Id, p => p.Nome);
            ViewBag.Dentistas = dentistasList.ToDictionary(d => d.Id, d => d.Nome);

            return View(consultasDTO);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
