using AutoMapper;
using Challenge_Odontoprev_ADB.Application.DTOs;
using Challenge_Odontoprev_ADB.Models.Entities;

namespace Challenge_Odontoprev_ADB.Mappings;

public class AutoMapperProfile : Profile 
{
    public AutoMapperProfile()
    {
        CreateMap<Paciente, PacienteReadDTO>();
        CreateMap<PacienteCreateDTO, Paciente>();

        CreateMap<Dentista, DentistaReadDTO>();
        CreateMap<DentistaCreateDTO, Dentista>();

        CreateMap<Consulta, ConsultaReadDTO>();
        CreateMap<ConsultaCreateDTO, Consulta>();

        CreateMap<HistoricoConsulta, HistoricoConsultaReadDTO>();
        CreateMap<HistoricoConsultaCreateDTO, HistoricoConsulta>();
    }
}
