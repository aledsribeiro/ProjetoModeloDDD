﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModel
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome do produto")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string NomeProduto { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "9999999999")]
        [Required(ErrorMessage = "Preencha o valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }


        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}