using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lab4t1.Models
{
    public class Perfil
    {
        public Perfil()
        {
            Jogos= new HashSet<Jogo>();
            Plataformas = new HashSet<Plataforma>();
            Categorias = new HashSet<Categoria>();
        }
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }
        [InverseProperty("Perfil")]
        [Required]
        public string UserName { get; set; }

        [InverseProperty("Perfil")]
        public virtual ICollection<Jogo> Jogos { get; set; }

        public virtual ICollection<Plataforma> Plataformas { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }

    }
}
