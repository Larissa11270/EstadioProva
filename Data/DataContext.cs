using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaApi.Models;
using CopaHAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CopaHAS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Jogador> TB_JOGADORES { get; set; }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().ToTable("TB_JOGADORES");

            modelBuilder.Entity<Jogador>().HasData
            (
                new Jogador(){ Id=1, Nome="Hugo Souza",NumeroCamisa=1,Posicao="Goleiro",Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=2, Nome="Yuri Alberto",NumeroCamisa=9,Posicao="Atacante",Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=3, Nome="Danilo", NumeroCamisa=2, Posicao="Lateral Direito", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=4, Nome="Marquinhos", NumeroCamisa=4, Posicao="Zagueiro", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=5, Nome="Casemiro", NumeroCamisa=5, Posicao="Volante", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=6, Nome="Alex Sandro", NumeroCamisa=6, Posicao="Lateral Esquerdo", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=7, Nome="Lucas Paquetá", NumeroCamisa=7, Posicao="Meio Campo", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=8, Nome="Bruno Guimarães", NumeroCamisa=8, Posicao="Meio Campo", Status=Models.Enuns.StatusJogador.Reserva },
                new Jogador(){ Id=9, Nome="Richarlison", NumeroCamisa=10, Posicao="Atacante", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=10, Nome="Vinicius Jr", NumeroCamisa=11, Posicao="Atacante", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=11, Nome="Rodrygo", NumeroCamisa=19, Posicao="Atacante", Status=Models.Enuns.StatusJogador.DepartamentoMedico },
                new Jogador(){ Id=12, Nome="Alisson", NumeroCamisa=23, Posicao="Goleiro", Status=Models.Enuns.StatusJogador.NaoRelacionado }
            );

            modelBuilder.Entity<Estadio>().ToTable("TB_ESTADIO");

            modelBuilder.Entity<Estadio>().HasData
            (
                new Estadio(){ Id=1, Nome="Maracanã", Cidade="Rio de Janeiro", Capacidade=50000},
                new Estadio(){ Id=2, Nome="Pacaembu", Cidade="São Paulo", Capacidade=20000},
                new Estadio(){ Id=3, Nome="Morumbi", Cidade="São Paulo", Capacidade=80000},
                new Estadio(){ Id=4, Nome="Allianz Parque", Cidade="São Paulo", Capacidade=90000},
                new Estadio(){ Id=5, Nome="Canindé", Cidade="São Paulo", Capacidade=30000},
                new Estadio(){ Id=6, Nome="Neo Química Arena", Cidade="São Paulo", Capacidade=100000},
                new Estadio(){ Id=7, Nome="Rua Javari", Cidade="Santos", Capacidade=40000}
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar").HaveMaxLength(200);

            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<Estadio> TB_ESTADIO { get; set; }     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}

