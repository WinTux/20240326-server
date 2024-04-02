using System.ComponentModel.DataAnnotations;

namespace _20240326_server.Models
{
    public class Plato
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
