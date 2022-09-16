using System.ComponentModel.DataAnnotations;

namespace OptiRest.Data.Models
{
    public class Plato
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public double Precio { get; set; }
    }
}
