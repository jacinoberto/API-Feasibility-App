using Application.DTOs.ObservationDTO;

namespace Application.Utils.Formatting;

public interface ITextFormattingUtil
{
    string? Format(string? text);
    IEnumerable<CreateObservationDto> CaptureText(string text);
}