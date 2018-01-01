using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.NomeProduto)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Valor)
               .IsRequired();

            //aponta para a entidade cliente
            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
