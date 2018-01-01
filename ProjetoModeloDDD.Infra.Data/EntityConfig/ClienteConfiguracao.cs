using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    /// <summary>
    /// Fluent API para mapear os comportamentos da minha
    /// entidade de dominio para ela ser modela como uma tabela
    /// da minha base de dados
    /// </summary>
    public class ClienteConfiguracao: EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();
        }
    }
}
