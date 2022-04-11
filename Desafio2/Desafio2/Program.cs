using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace Desafio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            List<Supermercado> listaSupermercado = new List<Supermercado>();
            string arquivoJson = File.ReadAllText(@"Lista_Supermercado.txt");

            if (!string.IsNullOrEmpty(arquivoJson))
            {
                listaSupermercado = JsonSerializer.Deserialize<List<Supermercado>>(arquivoJson);
            }

            while (opcao != 4)
            {

                Console.WriteLine("1 - Listar Itens");
                Console.WriteLine("2 - Adicionar Itens");
                Console.WriteLine("3 - Remover Itens");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção Desejada: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (opcao == 1)
                {
                    ListarItens(listaSupermercado, arquivoJson);

                }
                else if (opcao == 2)
                {
                    AdicionarItem(listaSupermercado);
                }
                else if (opcao == 3)
                {
                    RemoverItem(listaSupermercado);
                }
                string jsonString = JsonSerializer.Serialize(listaSupermercado);
                File.WriteAllText(@"Lista_Supermercado.txt", jsonString);
            }
        }

        private static void ListarItens(List<Supermercado> listaSupermercado, string arquivoJson)
        {
            if (string.IsNullOrEmpty(arquivoJson) && listaSupermercado.Count == 0)
            {
                Console.WriteLine("Não há itens na lista");
            }
            else
            {

                Console.WriteLine($"   Identificador\t\t  Id\t\t\t  Nome\t\t\tQuantidade\tCategoria\t\tPreço          Prioridade        Marca     Utilidade       Consumível     Perecível");
                for (int i = 0; i < listaSupermercado.Count; i++)
                {
                    Console.WriteLine($"{i,10}" + "\t  " +
                                      $"{listaSupermercado[i].Id,36}" + "\t" +
                                      $"{listaSupermercado[i].Nome,-20}" + "\t" +
                                      $"{listaSupermercado[i].Quantidade,5}" + "\t\t" +
                                      $"{listaSupermercado[i].Categoria,-20}" + "\t" +
                                      $"{listaSupermercado[i].Preco.ToString("F2", CultureInfo.InvariantCulture),5}" +
                                      $"{listaSupermercado[i].Prioridade,20}" + 
                                      $"{listaSupermercado[i].Marca,15}" + 
                                      $"{listaSupermercado[i].Utilidade,10}" + 
                                      $"{listaSupermercado[i].Consumivel,15}" +
                                      $"{listaSupermercado[i].Perecivel,15}");
                }
                Console.WriteLine();
            }
        }

        public static void AdicionarItem(List<Supermercado> listaSupermercado)
        {
            
            Console.WriteLine("Digite os dados do Produto:");
            Console.WriteLine();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Prioridade (Necessário ou Opcional): ");
            string prioridade = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Utilidade: ");
            string utilidade = Console.ReadLine();
            Console.Write("Consumível(Sim ou Não): ");
            string consumivel = Console.ReadLine();
            Console.WriteLine("Perecível(Sim ou Não): ");
            string perecivel = Console.ReadLine();

            

            listaSupermercado.Add(new Supermercado()
            { Id = Guid.NewGuid().ToString(), Nome = nome, Quantidade = quantidade, Categoria = categoria, Preco = preco, Prioridade = prioridade, Marca = marca, 
                Utilidade = utilidade, Consumivel = consumivel, Perecivel = perecivel });
            Console.Clear();
            
        }

        public static void RemoverItem(List<Supermercado> listaSupermercado)
        {
            Console.Write("Digite o Identificador do item para remove-lo: ");
            int identificador = int.Parse(Console.ReadLine());

            listaSupermercado.RemoveAt(identificador);
            Console.Clear();
        }
    }
}
