using lab4t1.Models;

namespace lab4t1.Data
{
    public class DBInitializer
    {
        private readonly ApplicationDbContext _dbcontext;
        public DBInitializer(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }   

        public void Run()
        {
            _dbcontext.Database.EnsureCreated();

            if(!_dbcontext.Categorias.Any())
            {
                var categorias = new Categoria[]
                {
                    new Categoria{Name="Ação"},
                    new Categoria{Name="Terror"}
                };
                foreach( var c in categorias)
                {
                    _dbcontext.Categorias.Add(c);
                }
                _dbcontext.SaveChanges();
            }

            if (!_dbcontext.Produtoras.Any())
            {
                var produtoras = new Produtora[]
                {
                    new Produtora{Name="SquashGame",Morada="Rua do Gamanço"},
                    new Produtora{Name="EA",Morada="Rua do Mico"}
                };
                foreach (var p in produtoras)
                {
                    _dbcontext.Produtoras.Add(p);
                }
                _dbcontext.SaveChanges();
            }

            if(!_dbcontext.Plataformas.Any())
            {
                var plataformas = new Plataforma[]
                {
                    new Plataforma{Name="Playstation 4"},
                    new Plataforma{Name="Xbox360"}
                };
                foreach (var p in plataformas)
                {
                    _dbcontext.Plataformas.Add(p);
                }
                _dbcontext.SaveChanges();
            }

            if (!_dbcontext.Jogos.Any())
            {
                
                var jogos = new Jogo[]
                {
                    new Jogo{Name="Fifa12",Description="QualquerCoisa",Preco=123,CategoriaID = 1,ProdutoraID=1,PlataformaID=2},
                    new Jogo{Name="KillUsel",Description="NadaNada",Preco=242,CategoriaID = 1,ProdutoraID=1,PlataformaID=2},
                    new Jogo{Name="okqw",Description="hdfjsdfsfw",Preco=12,CategoriaID = 1,ProdutoraID=1, PlataformaID = 2}
                };
                foreach (var j in jogos)
                {
                    _dbcontext.Jogos.Add(j);
                }
                _dbcontext.SaveChanges();
            }
        }
    }
}
