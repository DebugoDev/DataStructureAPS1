using System.Text.RegularExpressions;
using APS1.Enums;

namespace APS1.Classes;

public partial class Patient(string cpf, string CompleteName)
{
    public string Cpf { get; set; } = CpfService.FormatAndValidateCpf(cpf) ?? throw new InvalidDataException("Invalid CPF");
    public string CompleteName { get; set; } = CompleteName;
    public List<Triage> TriageHistory { get; set; } = [];

    public IEnumerable<Triage> RegisterNewTriage(BloodPressure bloodPressure, double temperature, ETriagePriority triagePriority)
        => TriageHistory.Append(new Triage(this, bloodPressure, temperature, triagePriority));

    public override string ToString() => $"{CompleteName} [{Cpf}]";

    public static partial class CpfService
    {
        [GeneratedRegex("[^0-9]")]
        private static partial Regex NonDigitRegex();

        [GeneratedRegex(@"^(\d)\1{10}$")]
        private static partial Regex RepeatedDigitsRegex();

        [GeneratedRegex(@"(\d{3})(\d{3})(\d{3})(\d{2})")]
        private static partial Regex CpfFormattingRegex();

        public static string? FormatAndValidateCpf(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string cpf = NonDigitRegex().Replace(input, "");

            if (cpf.Length != 11 || RepeatedDigitsRegex().IsMatch(cpf))
                return null;

            if (!IsValidDigit(cpf, 9) || !IsValidDigit(cpf, 10))
                return null;

            return CpfFormattingRegex().Replace(cpf, "$1.$2.$3-$4");
        }

        private static bool IsValidDigit(string cpf, int position)
        {
            int sum = 0;
            int weight = position + 1;

            for (int i = 0; i < position; i++)
                sum += (cpf[i] - '0') * weight--;

            int remainder = sum * 10 % 11;
            if (remainder == 10) remainder = 0;

            return remainder == (cpf[position] - '0');
        }
    }
}