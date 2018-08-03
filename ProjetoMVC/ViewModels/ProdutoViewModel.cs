using ProjetoDDD.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }
        
        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="produto"></param>
        public ProdutoViewModel(Produto produto)
        {
            this.ProdutoId = produto.ProdutoId;
            this.Nome = produto.Nome;
            this.Valor = produto.Valor;
            this.ClienteId = produto.Cliente.ClienteId;
            this.Cliente = new ClienteViewModel(produto.Cliente);
        }

        /// <summary>
        /// Construtor da classe. 
        /// </summary>
        /// <param name="clienteId"></param>
        public ProdutoViewModel(int clienteId)
        {
            this.ClienteId = clienteId;
        }

        /// <summary>
        /// Construtor sem parâmetros.
        /// </summary>
        public ProdutoViewModel()
        {

        }
    }
}