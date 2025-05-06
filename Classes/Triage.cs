using APS1.Enums;

namespace APS1.Classes;

public class Triage(Patient patient, BloodPressure bloodPressure, double temperature, ETriagePriority triagePriority)
{
    public Patient Patient { get; set; } = patient;
    public BloodPressure BloodPressure { get; set; } = bloodPressure;
    public double Temperature { get; set; } = temperature;
    public ETriagePriority TriagePriority { get; set; } = triagePriority;
    public readonly DateTime DateTime = DateTime.Now;
}