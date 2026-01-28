using System;

namespace TechTutorPlay.Models
{
    // Definiamo cosa è uno "Studente" nel nostro sistema
    public class Student
    {
        // Proprietà: i dati che ogni studente possiede
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEnrolled { get; set; } // Indica se è iscritto a un corso

        // Costruttore: serve a creare un nuovo studente in modo rapido
        public Student(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            IsEnrolled = false; // Di base, un nuovo studente non è ancora iscritto
        }

        // Metodo: un'azione che lo studente può compiere
        public void Enroll()
        {
            IsEnrolled = true;
            Console.WriteLine($"[LOG] Lo studente {Name} è stato iscritto con successo.");
        }
    }
}