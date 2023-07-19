using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4t1.Models
{
    public class Compras
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserID")]

        public Perfil? User { get; set; }

        [ForeignKey("JogoID")]

        public Jogo? Jogo { get; set; }

    }
}
