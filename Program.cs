using System;
using System.Collections.Generic;
using TechTutorPlay.Models;

namespace TechTutorPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creiamo un database virtuale usando una lista di oggetti "Student"
            List<Student> databaseStudenti = new List<Student>();

            // Aggiungiamo te come amministratore e primo studente
            databaseStudenti.Add(new Student(1, "Daniele", "admin@techtutorplay.tech"));
            databaseStudenti.Add(new Student(2, "Marco Rossi", "marco@example.com"));

            Console.WriteLine("=== TechTutorPlay Enterprise Manager ===");

            // Simuliamo l'iscrizione automatica per tutti gli studenti nel database
            foreach (var s in databaseStudenti)
            {
                s.Enroll();
                Console.WriteLine($"Studente: {s.Name} | Email: {s.Email} | Status: {(s.IsEnrolled ? "Attivo" : "Inattivo")}");
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Operazione completata. Sistema in attesa...");
            Console.ReadKey();
        }
    }
}
