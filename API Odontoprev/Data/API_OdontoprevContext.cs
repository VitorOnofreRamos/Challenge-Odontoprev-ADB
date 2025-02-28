using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Odontoprev.Models;

namespace API_Odontoprev.Data
{
    public class API_OdontoprevContext : DbContext
    {
        public API_OdontoprevContext (DbContextOptions<API_OdontoprevContext> options)
            : base(options)
        {
        }

        public DbSet<API_Odontoprev.Models.ModeloTeste> ModeloTeste { get; set; } = default!;
    }
}
