using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace lab4t1.Models
{
    public class Jogo
    {
        [Key]
        public int Id { get; set; }
        [InverseProperty("Perfil")]

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Foto { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Display(Name = "Plataforma")]
        public int? PlataformaID { get; set; }

        [ForeignKey("PlataformaID")]
        [InverseProperty("Jogos")]
        public Plataforma? Plataforma { get; set; }

        [Display(Name = "Categoria")]
        public int?  CategoriaID { get; set; }

        [ForeignKey("CategoriaID")]
        [InverseProperty("Jogos")]
        public Categoria? Categoria { get; set; }

        [Display(Name = "Produtora")]
        public int? ProdutoraID { get; set; }

        [ForeignKey("ProdutoraID")]
        [InverseProperty("Jogos")]
        public Produtora? Produtora { get; set; }

        [Display(Name = "Funcionario")]
        public int? FuncionarioID { get; set; }
        [ForeignKey("FuncionarioID")]
        [InverseProperty("Jogos")]
        public Perfil? Perfil { get; set; }
    }

}
