namespace ConsoleCheckPassword {

    internal class Program {

        static void Main(string[] args) {

            bool appRunning = true;

            while (appRunning) {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("ConsoleCheckPassword \n");

                string password = GetPasswordFromInput();

                string resultText = CheckPassword(password) ? "" : "nicht ";            // shortcut if clause >>  (case) ? <true> : <false>
                Console.WriteLine("\nDas Passwort entspricht {0}den Vorgaben", resultText);

                Console.Write("\n\nProgramm beenden (e)? ");
                try {
                    string exitApp = Console.ReadLine();
                    if (exitApp.ToUpper() == "E") {
                        appRunning = false;
                    }
                } catch {
                    Console.WriteLine("Ungültige Eingabe!"); 
                }
            }
        }

        private static string GetPasswordFromInput() {

            string password = "";
            Console.Write("Bitte geben Sie das zu prüfende Passwort ein: ");
            try {
                password = Console.ReadLine();
            } catch {
                // no error message, just keep going and repeat the app 
            }

            return password;
        }

        private static bool CheckPassword(string password) {
            
            bool isValid = true;
            string[] pwChars = { 
                "0123456789",
                "!^\"°§$%&/()=?´`\\}][{µ€~+*#'-_.:,;<>|@ ",
                "abcdefghijklmnopqrstuvwxyzßöäü",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZÖÄÜ" 
            };
            string[] pwText = { 
                "Ziffern:", 
                "Sonderzeichen:", 
                "Kleinbuchstaben:", 
                "Großbuchstaben:", 
                "Länge:" 
            };
            int[] pwCharSums = { 0, 0, 0, 0, password.Length }; 

            // count chartypes
            for (int i = 0; i < password.Length; i++) {
                for (int j = 0; j < pwChars.Length; j++) {
                    if (pwChars[j].Contains(password[i].ToString())) {
                        pwCharSums[j]++;
                    }
                }
            }

            // output + check chartype sums
            Console.WriteLine();
            for (int i = 0; i < pwCharSums.Length; i++) {
                Console.WriteLine("  {0,-17}{1,3}", pwText[i], pwCharSums[i]);
                if (pwCharSums[i] == 0) {
                    isValid = false;
                }
            }
            if (password.Length < 8) {
                isValid = false;
            }
            
            return isValid;
        }
    }
}
