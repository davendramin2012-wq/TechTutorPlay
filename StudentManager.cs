using System;
using System.Collections.Generic;

// Definisce lo spazio dei nomi per il tuo progetto educativo
namespace TechTutorPlay
{
    class Program
    {
        // Il punto di inizio del tuo programma
        static void Main(string[] args)
        {
            // Crea una lista per contenere i nomi degli studenti iscritti
            List<string> classe = new List<string>();

            // Aggiunge alcuni studenti di esempio alla tua classe virtuale
            classe.Add("Daniele");
            classe.Add("Studente Beta");
            classe.Add("Studente Gamma");

            // Stampa un titolo professionale sulla console
            Console.WriteLine("=== TechTutorPlay: Gestione Classe Virtuale ===");
            Console.WriteLine($"Studenti totali iscritti: {classe.Count}");
            Console.WriteLine("---------------------------------------------");

            // Cicla attraverso la lista degli studenti per visualizzarli
            foreach (string studente in classe)
            {
                // Mostra il nome dello studente e simula un ID generato
                Console.WriteLine($"Studente: {studente} | Stato: Attivo");
            }

            // Messaggio finale prima di chiudere il programma
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Sincronizzazione con il database completata.");

            // Aspetta che l'utente prema un tasto prima di chiudere la finestra
            Console.ReadKey();
        }
    }
}
