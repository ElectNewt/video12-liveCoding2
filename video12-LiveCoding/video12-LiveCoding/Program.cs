using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace video12_LiveCoding
{
    class Program
    {
        /*
         * 
         * Introducir por pantalla una fecha en formato año, mes dia y mostrar por pantalla 
         * Fecha del log: {diaSemana}, {numerodiaMes} de {mesConNombre} de {año}; 

cada vez que imprimamos algo por pantalla debemos escribirlo en un fichero como si fuera un log.

         */
        static string path = @"c:\Ejemplos\Log-Video11.log";

        static void Main(string[] args)
        {
            Console.WriteLine("por favor introduce una fecha en formato yyyyMMdd");
            string fechaIntroducida = Console.ReadLine();
            var fecha = DateTime.ParseExact(fechaIntroducida, "yyyyMMdd", new CultureInfo("es-ES"));

            string texto = $"Fecha de log: {fecha.DayOfWeek}, {fecha.Day} de {fecha.ToString("MMMM")} de {fecha.Year}";
            Console.WriteLine(texto);
            EscribirLog(texto);
            Console.ReadKey();
        }

        public static void EscribirLog(string mensaje)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }
            File.AppendAllLines(path, new List<string> { mensaje });

        }

    }
}
