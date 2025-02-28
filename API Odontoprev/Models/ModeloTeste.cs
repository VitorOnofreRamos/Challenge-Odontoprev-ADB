using System.ComponentModel.DataAnnotations;

namespace API_Odontoprev.Models
{
	public class ModeloTeste
	{
		[Key]
		public int Id { get; set; }
		public string Name {  get; set; }
		public bool Complete { get; set; }
	}
}
