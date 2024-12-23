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
        static void Main(string[] args)
        {
            //Programa eleitoral - Start em 20/12/2024 às 22h59

            //Instanciando lista para cadastrar os candidatos
            var corConsole = Console.BackgroundColor;
            List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partidoPolitico)> candidatos = new List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partidoPolitico)>();
            bool encerrarPrograma = false;
            while (!encerrarPrograma)
            {
                //Menu provisório
                Console.Clear();
                Console.WriteLine("=====|Programa de Eleições|=====");
                Console.WriteLine("1 - Candidatos");
                Console.WriteLine("2 - ");
                Console.WriteLine("3 - ");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcaoMenu = Console.ReadLine();


                switch (opcaoMenu)
                {

                    case "0":
                        Console.WriteLine("Encerrando sistema...");
                        encerrarPrograma = true;
                        break;

                    case "1":  //Candidatos
                        SubmenuCandidatos(candidatos);

                        break;

                    case "2":


                        break;

                    case "3":

                        break;


                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida. Clique qualquer tecla para tentar novamente!");
                        Console.BackgroundColor = corConsole;
                        Console.ReadKey();
                        break;
                }// fim do switch
            } // fim do while do menu inicial

        }
        //=====================================| FUNÇÕES | ==================================================
        static void CadastrarCandidato(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos)
        {
            string nomeCompleto;
            string nomeEleitoral;
            string partidoPolitico;
            string numeroCandidato;
            string opcaoMenu = "s";

            while (opcaoMenu != "n")
            {
                Console.Write("Informe o nome completo do Candidato: ");
                nomeCompleto = Console.ReadLine();

                Console.Write("Informe o nome eleitoral do Candidato: ");
                nomeEleitoral = Console.ReadLine();

                Console.Write("Informe o partido do Candidato: ");
                partidoPolitico = Console.ReadLine();

                bool numeroValido;

                do
                {
                    numeroValido = true;
                    Console.Write("Informe o número de votação do Candidato: ");
                    numeroCandidato = Console.ReadLine();

                    // Validação manual
                    foreach (var candidato in candidatos)
                    {
                        if (candidato.numeroCandidato == numeroCandidato)
                        {
                            Console.WriteLine($"Erro: O número {numeroCandidato} já está cadastrado para outro candidato. " +
                                $"Informe um número diferente.");
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
        }// fim da função cadastrar candidato
        static void ExibirCandidatos(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos)
        {
            if (candidatos.Count == 0)
            {
                Console.WriteLine("Nenhum candidato cadastrado! Pressione qualquer tecla para continuar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                  "ID", "Nome Completo", "Nome Eleitoral", "Número", "Partido"); //cabeçalho da tabela de exibição

                Console.WriteLine(new string('-', 80)); // linha que separa o cabeçalho dos dados

                for (int i = 0; i < candidatos.Count; i++)
                {
                    var candidato = candidatos[i];
                    Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                                      i + 1, candidato.nomeCompleto, candidato.nomeEleitoral,
                                      candidato.numeroCandidato, candidato.partidoPolitico); //exibindo dados dos candidatos
                }

                Console.WriteLine("\n\nPressione qualquer tecla para continuar.");
            }
            Console.ReadKey();
        }// fim da função ExibirCandidatos

        static void RemoverCandidatos(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos)
        {
            if (candidatos.Count == 0)
            {
                Console.WriteLine("Nenhum candidato cadastrado. Pressione qualquer tecla para continuar.");
            }
            else
            {
                // Exibindo a lista de candidatos
                Console.Clear();
                Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                  "ID", "Nome Completo", "Nome Eleitoral", "Número", "Partido"); //cabeçalho da tabela de exibição

                Console.WriteLine(new string('-', 80)); // linha que separa o cabeçalho dos dados

                for (int i = 0; i < candidatos.Count; i++)
                {
                    var candidato = candidatos[i];
                    Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                                      i + 1, candidato.nomeCompleto, candidato.nomeEleitoral,
                                      candidato.numeroCandidato, candidato.partidoPolitico); //exibindo dados dos candidatos
                }
                // solicitar o número do candidato a ser removido
                Console.WriteLine("\nInforme o número do candidato a ser removido:");
                string numeroCandidato = Console.ReadLine();

                // procurar pelo candidato com o número fornecido
                bool candidatoEncontrado = false;

                for (int i = 0; i < candidatos.Count; i++)
                {
                    if (candidatos[i].numeroCandidato == numeroCandidato)
                    {
                        candidatos.RemoveAt(i);
                        candidatoEncontrado = true;
                        Console.WriteLine("CANDIDATO REMOVIDO COM SUCESSO!");
                        break;
                    }
                }

                if (!candidatoEncontrado)
                {
                    Console.WriteLine("Erro: Número do candidato não encontrado! Pressione qualquer tecla para continuar.");
                }
            }
            Console.ReadKey();

        }//Fim da Função RemoverCandidatos

        //=====================================| SUBMENUS | ==================================================

        static void SubmenuCandidatos(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos)
        {

            bool voltarAoMenu = false;

            while (!voltarAoMenu)
            {
                Console.Clear();
                Console.WriteLine("=====| CANDIDATOS | =====");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Exibir");
                Console.WriteLine("3 - Remover");
                Console.WriteLine("0 - Voltar ao Menu");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":

                        Console.WriteLine("Redirecionando ao menu inicial...");
                        voltarAoMenu = true;
                        break;
                    case "1":
                        CadastrarCandidato(candidatos);

                        break;

                    case "2":
                        ExibirCandidatos(candidatos);

                        break;

                    case "3":
                        RemoverCandidatos(candidatos);

                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();

                        break;
                }// fim do switch


            }// fim do laço while

        }// fim da função submenu de candidatos


    }
}
