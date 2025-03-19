﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("HISTORICO_CONSULTA")]
public class HistoricoConsulta : _BaseEntity
{
    [Key]
    [Column("ID_HISTORICO")]
    public override long ID { get; set; }

    [Required]
    [ForeignKey("ID_CONSULTA")]
    [Column("ID_CONSULTA")]
    public long ID_Consulta { get; set; }

    [Required]
    [Column("DATA_ATENDIMENTO")]
    public DateTime Data_Atendimento { get; set; }

    [Required]
    [StringLength(300)]
    [Column("MOTIVO_CONSULTA")]
    public string Motivo_Consulta { get; set; }

    [StringLength(300)]
    [Column("OBSERVACOES")]
    public string Observacoes { get; set; }

    // Navegação
    public Consulta Consulta { get; set; }
}