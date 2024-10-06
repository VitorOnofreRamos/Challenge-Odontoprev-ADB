﻿using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Implementations;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class DoctorService
{
    private readonly DoctorRepository _doctorRepository;

    public DoctorService(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id) =>
        await _doctorRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync() =>
        await _doctorRepository.GetAllAsync();

    public async Task AddDoctorAsync(Doctor doctor) =>
        await _doctorRepository.AddAsync(doctor);

    public async Task UpdateDoctorAsync(Doctor doctor) =>
        await _doctorRepository.UpdateAsync(doctor);

    public async Task RemoveDoctorAsync(int id) =>
        await _doctorRepository.RemoveAsync(id);
}
