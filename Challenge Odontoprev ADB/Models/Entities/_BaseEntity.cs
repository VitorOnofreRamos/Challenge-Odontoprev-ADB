using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public abstract class _BaseEntity
{
    [Key] 
    public virtual long Id { get; set; }
}
