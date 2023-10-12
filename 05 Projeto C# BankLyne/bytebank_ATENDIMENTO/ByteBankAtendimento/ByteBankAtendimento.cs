using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.ByteBankExecoes;
using System.Threading.Channels;

namespace bytebank_ATENDIMENTO.ByteBankAtendimento;

public class ByteBankAtendimento
{
    ///     EXEMPLO DE ARRAYLIST UMA BIBLIOTECA MUITO UTIL     ///
    //ArrayList listaDeContas = new ArrayList(); // AQUI ESTOU UTILIZANDO A BIBLIOTECA "ARRAYLIST QUE FACILITA MUITO O TRABALHO. NÃO PRECISANDO CRIAR UMA CLASE ESPECIFICA"
     public static List<ContaCorrente> listaDeContas = new List<ContaCorrente>()// Usando a classe LIST , que é uma classe generica , posso definir que tipo de objeto posso receber na minha lista
    {
        new ContaCorrente(95){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique", Profissao = "Motorista"}},
        new ContaCorrente(95){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro", Profissao = "Contador"}},
        new ContaCorrente(94){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa", Profissao = "Atendente"}}
    };


    public void AtendimentoCliente()
    {
        try
        {
            char opcao = '0';
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Sair do Sistema      ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");

                try // ATRAVES DO TRY/ CATH , O PROGRAMA VAI TENTAR EXECUTAR O CODIGO E SE DER ALGUM ERRO , COMO UMA EXECAO , IRÁ MOSTRAR A MENSAGEM QUE COLOQUEI ATRAVES DO BYTEBANKEXECAO
                {
                    opcao = Console.ReadLine()[0];// O READLINE RETORNA UMA LISTA DE STRINGS POR ISSO USO O [], POIS QUERO O PRIMEIRO ITEM DA LISTA, QUE É O QUE FOI DIGITADO 
                                                  // código anterior omitido
                }
                catch (Exception execao)
                {

                    throw new ByteBankExecao(execao.Message);// MENSAGEM DE ERRO, CASO OCORRA UMA EXECAO
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OrdernarContas();
                        break;
                    case '5':
                        PesquisarContas();
                        break;
                    case '6':
                        EcerrarApp();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;


                }
            }
        }
        catch (ByteBankExecao execao)
        {
            Console.WriteLine($"{execao.Message}");
        }
    }

    private void EcerrarApp()
    {
        Console.WriteLine("... Aplicativo encerrado ...");
        Console.ReadKey();
    }

    void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===    PESQUISAR CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write(" DESEJA PESQUISAR POR (1) NÚMERO DO CPF OU (2) NÚMERO DA CONTA OU (3) NÚMERO DA AGÊNCIA :");
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                {
                    Console.WriteLine("Digite o cpf do titular: ");
                    string cpf = Console.ReadLine();
                    ContaCorrente contaPeloCpf = ConsultaPeloCpf(cpf);
                    Console.WriteLine(contaPeloCpf.ToString());
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Digite o numero da conta: ");
                    string numeroConta = Console.ReadLine();
                    ContaCorrente contaPelaConta = ConsultaPelaConta(numeroConta);
                    Console.WriteLine(contaPelaConta.ToString());
                    Console.ReadKey();
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Digite o numero da Agência: ");
                    int numeroAgencia = int.Parse(Console.ReadLine());
                    var contaPelaAgencia = ConsultaPelaAgencia(numeroAgencia); // AQUI USEI O VAR PARA CHAMAR A VARIAVEL POIS (um retorno implícito)
                    ExibirContas(contaPelaAgencia);
                    Console.ReadKey();
                    break;
                }
            default:
                {
                    Console.WriteLine("Opção invalida!!");
                    break;
                }

        }
    }

    void ExibirContas(List<ContaCorrente> contaPelaAgencia)
    {
        if (contaPelaAgencia == null) // se a lista passada como paremetro estiver vazia
        {
            Console.WriteLine(" .... Não foi encontrado nehum dado na pesquisa ....");
        }
        else
        {
            foreach (var item in contaPelaAgencia)
            {
                Console.WriteLine(item.ToString()); // pra cada item na lista, vou usar o metodo "TOLIST" , e escrever na tela seus dados 
            }
        }
    }

    List<ContaCorrente> ConsultaPelaAgencia(int numeroAgencia)
    {
        var consulta = (
                             from conta in listaDeContas               // AQUI FILTREI AS CONTAS POR SEU NÚMERO DA CONTA E CRIEI UMA LISTA ATRAVÉS DO METODO 
                             where conta.Numero_agencia == numeroAgencia  //Vamos utilizar outro recurso do LINQ e escreveremos essa consulta manualmente, de modo que perceberemos que a sintaxe é muito parecida com a linguagem SQL.
                             select conta).ToList();
        return consulta;
    }

    ContaCorrente ConsultaPelaConta(string? numeroConta)
    {
        //ContaCorrente conta = null;
        //foreach (var item in listaDeContas)
        //{
        //    if (item.Conta.Equals(numeroConta))
        //    {
        //        conta = item;
        //    }

        //}
        //return conta;

        var consulta = (from conta in listaDeContas
                        where conta.Conta == numeroConta
                        select conta).FirstOrDefault();
        return consulta;
    }

    ContaCorrente ConsultaPeloCpf(string? cpf)
    {
        //ContaCorrente conta = null;
        //foreach (var item in listaDeContas)
        //{
        //    if (item.Titular.Cpf.Equals(cpf))    // MODO QUE UTILIZA MUITAS LINHAS PARA PROCURAR UMA CONTA PELO CPF
        //    {
        //        conta = item;
        //    }

        //}
        //return conta;

        return listaDeContas.Where(conta => conta.Titular.Cpf.Equals(cpf)).FirstOrDefault();// VAI ME RETORNA A CONTA QUE TEM O CPF PASSADO OU NULL.
    }

    void OrdernarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     CONTAS ORDENADAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        listaDeContas.Sort();
        Console.WriteLine("----- Lista ordenada com sucesso -----");
        foreach (var conta in listaDeContas)
        {
            Console.WriteLine($" {conta.ToString()}\n ");
            Console.WriteLine("=========================");
        }

        Console.ReadKey();


    }

    void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da Conta: ");
        string numeroConta = Console.ReadLine();
        ContaCorrente conta = null;
        foreach (var item in listaDeContas)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
            }
            if (conta != null)
            {
                listaDeContas.Remove(conta);
                Console.WriteLine("---- Conta removida com sucesso ----");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("---- Conta digitada não existe ----");
                Console.ReadKey();
            }
        }
    }

    void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   LISTA DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        if (listaDeContas.Count <= 0)
        {
            Console.WriteLine("Nenhuma conta encontrada.");
            Console.ReadKey(); // O "READKEY"  FAZ COM QUE O PROGRAMA AGUARDE O USUARIO APERTAR UMA TECLA , PARA PODER FINALIZAR
            return;
        }
        else
        {
            foreach (ContaCorrente item in listaDeContas)
            {
                //Console.WriteLine("===  Dados da Conta  ===");
                //Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                //Console.WriteLine("Número da Agencia : " + item.Numero_agencia);
                //Console.WriteLine("Número da Conta : " + item.Conta);
                //Console.WriteLine("Saldo da Conta : " + item.Saldo);
                //Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                Console.WriteLine(item.ToString());// com o metodo ToString, tenho o mesmo resulta , economizando muito código
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
            }
        }
    }

    void CadastrarConta()
    {

        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===\n");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia);

        Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();

    }


}
