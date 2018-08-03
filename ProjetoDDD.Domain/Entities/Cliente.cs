using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDDD.Domain.Entities
{
    public class Cliente
    {
        public virtual int ClienteId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        /// <summary>
        /// Instance of the object.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = DateTime.Now;
        }

        public Cliente()
        {

        }

        public virtual void RemoveAllProdutos()
        {
            var produtos = this.Produtos.ToList();

            foreach (var produto in produtos)
            {
                this.Produtos.Remove(produto);
            }
        }

        public virtual void AddProduto(Produto produto)
        {
            if (this.Produtos.Any(p => p.Nome == produto.Nome))
                throw new ArgumentException("Esse produto já foi cadastrado para esse cliente.");

            this.Produtos.Add(new Produto(produto.Nome, produto.Valor, this));
        }
    }
}
