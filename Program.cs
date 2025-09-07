using System;
using System.Collections.Generic;

class Program
{
    // Diccionario para almacenar las disciplinas y sus deportistas.
    // La clave es la disciplina (string) y el valor es un conjunto de deportistas (HashSet<string>).
    static Dictionary<string, HashSet<string>> disciplinasDeportistas = new Dictionary<string, HashSet<string>>();

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║      SISTEMA DE PREMIACIÓN DEPORTIVA  ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.WriteLine("\nMenú de Opciones:");
            Console.WriteLine("1. Agregar deportista a una disciplina");
            Console.WriteLine("2. Consultar deportistas por disciplina");
            Console.WriteLine("3. Visualizar todas las disciplinas y deportistas");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarDeportista();
                    break;
                case "2":
                    ConsultarDeportistas();
                    break;
                case "3":
                    VisualizarTodo();
                    break;
                case "4":
                    continuar = false;
                    Console.WriteLine("\nSaliendo del programa. ¡Gracias!");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal.");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Permite agregar un deportista a una disciplina específica.
    /// </summary>
    static void AgregarDeportista()
    {
        Console.Clear();
        Console.WriteLine("--- AGREGAR DEPORTISTA ---");
        Console.Write("Ingrese el nombre de la disciplina (Ej: Natación): ");
        string disciplina = Console.ReadLine().Trim();

        Console.Write("Ingrese el nombre del deportista: ");
        string deportista = Console.ReadLine().Trim();

        if (string.IsNullOrEmpty(disciplina) || string.IsNullOrEmpty(deportista))
        {
            Console.WriteLine("\nError: La disciplina y el nombre del deportista no pueden estar vacíos.");
            return;
        }

        // Si la disciplina no existe, la crea con un nuevo HashSet.
        if (!disciplinasDeportistas.ContainsKey(disciplina))
        {
            disciplinasDeportistas[disciplina] = new HashSet<string>();
            Console.WriteLine($"\nLa disciplina '{disciplina}' ha sido creada.");
        }

        // Añade el deportista al HashSet. Add() devuelve false si ya existe.
        if (disciplinasDeportistas[disciplina].Add(deportista))
        {
            Console.WriteLine($"\n'{deportista}' ha sido agregado a la disciplina de '{disciplina}'.");
        }
        else
        {
            Console.WriteLine($"\n'{deportista}' ya existe en la disciplina de '{disciplina}'.");
        }
    }

    /// <summary>
    /// Consulta y muestra todos los deportistas de una disciplina.
    /// </summary>
    static void ConsultarDeportistas()
    {
        Console.Clear();
        Console.WriteLine("--- CONSULTAR DEPORTISTAS POR DISCIPLINA ---");
        Console.Write("Ingrese el nombre de la disciplina a consultar: ");
        string disciplina = Console.ReadLine().Trim();

        if (disciplinasDeportistas.ContainsKey(disciplina))
        {
            Console.WriteLine($"\nDeportistas en '{disciplina}':");
            // Itera sobre el HashSet para mostrar cada deportista.
            foreach (var d in disciplinasDeportistas[disciplina])
            {
                Console.WriteLine($"- {d}");
            }
        }
        else
        {
            Console.WriteLine($"\nLa disciplina '{disciplina}' no se encuentra registrada.");
        }
    }

    /// <summary>
    /// Muestra todas las disciplinas y sus deportistas.
    /// </summary>
    static void VisualizarTodo()
    {
        Console.Clear();
        Console.WriteLine("--- VISUALIZACIÓN COMPLETA DE DATOS ---");
        if (disciplinasDeportistas.Count == 0)
        {
            Console.WriteLine("No hay disciplinas registradas en el sistema.");
            return;
        }

        // Itera sobre el diccionario para mostrar cada clave-valor.
        foreach (var par in disciplinasDeportistas)
        {
            string disciplina = par.Key;
            HashSet<string> deportistas = par.Value;
            
            Console.WriteLine($"\nDisciplina: {disciplina}");
            if (deportistas.Count > 0)
            {
                Console.WriteLine("  Deportistas:");
                foreach (var d in deportistas)
                {
                    Console.WriteLine($"    - {d}");
                }
            }
            else
            {
                Console.WriteLine("  (No hay deportistas registrados en esta disciplina)");
            }
        }
    }
}