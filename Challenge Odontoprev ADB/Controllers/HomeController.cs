using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Application.Services;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories;
using AutoMapper;

namespace Challenge_Odontoprev_ADB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly _IService<Consulta> _service;

        public HomeController(
            ILogger<HomeController> logger, 
            IUnitOfWork unitOfWork, 
            _IService<Consulta> service
        ){
            _logger = logger;
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var majorConsulta = await _service.GetAll();

            var majorConsultaDTOs = majorConsulta.Select(a => new ConsultaReadDTO
            {
                ID = a.ID,
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
