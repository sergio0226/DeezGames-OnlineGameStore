using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab4t1.Models
{
    public class Plataforma
    {
        public Plataforma()
        {
            Jogos = new HashSet<Jogo>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [InverseProperty("Plataforma")]
        public virtual ICollection<Jogo> Jogos { get; set; }

    }
}
