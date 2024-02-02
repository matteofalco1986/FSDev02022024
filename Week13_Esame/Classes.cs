namespace MyClasses
{
    public class Contribuente
    {
        // FIELDS
        private string _nome;
        private string _cognome;
        private string _dataNascita;
        private string _codiceFiscale;
        private string _sesso;
        private string _comuneResidenza;
        private double _redditoAnnuale;

        // PROPERTIES
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
                    _nome = value;
                }
                else
                {
                    throw new Exception("Il nome deve essere di almeno un carattere");
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
                    _cognome = value;
                }
                else
                {
                    throw new Exception("Il cognome deve essere di almeno un carattere");
                }
            }
        }
        public string DataNascita
        {
            get
            {
                return _dataNascita;
            }
            set
            {
                _dataNascita = value;
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
                _comuneResidenza = value;
            }
        }
        public double RedditoAnnuale
        {
            get
            {
                return _redditoAnnuale;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Il reddito deve essere un valore positivo");
                }
                _redditoAnnuale = value;
            }
        }

        // PROCEDURES
        public void SetFields()
        {
            Console.Write("Nome: ");
            Nome = Console.ReadLine();

            Console.Write("Cognome: ");
            Cognome = Console.ReadLine();

            Console.Write("Data di nascita. gg/mm/yyyy: ");
            DataNascita = Console.ReadLine();

            Console.Write("Codice Fiscale: ");
            CodiceFiscale = Console.ReadLine();

            Console.Write("Sesso. M o F: ");
            Sesso = Console.ReadLine();

            Console.Write("Comune di residenza: ");
            ComuneResidenza = Console.ReadLine();

            Console.Write("Reddito annuale: ");
            RedditoAnnuale = double.Parse(Console.ReadLine());
        }
        public void PrintSummary()
        {
            Console.Clear();
            Console.WriteLine("Grazie per esserti registrato. Ecco qui un riepilogo dei tuoi dati.\n");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cognome: {Cognome}");
            Console.WriteLine($"Data di nascita: {DataNascita}");
            Console.WriteLine($"Codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Comune di residenza: {ComuneResidenza}");
            Console.WriteLine($"Reddito annuale: {RedditoAnnuale} €");
        }

        // CONSTRUCTORS
        public Contribuente()
        {
            SetFields();
        }
    }
    public class FasceReddito
    {
        public static double Min1
        {
            get
            {
                return 0;
            }
        }
        public static double Max1
        {
            get
            {
                return 15000;
            }
        }
        public static double Min2
        {
            get
            {
                return Max1 + 1;
            }
        }
        public static double Max2
        {
            get
            {
                return 28000;
            }
        }
        public static double Min3
        {
            get
            {
                return Max2 + 1;
            }
        }
        public static double Max3
        {
            get
            {
                return 55000;
            }
        }
        public static double Min4
        {
            get
            {
                return Max3 + 1;
            }
        }
        public static double Max4
        {
            get
            {
                return 75000;
            }
        }
        public static double Min5
        {
            get
            {
                return Max4 + 1;
            }
        }
    }
}