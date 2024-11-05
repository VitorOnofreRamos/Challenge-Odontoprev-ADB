using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models;
using Challenge_Odontoprev_ADB.Repositories.Implementations;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Challenge_Odontoprev_ADB.Application.DTOs;

namespace Challenge_Odontoprev_ADB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var majorAppointments = await _unitOfWork.Appointment.GetAllAsync();

            var majorAppointmentsDTOs = majorAppointments.Select(a => new AppointmentDTO
            {
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

            return View(majorAppointmentsDTOs);
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
