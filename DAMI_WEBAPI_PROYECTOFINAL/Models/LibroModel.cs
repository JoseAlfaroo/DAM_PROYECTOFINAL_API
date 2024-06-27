using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAMI_WEBAPI_PROYECTOFINAL.Models
{
    public class LibroModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? LibroID { get; set; }
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Autor { get; set; }
        [Required]
        public string? Genero { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Imagen { get; set; }

        [JsonIgnore]
        public ICollection<DetallePrestamoModel>? DetallesPrestamos { get; set; }
    }
}
