//    FORMAS DE TRABALHAR COM ARRAYS    //

using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_ATENDIMENTO.ByteBankAtendimento;
using bytebank_ATENDIMENTO.ByteBankExecoes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

Console.WriteLine(" Boas Vindas ao ByteBank, Atendimento.");

new ByteBankAtendimento().AtendimentoCliente();

//ContaCorrente ContaSaldo = 




#region  EXEMPLOS DE ARRAYS EM C#
void ArrayIniciando()
{
    int[] notas = new int[5] { 10, 10, 8, 6, 9 };


    Console.WriteLine($"\nEssas são as notas");

    foreach (int nota in notas)
    {
        Console.WriteLine($"-> {nota}");
    }
}

void BuscandoPalavrasNoArray()
{

    string[] ArrayDeNomes = new string[3];

    for (int i = 0; i < ArrayDeNomes.Length; i++)
    {
        Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.\n");
        Console.Write($"Digite o {i + 1}º nome: ");// FAÇO I + 1 POIS QUERO COMEÇAR PEDINDO O PRIMEIRO NOME
        ArrayDeNomes[i] = Console.ReadLine()!;
        Console.Clear();
    }
    Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.\n");

    Console.Write("Digite o nome que está procurando: ");
    string busca = Console.ReadLine()!;

    foreach( string nome in ArrayDeNomes)
    {
        if (nome.Equals(busca))// AQUI ESTOU COMPARANDO CADA NOME DO ARRAY COM O QUE FOI DIGITADO E SALVO NA VARIAVEL "BUSCA"
        {
            Console.WriteLine($"Nome encontrado -> {busca}.");
            break;
        }
        
    }

   

}

Array amostra = Array.CreateInstance(typeof(double), 5);// CRIEI UMA CLASSE ARRAY E " o tipo dos valores do array e o tamanho dele "

amostra.SetValue(2.6, 0);
amostra.SetValue(4.5, 1);
amostra.SetValue(3.2, 2); 
amostra.SetValue(10, 3);
amostra.SetValue(9.5, 4);


void TestaMediana(Array array)
{
    if((array == null) || (array.Length == 0))
       {
        Console.WriteLine("Array para o calculo mediana está vazio ou nulo!");
        }

    double[] numerosOrdenados = (double[])array.Clone();//criando um array reserva chamado numerosOrdenados que será uma cópia de array
    Array.Sort(numerosOrdenados);// AQUI COLOQUEI A LISTA DE NUMEROS EM ORDEM CRESCENTE

    int tamanho = numerosOrdenados.Length; // UMA VARIAVEL INTEIRA, COM O TAMANHO DO ARRAY
    int meio = tamanho / 2; // VARIAVEL INTEIRA O TAMANHO DO ARRAY DIVIDIDO POR DOIS, OU SEJA , METADE

    double mediana = (meio != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    // USEI UM OPERADOR TERNARIO PARA PODER DECLARAR A VARIAVEL

    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}


void MediaSimples(Array array)
{
    double[] numerosMedia = (double[])array.Clone();
    double media = (double)numerosMedia.Average();

    Console.WriteLine($"A média da amostra é {media}.");
}

//ArrayIniciando();
//BuscandoPalavrasNoArray();
//TestaMediana(amostra);
//MediaSimples(amostra);
//TestarContaCorrente();
//TestarListaDeContaCorrente();


void TestarContaCorrente()
{
    ContaCorrente[] contaCorrentes = new ContaCorrente[]
    {
        new ContaCorrente(300),
        new ContaCorrente(301),
        new ContaCorrente(302)
    };
    

    foreach (ContaCorrente conta in contaCorrentes)
    {
        Console.WriteLine($"Número da conta -> {conta.Conta} , {conta.Numero_agencia}");
    }
    

}

void TestarListaDeContaCorrente()
{
    ListaDeContasCorrentes ListaDeContas = new ListaDeContasCorrentes();

    ListaDeContas.Adicionar(new ContaCorrente(301));
    ListaDeContas.Adicionar(new ContaCorrente(205));
    ContaCorrente fabio = new ContaCorrente(329);
    ContaCorrente nicoly = new ContaCorrente(108);

    ListaDeContas.Adicionar(fabio);
    ListaDeContas.Adicionar(nicoly);

   // ListaDeContas.ExibeLista();
   // Console.WriteLine("");
   // ListaDeContas.Remover(nicoly);
   // ListaDeContas.ExibeLista();
   //Console.ReadKey();

    for (int i = 0; i < ListaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = ListaDeContas[i];
        Console.WriteLine($"Indice [{i}] -> {conta.Conta}/{conta.Numero_agencia}");
    }
}
#endregion  // 

#region Exemplos de metodos de List
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874),
//    new ContaCorrente(874),
//    new ContaCorrente(874)
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951),
//    new ContaCorrente(321),
//    new ContaCorrente(719)
//};

//_listaDeContas2.AddRange(_listaDeContas3); // ESSE METODO PASSA UMA LISTA PARA O FINAL DA OUTRA
//_listaDeContas2.Reverse();// AQUI A LISTA É INVERTIDA

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = _listaDeContas3.GetRange(0, 1); // MOSTRAR O QUE QUERO DA LISTA PELO SEU INDICE, PRIMEIRO PASSO O INDICE ONDE COMEÇO E DEPOIS ONDE QUERO QUE TERMINE
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//_listaDeContas3.Clear();// COMO LIMPAR UMA LISTA
//for (int i = 0; i < _listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas3[i].Conta}]");
//}

//List<string> nomesDosEscolhidos = new List<string>()
//{
//    "Bruce Wayne",
//    "Carlos Vilagran",
//    "Richard Grayson",
//    "Bob Kane",
//    "Will Farrel",
//    "Lois Lane",
//    "General Welling",
//    "Perla Letícia",
//    "Uxas",
//    "Diana Prince",
//    "Elisabeth Romanova",
//    "Anakin Wayne"
//};

////  EXERCICIO PARA BUSCAR NOME EM UMA LISTA
//void BuscarNome()
//{
//    Console.Clear();
//    Console.Write("Digite o nome que deseja encontrar: ");
//    string nomeBuscado = Console.ReadLine();
//    if (nomesDosEscolhidos.Contains(nomeBuscado))
//    {
//        Console.WriteLine($"O nome {nomeBuscado} existe na lista.");
//        Console.ReadKey();
//    }
//    else
//    {
//        Console.WriteLine("Esse nome não existe na lista.");
//    }


//}

////BuscarNome();

//bool VerificaNomes(List<string> nomesDosEscolhidos, string escolhido)
//{
//    return nomesDosEscolhidos.Contains(escolhido);
//}

#endregion

// Exemplo de uma classe GENERICA
//Generica<int> teste1 = new Generica<int>();
//teste1.MostrarMensagem(10);

//Generica<string> teste2 = new Generica<string>();
//teste2.MostrarMensagem("Olá mundo!");

//public class Generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo (t)");
//    }
//}










