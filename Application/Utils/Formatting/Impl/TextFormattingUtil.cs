using System.Globalization;
using System.Text;
using Application.DTOs.ObservationDTO;

namespace Application.Utils.Formatting.Impl;

public class TextFormattingUtil : ITextFormattingUtil
{
    public string? Format(string? text)
    {
        if (text == null) return null;
        
        string formattedText = text.Normalize(NormalizationForm.FormD);
        StringBuilder normalizedText = new StringBuilder();

        foreach (char c in formattedText)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                normalizedText.Append(c);
            }
        }

        return normalizedText.ToString().Normalize(NormalizationForm.FormC);
    }

    public IEnumerable<CreateObservationDto> CaptureText(string text)
    {
        string[] observations = text.Split(';');
        
        ICollection<CreateObservationDto> dtos = [];
        foreach (var observation in observations)
        {
            dtos.Add(new CreateObservationDto(observation.Trim()));
        }
        
        return dtos;
    }
}