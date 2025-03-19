using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public abstract class _BaseEntity
{
    public virtual long ID { get; set; }
}
