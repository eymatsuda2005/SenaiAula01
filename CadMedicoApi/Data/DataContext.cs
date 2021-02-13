using CadMedicoApi.Models;
using Microsoft.EntityFrameworkCore;
using  System.Collections.Generic;


namespace CadMedicoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        
        public DbSet<MedicoModel> Medicos{get; set;}
        public DbSet<CidadeModel> Cidades{get;set;}
        public DbSet<EspecialidadeModel> Especialidades{get;set;}
        public DbSet<UsuarioModel> Usuarios{get; set;}
        public DbSet <PrivilegioModel> Privilegios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<MedicoModel>().HasData(new List<MedicoModel>(){
                     new MedicoModel(1, "Eduardo", "33", "3344-0099"),
                     new MedicoModel(2, "Eduardo", "33", "3344-0099"),
                     new MedicoModel(3, "Manoel","35", "3344-0099" ),
                     new MedicoModel(4, "Antonio", "36", "3344-0099" ),
                     new MedicoModel(5, "Chico","37", "3344-0099" )           
           });
           builder.Entity<CidadeModel>().HasData(new List<CidadeModel>(){
                   new CidadeModel(1,"Apucarana","Parana"),
                   new CidadeModel(2, "Londrina", "Paraná"),
                   new CidadeModel(3, "Curitiba", "Paraná"),
                   new CidadeModel(4, "Maringá", "Paraná")
                    
           });

             builder.Entity<EspecialidadeModel>().HasData(new List<EspecialidadeModel>(){
                   new EspecialidadeModel(1,"Obstetra"),
                   new EspecialidadeModel(2, "Podólogo"),
                   new EspecialidadeModel(3, "Cardiologista"),
                   new EspecialidadeModel(4, "Geriatra")     
           });
            builder.Entity<UsuarioModel>().HasData(new List<UsuarioModel>(){
                   new UsuarioModel(1, "Eduardo", "Eduardo", "1234", 1),
                   new UsuarioModel(2, "Chico", "Chicao", "4321", 2),
                   new UsuarioModel(3, "Cleitin", "Cleitin", "0987", 3),
                   new UsuarioModel(4, "João","Joao", "9087", 5)      
           });
            builder.Entity<PrivilegioModel>().HasData(new List<PrivilegioModel>(){
                   new PrivilegioModel(1, "Master"),
                   new PrivilegioModel(2, "Adm"),
                   new PrivilegioModel(3, "User"),
                   new PrivilegioModel(4, "UserMed")   
                     
           });
            builder.Entity<MedicoCidade>(). HasKey(MC=> new {MC.MedicoId, MC.CidadeId});

            builder.Entity<MedicoCidade>().HasData(new List<MedicoCidade>(){
                        new MedicoCidade() {MedicoId = 1, CidadeId= 1},
                        new MedicoCidade() {MedicoId = 1, CidadeId= 2},
                        new MedicoCidade() {MedicoId = 3, CidadeId= 3},
                        new MedicoCidade() {MedicoId = 4, CidadeId= 4}
                        });

            builder.Entity<MedicoEspecialidade>(). HasKey(MC=> new {MC.MedicoId, MC.EspecialidadeId});

            builder.Entity<MedicoEspecialidade>().HasData(new List<MedicoEspecialidade>(){
                        new MedicoEspecialidade() {MedicoId = 1, EspecialidadeId= 1},
                        new MedicoEspecialidade() {MedicoId = 1, EspecialidadeId= 2},
                        new MedicoEspecialidade() {MedicoId = 3, EspecialidadeId= 3},
                        new MedicoEspecialidade() {MedicoId = 4, EspecialidadeId= 4}

                        });
        }
    }
}