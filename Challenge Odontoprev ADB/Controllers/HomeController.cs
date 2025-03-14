using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Application.Services;

namespace Challenge_Odontoprev_ADB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConsultaService consultaService;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ConsultaService _consultaService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            consultaService = _consultaService;
        }

        public async Task<IActionResult> Index()
        {
            var majorConsulta = await consultaService.GetAllConsultasAsync();

            var majorConsultaDTOs = majorConsulta.Select(a => new ConsultaDTO
            {
                Id = a.Id,
                Data_Consulta = a.Data_Consulta,
                ID_Dentista = a.ID_Dentista,
                ID_Paciente = a.ID_Paciente,
                Status = a.Status
            }).ToList();

            return View(majorConsultaDTOs);
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
