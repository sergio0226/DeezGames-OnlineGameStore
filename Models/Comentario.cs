using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4t1.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Classificacao { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        //[InverseProperty("Comentarios")]
        public Perfil? User { get; set; }

        [Required]
        public int JogoID { get; set;}

        [ForeignKey("JogoID")]
        //[InverseProperty("Comentarios")]
        public Jogo? Jogo { get; set; }



    }
}
