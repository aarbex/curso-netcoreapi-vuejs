using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<Aluno> Alunos {get; set;}
        
        public DbSet<Professor> Professores {get; set;}   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>(){
                        new Professor(){
                            Id = 1,
                            Nome = "Rafael Casado"
                        },
                        new Professor(){
                            Id = 2,
                            Nome = "Hélio Duarte"
                        }
                    }
                );

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>(){
                        new Aluno(){
                            Id = 1,
                            Nome = "André",
                            Sobrenome = "Arbex",
                            Dt_nasc = "13/09/1981",
                            ProfessorId = 1
                        },
                        new Aluno(){
                            Id = 2,
                            Nome = "Marcia",
                            Sobrenome = "Arbex",
                            Dt_nasc = "10/03/1977",
                            ProfessorId = 1
                        },
                        new Aluno(){
                            Id = 3,
                            Nome = "Victor",
                            Sobrenome = "Arbex",
                            Dt_nasc = "12/08/2010",
                            ProfessorId = 2
                        },
                        new Aluno(){
                            Id = 4,
                            Nome = "Arthur",
                            Sobrenome = "Arbex",
                            Dt_nasc = "01/08/2014",
                            ProfessorId = 2
                        }
                    }
                );
        } 
        
    }
}