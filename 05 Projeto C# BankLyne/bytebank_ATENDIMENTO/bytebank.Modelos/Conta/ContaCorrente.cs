namespace bytebank.Modelos.Conta;

public class ContaCorrente : IComparable<ContaCorrente> // ATRAVES DA INTERFACE "ICOMPARABLE" A CLASS CONTACORRENTE PODE USAR O METODO "SORT" QUE ORDENA A LISTA DE CLIENTES
{
	private int _numero_agencia;

	private string _conta;

	private double saldo;

	public Cliente Titular { get; set; }

	public string Nome_Agencia { get; set; }

	public int Numero_agencia
	{
		get
		{
			return _numero_agencia;
		}
		set
		{
			if (value > 0)
			{
				_numero_agencia = value;
			}
		}
	}

	public string Conta
	{
		get
		{
			return _conta;
		}
		set
		{
			if (value != null)
			{
				_conta = value;
			}
		}
	}

	public double Saldo
	{
		get
		{
			return saldo;
		}
		set
		{
			if (!(value < 0.0))
			{
				saldo = value;
			}
		}
	}

	public static int TotalDeContasCriadas { get; set; }

	public bool Sacar(double valor)
	{
		if (saldo < valor)
		{
			return false;
		}
		if (valor < 0.0)
		{
			return false;
		}
		saldo -= valor;
		return true;
	}

	public void Depositar(double valor)
	{
		if (!(valor < 0.0))
		{
			saldo += valor;
		}
	}

	public bool Transferir(double valor, ContaCorrente destino)
	{
		if (saldo < valor)
		{
			return false;
		}
		if (valor < 0.0)
		{
			return false;
		}
		saldo -= valor;
		destino.saldo += valor;
		return true;
	}

	public ContaCorrente(int numero_agencia)
	{
		
		Numero_agencia = numero_agencia;
		Conta = Guid.NewGuid().ToString().Substring(0, 8); // CRIA UM NUMERO DE CONTA ALEATÓRIA NA FORMA DE UMA STRING
		Titular = new Cliente();
		TotalDeContasCriadas++;
	}

	public override string ToString()
	{

		return $" === DADOS DA CONTA === \n" +
			   $"Número da Conta : {this.Conta} \n" +
			   $"Número da Agência : {this.Numero_agencia} \n"+
			   $"Titular da Conta: {this.Titular.Nome} \n" +
			   $"CPF do Titular  : {this.Titular.Cpf} \n" +
			   $"Profissão do Titular: { this.Titular.Profissao}\n";

	}

    public int CompareTo(ContaCorrente? other)
    {
		return this.Numero_agencia.CompareTo(other.Numero_agencia);// AQUI RETORNO O QUE VAI SER COMPARADO, COMO O METODO RETORNA UM INTEIRO , USEI PARA COMPARAR O NUMERO DA AGENCIA
        
    }
}