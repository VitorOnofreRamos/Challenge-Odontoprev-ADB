﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("CONSULTA")]
public class Consulta : _BaseEntity
{
    [Key]
    [Column("ID_CONSULTA")]
    public override long ID { get; set; }

    [Required]
    [Column("DATA_CONSULTA")]
    public DateTime Data_Consulta { get; set; }

    [Required]
    [ForeignKey("ID_PACIENTE")]
    [Column("ID_PACIENTE")]
    public long ID_Paciente { get; set; }

    [Required]
    [ForeignKey("DENTISTA")]
    [Column("ID_DENTISTA")]
    public long ID_Dentista { get; set; }

    [Required]
    [StringLength(50)]
    [Column("STATUS")]
    public string Status { get; set; }

    // Navegação
    public Paciente Paciente { get; set; }
    public Dentista Dentista { get; set; }
    public ICollection<HistoricoConsulta> Historicos { get; set; }
}
