using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="cliente"></param>
        public ClienteViewModel(Cliente cliente)
        {
            this.ClienteId = cliente.ClienteId;
            this.Nome = cliente.Nome;
            this.Cpf = cliente.Cpf;
            this.DataCadastro = cliente.DataCadastro;
        }

        /// <summary>
        /// Contrutor sem parâmetros.
        /// </summary>
        public ClienteViewModel()
        {
            this.DataCadastro = DateTime.Now;
        }
    }
}