using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto1Apptransf.Classes
{
	public class Conta
	{
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private double limite;
		private string Nome { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
			// Validação de saldo suficiente
			if (this.Saldo - valorSaque < (this.Credito * -1))
			{
				Console.WriteLine("Saldo insuficiente!");
				return false;
			}
			this.Saldo -= valorSaque;

			if (this.Saldo < 0)
			{
				limite = this.Credito + this.Saldo;
			}
			else
			{
				limite = this.Credito;
			}

			Console.WriteLine("Saldo atual da conta de {0} é {1} com limite disponível de {2}", this.Nome, this.Saldo, limite);
			
			return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

			if (this.Saldo < 0)
            {
				limite = this.Credito + this.Saldo;
            }
			else
            {
				limite = this.Credito;
            }
			Console.WriteLine("Saldo atual da conta de {0} é {1} com limite disponível de {2}", this.Nome, this.Saldo, limite);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia))
			{
				contaDestino.Depositar(valorTransferencia);
			}
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "TipoConta " + this.TipoConta + " | ";
			retorno += "Nome " + this.Nome + " | ";
			retorno += "Saldo " + this.Saldo + " | ";
			if (this.Saldo < 0)
			{
				limite = this.Credito + this.Saldo;
				retorno += "Crédito " + limite;
			}
			else
			{
				retorno += "Crédito " + this.Credito;
			}
			return retorno;
		}
	}
}