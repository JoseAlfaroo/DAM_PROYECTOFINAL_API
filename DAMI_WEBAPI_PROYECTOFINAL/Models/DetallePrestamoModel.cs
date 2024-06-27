using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAMI_WEBAPI_PROYECTOFINAL.Models
{
    public class DetallePrestamoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? DetallePrestamoID { get; set; }

        public int? PrestamoID { get; set; }
        [Required]
        public int? LibroID { get; set; }

        [JsonIgnore]
        public LibroModel? Libro { get; set; }

        [JsonIgnore]
        [ForeignKey("PrestamoID")]
        public PrestamoModel? Prestamo { get; set; }

    }
}
