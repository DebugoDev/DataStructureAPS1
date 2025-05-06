namespace APS1.Classes;

public struct BloodPressure(int systolic, int diastolic)
{
    public int Systolic { get; set; } = systolic;
    public int Diastolic { get; set; } = diastolic;

    public override readonly string ToString() => $"{Systolic}/{Diastolic} mmHg";
}
