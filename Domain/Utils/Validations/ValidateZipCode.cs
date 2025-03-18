using Domain.Exceptions;
using Domain.Utils.Formatting;
using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Utils.Validations;

public class ValidateZipCode
{
    public static void Validation(string? zipCode, string? street, int? number, string? area, string? city)
    {
        ZipCodeIsValid(zipCode);
        StreetIsValid(street);
        NumberIsValid(number);
        AreaIsValid(area);
        CityIsValid(city);
    }

    private static void ZipCodeIsValid(string? zipCode)
    {
        if (string.IsNullOrEmpty(zipCode)) return;
        
        zipCode = FormatContent.RemovePunctuation(zipCode);
        InvalidDataException.When(zipCode.Length > 8, "O CEP não pode ter mais de 8 digitos.");
        InvalidDataException.When(zipCode.Length < 8, "O CEP não pode ter menos de 8 digitos.");
    }

    private static void StreetIsValid(string? street)
    {
        if (string.IsNullOrEmpty(street)) return;
        
        street = FormatContent.NormalizeText(street);
        InvalidDataException.When(street.Length < 3, "A rua deve ter no minimo 3 caracteres.");
        InvalidDataException.When(street.Length > 100, "A rua não pode ter mais de 100 caracteres.");
        
    }

    private static int? NumberIsValid(int? number)
    {
        if (!number.HasValue) return null;
        if (number <= 0) return null;
        return number.Value;
    }
    
    private static void AreaIsValid(string? area)
    {
        if (string.IsNullOrEmpty(area)) return;
        
        area = FormatContent.NormalizeText(area);
        InvalidDataException.When(area.Length < 3, "O bairro deve ter no minimo 3 caracteres.");
        InvalidDataException.When(area.Length > 100, "O bairro não pode ter mais de 100 caracteres.");
        
    }
    
    private static void CityIsValid(string? city)
    {
        if (string.IsNullOrEmpty(city)) return;
        
        city = FormatContent.NormalizeText(city);
        InvalidDataException.When(city.Length < 3, "A rua deve ter no minimo 3 caracteres.");
        InvalidDataException.When(city.Length > 100, "A rua não pode ter mais de 100 caracteres.");
        
    }
}