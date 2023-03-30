using System.ComponentModel.DataAnnotations;

namespace ApiAmbiente1.Entities
{
    public class Novedad
    {
        public int Id { get; set; }
        [Required]

        public string Descripcion { get; set; }
        [Required]
        public string Tema { get; set; }
        [Required]
        public int AmbienteId { get; set; }
        public Ambiente Ambiente { get; set; }

    }
}

