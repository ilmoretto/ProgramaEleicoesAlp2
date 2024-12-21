using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEleicoes
{
    internal class Program
    {
        static void Main(string[] args) {
            //Programa eleitoral - Start em 20/12/2024 às 22h59

            //Menu provisório
            Console.WriteLine("=====|Programa de Eleições|=====");
            Console.WriteLine("1 - Cadastrar Candidato");
            Console.WriteLine("2 - Iniciar Votação");
            Console.WriteLine("3 - Contar Votos e Exibir Resultado");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            int opcaoMenu = Convert.ToInt32(Console.ReadLine());

            switch (opcaoMenu) {

                case 0:
                    Console.WriteLine("Encerrando sistema...");
                    break;

                case 1:  //cadastrar candidato


                    break;

                case 2:  // iniciar votação

                    break;

                case 3: // encerrar votação

                    break;


                default:
                    Console.WriteLine("Opção inválida. Tente novamente!");
                    break;
            }// fim do switch

        }
        static void CadastrarCandidato() {
            List < (string nomeCompleto, string apelidoUrna, string numeroCandidato)> candidatos = new List<(string nomeCompleto, string apelidoUrna, string numeroCandidato)> ();

            string nomeCompleto;
            string apelidoUrna;
            string numeroCandidato;
            char opcao = 's';

            while(opcao != 'n') {

            }
        }
    }
}
