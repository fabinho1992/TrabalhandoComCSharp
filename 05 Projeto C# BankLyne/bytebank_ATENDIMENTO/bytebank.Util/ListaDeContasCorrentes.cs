using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private  int proximaPosicao = 0;

    public ListaDeContasCorrentes(int tamanhoInicial = 5)//CASO NÃO PASSE NENHUM PARAMETRO QUANDO CRIAR UMA LISTA DE CONTAS, O VALOR PADRÃO SERÁ 5 DO VETOR
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    public void Adicionar(ContaCorrente conta)
    {
        Console.WriteLine($"Adicionando conta na posição {proximaPosicao}");//Para nos certificar de que os itens estão sendo inseridos no vetor, vamos exibir uma mensagem no console:
        VerificarCapacidade(proximaPosicao + 1);
        _itens[proximaPosicao] = conta;// A CADA CONTA ADICIONADA SE SOMA 1 NA PROXIMA POSIÇÃO
        proximaPosicao++;
    }

    public void VerificarCapacidade(int tamanhoNecessario)//AQUI VOU VERIFICAR SE MINHA LISTA DE CONTAS , TEM CAPACIDADE DE RECEBER MAIS CONTAS 
        //E SE NÃO TIVER IRÁ ADICIONAR MAIS "ESPAÇO" NA LISTA
    {
        if(_itens.Length >= tamanhoNecessario) //SE A LISTA FOR MAIOR OU IGUAL AO TAMANHO NECESSARIO, NÃO É NECESSARIO NENHUMA AÇÃO
        {
            return;
        }
        Console.WriteLine("Adicionando mais contas a lista!");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];// CRIO UM NOVO ARRAY QUE IRÁ RECEBER O ANTIGO MAS COM MAIS ESPAÇO

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];

        }
        
        _itens = novoArray; //  AO FINAL DO LOOP , A LISTA _ITENS RECEBE A LISTA ATUAL ATUALIZADA

    }

    

    public void ExibeLista()
    {   

        foreach (var conta in _itens)
        {
            if (conta != null)
            {
                Console.WriteLine($"Conta -> {conta.Numero_agencia} / {conta.Conta}");
            }

            
            
        }
    }

    public void Remover(ContaCorrente conta)// PARA REMOVER UM VALOR DO ARRAY TENHO QUE POR O VALOR QUE ESTA A FRENTE DELE NO SEU LUGAR
        // POR ISSO SE UTILIZA O FOR, COLOCANDO O PRÓXIMO INDICE SMP NO LUGAR DO ATUAL
    {
        int indiceConta = 0;

        for (int i = 0; i < proximaPosicao; i++)
        {
            ContaCorrente novaConta = _itens[i];//AQUI ENCONTRO O INDICE DO AQRRAY QUE QUERO REMOVER
            if(novaConta == conta)
            {
                indiceConta = i;
                break;
            }
        }
        //  {1, 3, 5, 6, 9}
        for (int i = indiceConta;i < proximaPosicao ; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        proximaPosicao--;// APÓS REMOVER TENHO QUE TIRAR ESSE VALOR DA CONTAGEM POR ISSO O "--" NA PRÓXIMA POSIÇÃO
        
    }

    //public ContaCorrente RecuperarContaComIndice(int indice)
    //{
    //    if(indice < 0 || indice > proximaPosicao)
    //    {
    //        throw new ArgumentOutOfRangeException(nameof(indice));// MENSAGEM DE ERRO
    //    }
    //    return _itens[indice];
    //}

    public int Tamanho 
    { 
        get 
        {
            return proximaPosicao;
        }  
    }

    //    indexador  //
    //precisamos usar a palavra reservada this com um índice inteiro em uma estrutura bem parecida a uma propriedade e definir a forma de recuperar um elemento do vetor interno da classe.
    public ContaCorrente this[int indice]// AQUI CRIEI UM INDEXADOR E POSSO USAR O OBJETO COMO ARRAY
    {
        get { return _itens[indice]; }//USEI O METODO DE RECUPERAR INDICE 
    }

}

