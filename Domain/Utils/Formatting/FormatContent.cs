using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Utils.Formatting;

public partial class FormatContent
{
    public static string RemovePunctuation(string value)
    {
        return Regex.Replace(value, @"\D", "");
    }

    public static string NormalizeText(string text)
    {
        // Valida se a variável texto possuí algum valor
        if (string.IsNullOrEmpty(text)) return text;

        // Normaliza os caracteres que contém acento
        var normalize = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var caracter in normalize)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(caracter);
            if (category != UnicodeCategory.NonSpacingMark) // Faz a remoção dos acentos
            {
                stringBuilder.Append(category);
            }
        }
        
        return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();
    }
}