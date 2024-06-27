using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAMI_WEBAPI_PROYECTOFINAL.Models
{
    public class PrestamoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PrestamoID { get; set; }
        [Required]
        public int? UserID { get; set; }
        public DateTime? FechaPrestamo { get; set; }

        public ICollection<DetallePrestamoModel>? DetallesPrestamos { get; set; }
    }
}
