using System.ComponentModel.DataAnnotations;

namespace ApiAmbiente1.Entities
{
    public class Ambiente
    {
        public int Id { get; set; }
        [Required]
        public string Piso { get; set; }
        public string Capacidad { get; set; }
        [Required]
        public string Estado { get; set;}

        public List<Novedad> Novedades { get; set; }



    }
}
