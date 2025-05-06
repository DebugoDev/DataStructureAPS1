using APS1.Classes;
using APS1.Enums;

internal class Program
{
    private static int _counter = 1;
    private static readonly Random _random = new();

    private static void Main(string[] args)
    {
        while (_counter != 0)
        {
            _counter++;
            
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nHOSPITAL");

            Console.ResetColor();

            if (Hospital.CurrentHospital.TriageQueue.Count != 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                var patient = Hospital.CurrentHospital.TriageQueue.Dequeue();

                Console.WriteLine($"\n{patient} for triage");
                Console.WriteLine($"Counter {_random.Next(1, 8)}\n");

                Console.ResetColor();

                Hospital.CurrentHospital.RegisterTriage(patient);

                continue;
            }

            if (Hospital.CurrentHospital.GetClinicalCareQueue().Any() && _counter % 3 == 0)
            {
                var triage = Hospital.CurrentHospital.DequeueClinicalCarePatient() ?? throw new Exception("Something went wrong!");

                Console.BackgroundColor = triage.TriagePriority switch
                {
                    ETriagePriority.RED => ConsoleColor.Red,
                    ETriagePriority.YELLOW => ConsoleColor.Yellow,
                    ETriagePriority.GREEN => ConsoleColor.Green,
                    _ => ConsoleColor.White
                };
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine($"\n{triage.Patient} for clinical care");
                Console.WriteLine($"Counter {_random.Next(1, 8)}\n");

                Console.ResetColor();

                continue;
            }

            Console.WriteLine("Clinical care queue:");
            Hospital.CurrentHospital.LogClinicalCareQueue();

            Console.Write("Your cpf: ");
            var cpf = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cpf)) continue;

            Hospital.CurrentHospital.RegisterPatient(cpf);
        }
    }
}