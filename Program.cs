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
            var corConsole = Console.BackgroundColor;
            List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partidoPolitico)> candidatos = new List<(string nomeCompleto, string nomeEleitoral, string numeroCandidato, string partidoPolitico)>();
            List<string> votos = new List<string>();

            bool encerrarPrograma = false;
            while (!encerrarPrograma) {
                //Menu provisório
                Console.Clear();
                Console.WriteLine("=====|Programa de Eleições|=====");
                Console.WriteLine("1 - Candidatos");
                Console.WriteLine("2 - Votação ");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcaoMenu = Console.ReadLine();


                switch (opcaoMenu) {

                    case "0":
                        Console.WriteLine("Encerrando sistema...");
                        encerrarPrograma = true;
                        break;

                    case "1":  //Candidatos
                        SubmenuCandidatos(candidatos);

                        break;

                    case "2":
                        SubmenuVotacao(candidatos, votos);


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
        //=====================================| FUNÇÕES CANDIDATOS | ==================================================
        static void CadastrarCandidato(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos) {
            string nomeCompleto;
            string nomeEleitoral;
            string partidoPolitico;
            string numeroCandidato;
            string opcaoMenu = "s";

            Console.WriteLine("=====| CADASTRAR CANDIDATOS |=====");

            while (opcaoMenu != "n") {
                Console.Clear();
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
        static void ExibirCandidatos(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos) {
            Console.WriteLine("=====| EXIBIR CANDIDATOS |=====");
            if (candidatos.Count == 0) {
                Console.WriteLine("Nenhum candidato cadastrado! Pressione qualquer tecla para continuar.");
            } else {
                Console.Clear();
                Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                  "ID", "Nome Completo", "Nome Eleitoral", "Número", "Partido"); //cabeçalho da tabela de exibição

                Console.WriteLine(new string('-', 80)); // linha que separa o cabeçalho dos dados

                for (int i = 0; i < candidatos.Count; i++) {
                    var candidato = candidatos[i];
                    Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                                      i + 1, candidato.nomeCompleto, candidato.nomeEleitoral,
                                      candidato.numeroCandidato, candidato.partidoPolitico); //exibindo dados dos candidatos
                }

                Console.WriteLine("\n\nPressione qualquer tecla para continuar.");
            }
            Console.ReadKey();
        }// fim da função ExibirCandidatos

        static void RemoverCandidatos(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos) {
            Console.WriteLine("=====| REMOVER CANDIDATOS |=====");
            if (candidatos.Count == 0) {
                Console.WriteLine("Nenhum candidato cadastrado. Pressione qualquer tecla para continuar.");
            } else {
                // Exibindo a lista de candidatos
                Console.Clear();
                Console.WriteLine("{0,-4} | {1,-25} | {2,-20} | {3,-10} | {4,-15}",
                  "ID", "Nome Completo", "Nome Eleitoral", "Número", "Partido"); //cabeçalho da tabela de exibição

                Console.WriteLine(new string('-', 80)); // linha que separa o cabeçalho dos dados

                for (int i = 0; i < candidatos.Count; i++) {
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

                for (int i = 0; i < candidatos.Count; i++) {
                    if (candidatos[i].numeroCandidato == numeroCandidato) {
                        candidatos.RemoveAt(i);
                        candidatoEncontrado = true;
                        Console.WriteLine("CANDIDATO REMOVIDO COM SUCESSO!");
                        break;
                    }
                }

                if (!candidatoEncontrado) {
                    Console.WriteLine("Erro: Número do candidato não encontrado! Pressione qualquer tecla para continuar.");
                }
            }
            Console.ReadKey();

        }//Fim da Função RemoverCandidatos

        //=====================================| FUNÇÕES VOTAÇAO | ==================================================
        static void Votar(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos, List<string> votos) {

            if (candidatos.Count == 0) {
                Console.WriteLine("Nenhum candidato cadastrado. Pressione qualquer tecla para continuar.");
            } else {
                bool emVotacao = false;

                while (!emVotacao) {

                    Console.Clear();
                    Console.WriteLine("=====| VOTAÇÃO |=====");

                    // exibir candidatos disponiveis para votar
                    Console.WriteLine("Candidatos Disponíveis:");
                    foreach (var candidato in candidatos) {
                        Console.WriteLine($"\nNome: {candidato.nomeEleitoral}\nPartido: {candidato.partidoPolitico}" +
                            $"\nNúmero: {candidato.numeroCandidato}");
                    }

                    Console.WriteLine("\nOpções adicionais:");
                    Console.WriteLine("0 - Voto em BRANCO");
                    Console.WriteLine("Qualquer outro número - VOTO NULO");

                    // solicitar o voto
                    Console.Write("\nDigite o número do candidato: ");
                    string voto = Console.ReadLine();

                    // validação do voto
                    bool candidatoEncontrado = false;
                    foreach (var candidato in candidatos) {
                        if (candidato.numeroCandidato == voto) {
                            votos.Add(voto);
                            Console.WriteLine($"Você votou no candidato: {candidato.nomeEleitoral}");
                            candidatoEncontrado = true;
                            break;
                        }
                    }

                    if (!candidatoEncontrado) {
                        if (voto == "0") {
                            votos.Add("BRANCO");
                            Console.WriteLine("Você votou em BRANCO.");
                        } else {
                            votos.Add("NULO");
                            Console.WriteLine("Voto registrado como NULO.");
                        }
                    }

                    // Perguntar se deseja continuar votando
                    Console.Write("\nDeseja continuar votando? (s/n): ");
                    string continuar = Console.ReadLine().ToLower().Trim();

                    // Atualizar o estado de emVotacao
                    if (continuar == "n") {
                        break; // Encerra o loop
                    } else if (continuar != "s") {
                        Console.WriteLine("\nOpção inválida! Considerando como NÃO. Encerra a votação.");
                        break;
                    }

                }
                Console.WriteLine("\nVotação encerrada. Pressione qualquer tecla para retornar ao menu.");

            }

            Console.ReadKey();


        }// fim da função votar

        static void ContabilizarEExibir(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos, List<string> votos) {

            if (votos.Count == 0) {
                Console.WriteLine("Nenhuma votação foi realizadada. Pressione qualquer tecla para continuar...");
            } else {
                // definir contadores para votos nulos, brancos e válidos
                int votosNulos = 0;
                int votosBrancos = 0;

                // instanciar lista para contar os votos válidos por candidato
                List<int> votosValidos = new List<int>(new int[candidatos.Count]);

                // contabilizar os votos
                foreach (var voto in votos) {
                    if (voto == "BRANCO") {
                        votosBrancos++;
                    } else if (voto == "NULO") {
                        votosNulos++;
                    } else {
                        // Verificar qual candidato recebeu o voto
                        for (int i = 0; i < candidatos.Count; i++) {
                            if (candidatos[i].numeroCandidato == voto) {
                                votosValidos[i]++; // adiciona o voto válido do candidato
                                break;
                            }
                        }
                    }
                }

                // exibir os resultados
                Console.Clear();
                Console.WriteLine("\nResultado da votação:");

                // exibir os votos válidos por candidato
                for (int i = 0; i < candidatos.Count; i++) {
                    Console.WriteLine($"\nCandidato: {candidatos[i].nomeEleitoral}\nNumero: {candidatos[i].numeroCandidato}\nQantidade de votos: {votosValidos[i]}");
                }

                // exibir votos brancos e nulos
                Console.WriteLine($"\nVotos BRANCOS: {votosBrancos}");
                Console.WriteLine($"\nVotos NULOS: {votosNulos}");

                Console.WriteLine("\n\nPressione qualquer tecla para continuar...");

            }
            Console.ReadKey();



        }// fim da função de contabilizar e exibir votos


        //=====================================| SUBMENUS | ==================================================

        static void SubmenuCandidatos(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos) {//submenu relacionado ao gerenciamento de candidatos

            bool voltarAoMenu = false;

            while (!voltarAoMenu) {
                Console.Clear();
                Console.WriteLine("=====| MENU CANDIDATOS | =====");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Exibir");
                Console.WriteLine("3 - Remover");
                Console.WriteLine("0 - Voltar ao Menu");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao) {
                    case "0":

                        Console.WriteLine("Voltando ao menu inicial...");
                        voltarAoMenu = true;
                        break;
                    case "1": //cadastrar candidatos
                        CadastrarCandidato(candidatos);

                        break;

                    case "2": //exibir candidatos cadastrados
                        ExibirCandidatos(candidatos);

                        break;

                    case "3": // remover candidatos
                        RemoverCandidatos(candidatos);

                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();

                        break;
                }// fim do switch


            }// fim do laço while

        }// fim da função submenu de candidatos

        static void SubmenuVotacao(List<(string nomeCompleto, string nomeEleitoral, string partidoPolitico, string numeroCandidato)> candidatos, List<string> votos) {
            // submenu relacionado ao gerenciamento da votação

            bool voltarAoMenu = false;

            while (!voltarAoMenu) {

                Console.Clear();
                Console.WriteLine("=====| MENU VOTAÇÃO | =====");
                Console.WriteLine("1 - Iniciar Votação");
                Console.WriteLine("2 - Apuração de Votos");
                Console.WriteLine("0 - Voltar ao Menu");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao) {
                    case "0":
                        Console.WriteLine("Voltando ao menu inicial...");
                        voltarAoMenu = true;
                        break;

                    case "1": //inciar votação
                        Votar(candidatos, votos);

                        break;

                    case "2": //apuração de votos
                        ContabilizarEExibir(candidatos, votos);
                        break;


                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();

                        break;
                }// fim do switch
            }
        }


    }
}
