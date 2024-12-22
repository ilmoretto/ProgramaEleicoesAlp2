using System;
using System.Collections.Concurrent;
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

            //Instanciando lista para cadastrar os candidatos
            List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partidoPolitico)> candidatos = new List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partidoPolitico)>();
            int opcaoMenu = 0;
            do {
                //Menu provisório
                Console.Clear();
                Console.WriteLine("=====|Programa de Eleições|=====");
                Console.WriteLine("1 - Cadastrar Candidato");
                Console.WriteLine("2 - Iniciar Votação");
                Console.WriteLine("3 - Contar Votos e Exibir Resultado");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                opcaoMenu = Convert.ToInt32(Console.ReadLine());


                switch (opcaoMenu) {

                    case 0:
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    case 1:  //cadastrar candidato
                        CadastrarCandidato(candidatos);

                        break;

                    case 2:  // iniciar votação

                        break;

                    case 3: // encerrar votação

                        break;


                    default:
                        Console.WriteLine("Opção inválida. Tente novamente!");
                        break;
                }// fim do switch
            } while (opcaoMenu != 0);

        }
        static void CadastrarCandidato(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos) {


            string nomeCompleto;
            string nomeEleitoral;
            string partidoPolitico;
            string numeroCandidato;
            string opcaoMenu = "s";

            while (opcaoMenu != "n") {
                Console.Write("Informe o nome completo do Candidato: ");
                nomeCompleto = Console.ReadLine();

                Console.Write("Informe o nome eleitoral do Candidato: ");
                nomeEleitoral = Console.ReadLine();

                Console.Write("Informe o partido do Candidato: ");
                partidoPolitico = Console.ReadLine();

                bool numeroValido;

                do {
                    numeroValido = true;
                    Console.Write("Informe o número de votação do Candidato: ");
                    numeroCandidato = Console.ReadLine();

                    // Validação manual
                    foreach (var candidato in candidatos) {
                        if (candidato.numeroCandidato == numeroCandidato) {
                            Console.WriteLine($"Erro: O número {numeroCandidato} já está cadastrado para outro candidato. Informe um número diferente.");
                            numeroValido = false; // Número já existe, invalida a entrada
                            break;
                        }
                    }
                } while (!numeroValido); // Repete enquanto o número for inválido



                Console.WriteLine("\nCandidato cadastrado com sucesso!");


                candidatos.Add((nomeCompleto, nomeEleitoral, partidoPolitico, numeroCandidato));

                Console.Write("\nDeseja cadastrar outro candidato? (s/n): ");
                opcaoMenu = Console.ReadLine().ToLower().Trim();

            }
            Console.WriteLine("Cadastro encerrado, clique qualquer tecla para continuar...");
            Console.ReadKey();
        }

    }
}
