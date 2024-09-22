using System;
using System.Threading;
using System.Numerics;
using System.IO;
namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você quer fazer?");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar novo arquivo (ESC para sair)");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());
            Console.ReadKey();
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;

            }
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual arquivo deseja abrir?");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);

            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto");
            Console.WriteLine("-----------");
            Console.WriteLine("");
            System.String text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);

        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("EEm qual lugar você deseja salvar ?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"Salvo com sucesso no {path}");
            Thread.Sleep(1000);
            Menu();
        }

    }
}