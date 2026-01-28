using System;
using System.Security.Cryptography;
using System.Text;

namespace TechTutorPlay
{
    public class Security
    {
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 100000;
        
        // Hash della password "TechTutor2026" con salt generato
        // Questo è solo un esempio - in produzione useresti un database
        private const string AdminPasswordHash = "YOUR_HASH_HERE"; // Genera usando HashPassword()

        public bool Login(string inputPassword)
        {
            if (string.IsNullOrWhiteSpace(inputPassword))
            {
                Console.WriteLine("[SECURITY] ERRORE: Password non valida.");
                return false;
            }

            // Per questo esempio, usa il metodo semplice SHA256
            // In produzione usa VerifyPassword() con PBKDF2
            if (VerifyPasswordSimple(inputPassword))
            {
                Console.WriteLine("[SECURITY] Accesso autorizzato. Benvenuto nel sistema.");
                return true;
            }
            else
            {
                Console.WriteLine("[SECURITY] ERRORE: Password errata. Accesso negato.");
                return false;
            }
        }

        // Metodo semplificato per il tuo progetto attuale
        private bool VerifyPasswordSimple(string inputPassword)
        {
            string inputHash = ComputeSHA256Hash(inputPassword);
            string correctHash = ComputeSHA256Hash("TechTutor2026");
            return inputHash.Equals(correctHash, StringComparison.OrdinalIgnoreCase);
        }

        private string ComputeSHA256Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString();
            }
        }

        // Metodi avanzati per PBKDF2 (usa questi in produzione)
        public string HashPassword(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                var key = algorithm.GetBytes(KeySize);
                var salt = algorithm.Salt;
                
                var hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(key, 0, hashBytes, SaltSize, KeySize);
                
                return Convert.ToBase64String(hashBytes);
            }
        }
        
        public bool VerifyPassword(string password, string hash)
        {
            var hashBytes = Convert.FromBase64String(hash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);
                
                for (int i = 0; i < KeySize; i++)
                {
                    if (hashBytes[SaltSize + i] != keyToCheck[i])
                        return false;
                }
                return true;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Security security = new Security();
            
            Console.WriteLine("=== Sistema di Sicurezza TechTutor ===");
            
            // Opzione per generare hash (decommentare per testare)
            // string hash = security.HashPassword("TechTutor2026");
            // Console.WriteLine($"Hash generato: {hash}");
            
            Console.Write("Inserisci la password: ");
            string password = ReadPasswordSecurely();
            Console.WriteLine();
            
            security.Login(password);
            
            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }

        private static string ReadPasswordSecurely()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Length--;
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return password.ToString();
        }
    }
}
public void LogAttempt(string username, bool success)
{
    string status = success ? "SUCCESS" : "FAILED";
    // Stampa la data e l'ora del tuo PC fisico
    Console.WriteLine($"[{DateTime.Now}] Login Attempt for {username}: {status}");
}