using APS1.Enums;

namespace APS1.Classes;

public class Hospital
{
    public static Hospital CurrentHospital { get; private set; } = new();
    public Queue<Patient> TriageQueue = new();

    private readonly PriorityQueue<Triage, int> _priorityQueue = new();
    public Dictionary<string, Patient> RegisteredPatients { get; set; } = [];

    public IEnumerable<Triage> GetClinicalCareQueue()
    {
        var clone = new List<Triage>(_priorityQueue.UnorderedItems.Select(i => i.Element));
        return clone.OrderBy(t => (int)t.TriagePriority);
    }

    public Triage? DequeueClinicalCarePatient()
    {
        return _priorityQueue.TryDequeue(out var triage, out _) ? triage : null;
    }

    public void LogTriageQueue()
    {
        var patientsQueue = TriageQueue
            .Select((patient, index) => $"{index + 1}. {patient.CompleteName}");

        Console.WriteLine(string.Join('\n', patientsQueue));
    }

    public void LogClinicalCareQueue()
    {
        var patientsQueue = GetClinicalCareQueue()
            .Select((triage, index) => $"{index + 1}. {triage.Patient.CompleteName}");

        Console.WriteLine(string.Join('\n', patientsQueue));
    }

    public void RegisterPatient(string cpf)
    {
        var patient = GetPatientByCpf(cpf);

        if (patient is null)
        {
            Console.Write("Complete name: ");
            patient = new Patient(cpf, Console.ReadLine() ?? "Unknown");

            RegisteredPatients.Add(patient.Cpf, patient);
        }

        TriageQueue.Enqueue(patient);
        Console.WriteLine($"{patient.CompleteName} wait for your name to be called.");
    }

    public void RegisterTriage(Patient patient)
    {
        Console.Write("Systolic pressure (e.g. 12): ");
        var systolic = int.Parse(Console.ReadLine()!);

        Console.Write("Diastolic pressure (e.g. 8): ");
        var diastolic = int.Parse(Console.ReadLine()!);

        Console.Write("Temperature (e.g. 36.5): ");
        var temperature = double.Parse(Console.ReadLine()!);

        var bloodPressure = new BloodPressure(systolic, diastolic);

        var priority = (systolic, diastolic, temperature) switch
        {
            var (sys, dia, temp) when sys <= 17 && temp <= 38 => ETriagePriority.GREEN,
            var (sys, dia, temp) when sys <= 18 && temp <= 39 => ETriagePriority.YELLOW,
            _ => ETriagePriority.RED
        };

        var newTriage = patient.RegisterNewTriage(bloodPressure, temperature, priority).Last();
        _priorityQueue.Enqueue(newTriage, (int)priority);

        Console.WriteLine($"Triage registered with priority {priority}.");
        Console.WriteLine($"{patient.CompleteName} wait for your name to be called.");
    }

    public Patient? GetPatientByCpf(string cpf)
    {
        var validatedCpf = Patient.CpfService.FormatAndValidateCpf(cpf) ?? throw new InvalidDataException("Invalid CPF");
        return RegisteredPatients.TryGetValue(validatedCpf, out var patient) ? patient : null;
    }

    public static Hospital ResetHospital()
    {
        CurrentHospital = new();
        return CurrentHospital;
    }
}
