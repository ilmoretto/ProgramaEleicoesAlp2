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
                    CadastrarCandidato();

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
            List < (string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partido)> candidatos = new List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partido)> ();

            string nomeCompleto;
            string nomeEleitoral;
            string partido;
            string numeroCandidato;
            char opcaoMenu = 's';

            while(opcaoMenu != 'n') {
                Console.Write("Informe o nome completo do Candidato: ");
                nomeCompleto = Console.ReadLine();

                Console.Write("Informe o nome eleitoral do Candidato: ");
                nomeEleitoral = Console.ReadLine();

                Console.Write("Informe o partido do Candidato: ");
                partido = Console.ReadLine();

                Console.Write("Informe o número de votação do Candidato: ");
                numeroCandidato = Console.ReadLine();

                Console.WriteLine("\nCandidato cadastrado com sucesso!");

                candidatos.Add((nomeCompleto, nomeEleitoral, partido, numeroCandidato));

                Console.Write("\nDeseja cadastrar outro candidato? (s/n): ");
                opcaoMenu = Convert.ToChar(Console.ReadLine().ToLower());

               

            }
            Console.ReadKey();
        }
    }
}
