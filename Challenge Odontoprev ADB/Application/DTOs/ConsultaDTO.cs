﻿namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class ConsultaCreateDTO
{
    public DateTime Data_Consulta { get; set; }
    public long ID_Paciente { get; set; }
    public long ID_Dentista { get; set; }
    public string Status { get; set; }
}

public class ConsultaReadDTO
{
    public long ID_Consulta { get; set; }
    public DateTime Data_Consulta { get; set; }
    public long ID_Paciente { get; set; }
    public long ID_Dentista { get; set; }
    public string Status { get; set; }
}

