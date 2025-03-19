using Challenge_Odontoprev_ADB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Application.Services;
using Challenge_Odontoprev_ADB.Models.Entities;

namespace Challenge_Odontoprev_ADB.Controllers
{
    public class HomeController : Controller
    {
        private readonly _IService<Consulta> _consultaService;
		private readonly _IService<Paciente> _pacienteService;
		private readonly _IService<Dentista> _dentistaService;

		public HomeController(
            _IService<Consulta> consulta,
			_IService<Paciente> paciente,
			_IService<Dentista> dentista
		)
		{
            _consultaService = consulta;
            _pacienteService = paciente;
            _dentistaService = dentista;
        }

        public async Task<IActionResult> Index()
        {
            var consultas = await _consultaService.GetAll();

            var consultaDTOs = consultas.Select(a => new ConsultaReadDTO
            {
                ID = a.ID,
                Data_Consulta = a.Data_Consulta,
                ID_Dentista = a.ID_Dentista,
                ID_Paciente = a.ID_Paciente,
                Status = a.Status
            }).ToList();

			var pacientes = new Dictionary<long, string>();
			var dentistas = new Dictionary<long, string>();

			foreach (var consulta in consultaDTOs)
			{
				if (!pacientes.ContainsKey(consulta.ID_Paciente))
				{
					var paciente = await _pacienteService.GetById(consulta.ID_Paciente);
					pacientes[consulta.ID_Paciente] = paciente?.Nome ?? "Desconhecido";
				}

				if (!dentistas.ContainsKey(consulta.ID_Dentista))
				{
					var dentista = await _dentistaService.GetById(consulta.ID_Dentista);
					dentistas[consulta.ID_Dentista] = dentista?.Nome ?? "Desconhecido";
				}
			}

			// Passando os dicionários para a ViewBag
			ViewBag.Pacientes = pacientes;
			ViewBag.Dentistas = dentistas;

			return View(consultaDTOs);
        }

        public IActionResult About()
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
