using System;
using System.Data.Entity;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoModeloDDD.Infra.Data.EntityConfig;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContexto: DbContext
    {
        public ProjetoModeloContexto()
            :base("ProjetoModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        /// <summary>
        /// Usado para configurar como as tabelas devem ser criadas
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //para não pluralizar os objetos
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //força que todas as propriedades que contenham Id se tornem PK
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").
                Configure(p => p.IsKey());

            //quando a propriedade omitir o tipo ele assume o que esta aqui
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoConfiguracao());
        }

        /// <summary>
        /// Sobrescrito para setar a data quando um novo cliente for adicionado e
        /// não permite modificar a data nos updates
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
