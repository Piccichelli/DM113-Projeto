using ConsultaServiceSoap;
using System;
using System.Data;

namespace TerminalSecretaria
{
    class Program
    {
        static ConsultaServiceClient client = new ConsultaServiceClient(
        ConsultaServiceClient.EndpointConfiguration.BasicHttpBinding_IConsultaService, "http://localhost:5288/Service.asmx");
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== SECRETÁRIA VIRTUAL ===");
                Console.WriteLine("1. Listar consultas");
                Console.WriteLine("2. Cadastrar nova consulta");
                Console.WriteLine("3. Buscar consulta por id");
                Console.WriteLine("4. Atualizar consulta");
                Console.WriteLine("5. Deletar uma consulta");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                Console.Clear();
                switch (opcao)
                {
                    case "1":
                        ListarConsultas();
                        break;
                    case "2":
                        CadastrarConsulta();
                        break;
                    case "3":
                        BuscarConsulta();
                        break;
                    case "4":
                        AtualizarConsulta();
                        break;
                    case "5":
                        DeletarConsulta();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }


            }
        }

        static void ListarConsultas()
        {
            var consultas = client.GetConsultasAsync().GetAwaiter().GetResult();
            if (consultas.Length == 0)
            {
                Console.WriteLine("Nenhuma consulta agendada.");
            }
            
            foreach (var consulta in consultas)
            {
                Console.WriteLine($"\nData: {consulta.Data}");
                Console.WriteLine($"Nome: {consulta.Cliente.Nome}");
                Console.WriteLine($"Telefone: {consulta.Cliente.Telefone}");
                Console.WriteLine($"Id consulta: {consulta.Id}\n");
            }
        }

        static void CadastrarConsulta()
        {
            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Email (opcional): ");
            string email = Console.ReadLine();
            Console.WriteLine("Data da consulta (dd/mm/aaaa hh:mm)");
            string data = Console.ReadLine();
            DateTime dataDateTime = DateTime.Parse(data);


            var cliente = new ClienteModel
            {
                Nome = nome,
                Telefone = telefone,
                Email = email
            };

            var consulta = new ConsultaItem
            {
                Data = dataDateTime,
                Cliente = cliente
            };

            client.CreateConsultaItemAsync(consulta);
            Console.WriteLine("Consulta cadastrada com sucesso!");
        }

        static void AtualizarConsulta()
        {
            Console.WriteLine("Id da consulta a ser atualizada:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Email (opcional): ");
            string email = Console.ReadLine();
            Console.WriteLine("Data da consulta (dd/mm/aaaa hh:mm)");
            string data = Console.ReadLine();
            DateTime dataDateTime = DateTime.Parse(data);


            var cliente = new ClienteModel
            {
                Nome = nome,
                Telefone = telefone,
                Email = email
            };

            var consulta = new ConsultaItem
            {
                Data = dataDateTime,
                Cliente = cliente
            };
            consulta.Id = id;

            client.UpdateConsultaItemAsync(consulta);
            Console.WriteLine("Consulta atualizada com sucesso!");
        }

        static void BuscarConsulta()
        {
            Console.Write("Digite o id da consulta: ");
            int id = int.Parse(Console.ReadLine());

            var consulta = client.GetConsultaPorIdAsync(id).GetAwaiter().GetResult();
            
            if (consulta == null)
            {
                Console.WriteLine("Consulta não encontrada.");
            }
            else
            {
                Console.WriteLine($"Data: {consulta.Data}");
                Console.WriteLine($"Nome: {consulta.Cliente.Nome}");
                Console.WriteLine($"Telefone: {consulta.Cliente.Telefone}");
                Console.WriteLine($"Email: {consulta.Cliente.Email}");
            }
        }

        static void DeletarConsulta()
        {
            Console.Write("Digite o id da consulta para deletar: ");
            int id = int.Parse(Console.ReadLine());

            // Como o método é async, bloqueie esperando o resultado
            client.DeleteConsultaItemAsync(id).GetAwaiter().GetResult();
        }
    }
}