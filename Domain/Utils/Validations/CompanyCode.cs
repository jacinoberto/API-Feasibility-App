using System.ComponentModel.DataAnnotations;

namespace Domain.Utils.Validations;

public class CompanyCode : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        string? socialSecurity = value.ToString()?.Replace(".", "").Replace("-", "").Trim();
        if (socialSecurity != null && (socialSecurity.Length != 11 || socialSecurity.Distinct().Count() == 1)) return false;

        int[] multiplierOne = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplierTwo = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        
        string hasSocialSecurity = socialSecurity.Substring(0, 9);
        int sum = multiplierOne.Select((m, i) => m * (hasSocialSecurity[i] - '0')).Sum();
        int rest = sum % 11;
        int digitOne = rest < 2 ? 0 : 11 - rest;

        hasSocialSecurity += digitOne;
        sum = multiplierTwo.Select((m, i) => m * (hasSocialSecurity[i] - '0')).Sum();
        rest = sum % 11;
        int digitTwo = rest < 2 ? 0 : 11 - rest;

        return socialSecurity.EndsWith($"{digitOne}{digitTwo}");
    }
}