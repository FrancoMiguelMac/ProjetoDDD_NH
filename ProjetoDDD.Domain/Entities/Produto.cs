using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Entities
{
    public class Produto
    {
        public virtual int ProdutoId { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        /// <summary>
        /// Instance of the object.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="valor"></param>
        /// <param name="clienteId"></param>
        public Produto(string nome, decimal valor, Cliente cliente)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Cliente = cliente;
        }

        public Produto()
        {

        }

        public virtual void Update(string nome, decimal valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }
    }
}
