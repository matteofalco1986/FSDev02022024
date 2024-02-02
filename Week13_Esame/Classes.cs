using System.Globalization;

namespace MyClasses
{
    public class Contribuente
    {
        // ---------- FIELDS -------------
        private string _nome;
        private string _cognome;
        private DateTime _dataNascita;
        private string _codiceFiscale;
        private string _sesso;
        private string _comuneResidenza;
        private double _redditoAnnuale;

        // --------- PROPERTIES -----------
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length > 0)
                {
                    _nome = value.ToUpper();
                }
                else
                {
                    throw new Exception("Il nome deve essere di almeno un carattere");
                }
                foreach(var letter in value)
                {
                    if(Array.IndexOf(Generic.Alphabet, letter) == -1){
                        throw new Exception("Il nome non può contenere numeri, spazi o caratteri speciali");
                    }
                }  
            }
        }
        public string Cognome
        {
            get
            {
                return _cognome;
            }
            set
            {
                if (value.Length > 0)
                {
                    _cognome = value.ToUpper();
                }
                else
                {
                    throw new Exception("Il cognome deve essere di almeno un carattere");
                }
                foreach (var letter in value)
                {
                    if (Array.IndexOf(Generic.Alphabet, letter) == -1)
                    {
                        throw new Exception("Il cognome non può contenere numeri, spazi o caratteri speciali");
                    }
                }
            }
        }
        public string DataNascita
        {
            get
            {
                return _dataNascita.ToString("dd/mm/yyyy");
            }
            set
            {
                try
                {
                    _dataNascita = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                }
                catch
                {
                    throw new Exception("Il formato di data non è corretto");
                }
            }
        }
        public string CodiceFiscale
        {
            get
            {
                return _codiceFiscale;
            }
            set
            {
                if (value.Length != 16)
                {
                    throw new Exception("Il codice fiscale deve essere di 16 caratteri");
                }
                _codiceFiscale = value.ToUpper();
            }
        }
        public string Sesso
        {
            get
            {
                return _sesso;
            }
            set
            {
                if (value.ToLower() != "m" && value.ToLower() != "f")
                {
                    throw new Exception("Il valore per il sesso deve corrispondere a 'm' o 'f'");
                }
                _sesso = value;
            }
        }
        public string ComuneResidenza
        {
            get
            {
                return _comuneResidenza;
            }
            set
            {
                if (value.Length > 0)
                {
                    _comuneResidenza = value.ToUpper();
                }
                else
                {
                    throw new Exception("Entra un valore valido per il comune di residenza");
                }
            }
        }
        public double RedditoAnnuale
        {
            get
            {
                return Math.Round(_redditoAnnuale, 2);
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Il reddito deve essere un valore positivo");
                }
                _redditoAnnuale = Math.Round(value, 2);
            }
        }

        // --------- PROCEDURES -------------
        // Riempie i campi del nuovo utente
        public void SetFields()
        {
            bool isCorrect = false;

            // Settare il nome
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Nome: ");
                    Nome = Console.ReadLine();
                    isCorrect = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Settare e controllare il cognome
            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Cognome: ");
                    Cognome = Console.ReadLine();
                    isCorrect = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Settare e controllare la data
            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Data di nascita. gg/mm/yyyy: ");
                    DataNascita = Console.ReadLine();
                    isCorrect = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }
            }

            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Codice Fiscale: ");
                    CodiceFiscale = Console.ReadLine();
                    isCorrect = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Settare il sesso
            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Sesso. M o F: ");
                    Sesso = Console.ReadLine();
                    isCorrect = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Comune di residenza: ");
                    ComuneResidenza = Console.ReadLine();
                    isCorrect = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            // Settare e controllare il reddito

            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Reddito annuale: ");
                    RedditoAnnuale = double.Parse(Console.ReadLine());
                    isCorrect = true;
                }
                catch
                {
                    Console.WriteLine("Devi inserire un valore numerico valido");
                }
            }
        }

        // Stampa il riepilogo dati utente e tasse da pagare
        public void PrintTaxesToPay()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("Calcolo dell'imposta da versare");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"nato il {DataNascita} ({Sesso.ToUpper()}),");
            Console.WriteLine($"residente in {ComuneResidenza},");
            Console.WriteLine($"codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale} €");
            Console.WriteLine($"IMPOSTA DA VERSARE: {CalculateTaxes()} €");
        }

        // Chiede se l'utente vuole calcolare altre tasse
        public void CalculateMore()
        {
            bool isAnswerCorrect = false;
            while (!isAnswerCorrect)
            {
                Console.Write("\nVuoi calcolare le tue tasse in base ad un altro reddito? Y o N: ");
                string userAnswer = Console.ReadLine().ToLower();
                switch (userAnswer)
                {
                    case "n":
                        // Termina programma
                        Console.Clear();
                        Console.WriteLine("\nGrazie per aver usato il nostro calcolatore di tasse");
                        isAnswerCorrect = true;
                        return;
                    case "y":
                        // Input di reddito alternativo e ricalcolo
                        Console.Clear();
                        Console.Write("\nInserisci il tuo reddito annuo: ");
                        try
                        {
                            RedditoAnnuale = double.Parse(Console.ReadLine());
                            PrintTaxesToPay();
                        }
                        catch
                        {
                            Console.WriteLine("Devi inserire un valore numerico valido");
                        }
                        break;
                    default:
                        Console.WriteLine("La risposta non è corretta. Rispondi y o n");
                        break;
                }
            }
        }

        // -------- FUNCTIONS ---------
        public double CalculateTaxes()
        {
            double exceedAmount = 0;
            double taxesToPay = 0; ;
            if (RedditoAnnuale > FasceReddito.Fascia5)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia5) * Aliquota.Fascia5;
                taxesToPay = ImpostaBase.Fascia5 + exceedAmount;
            }
            else if (RedditoAnnuale > FasceReddito.Fascia4)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia4) * Aliquota.Fascia4;
                taxesToPay = ImpostaBase.Fascia4 + exceedAmount;

            }
            else if (RedditoAnnuale > FasceReddito.Fascia3)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia3) * Aliquota.Fascia3;
                taxesToPay = ImpostaBase.Fascia3 + exceedAmount;

            }
            else if (RedditoAnnuale > FasceReddito.Fascia2)
            {
                exceedAmount = (RedditoAnnuale - FasceReddito.Fascia2) * Aliquota.Fascia2;
                taxesToPay = ImpostaBase.Fascia2 + exceedAmount;

            }
            else
            {
                exceedAmount = RedditoAnnuale * Aliquota.Fascia1;
                taxesToPay = exceedAmount;

            }
            return Math.Round(taxesToPay, 2);

        }

        // -------- CONSTRUCTORS --------
        public Contribuente()
        {
            SetFields();
        }
    }

    // ---------- CLASSI CON VARIABILI STATICHE -------------
    public class FasceReddito
    {
        public static double Fascia2
        {
            get
            {
                return 15000;
            }
        }
        public static double Fascia3
        {
            get
            {
                return 28000;
            }
        }
        public static double Fascia4
        {
            get
            {
                return 55000;
            }
        }
        public static double Fascia5
        {
            get
            {
                return 75000;
            }
        }
    }
    public class Aliquota
    {
        public static double Fascia1
        {
            get
            {
                return 0.23;
            }
        }
        public static double Fascia2
        {
            get
            {
                return 0.27;
            }
        }
        public static double Fascia3
        {
            get
            {
                return 0.38;
            }
        }
        public static double Fascia4
        {
            get
            {
                return 0.41;
            }
        }
        public static double Fascia5
        {
            get
            {
                return 0.43;
            }
        }
    }
    public class ImpostaBase
    {
        public static double Fascia2
        {
            get
            {
                return 3450;
            }
        }
        public static double Fascia3
        {
            get
            {
                return 6960;
            }
        }
        public static double Fascia4
        {
            get
            {
                return 17220;
            }
        }
        public static double Fascia5
        {
            get
            {
                return 25420;
            }
        }

    }
    public class Generic
    {
        private static char[] _alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


    public static char[] Alphabet
        {
            get
            {
                return _alphabet;
            }
        }
        public static void WelcomeUser()
        {
            Console.Clear();
            Console.Write("\nBenvenuto nel calcolatore di tasse. Usa questo strumento per calcolare le imposte dovute al tuo beneamato fisco. Premi un tasto qualsiasi per continuare");
            Console.ReadKey();
            Console.Clear();
        }
    }

}