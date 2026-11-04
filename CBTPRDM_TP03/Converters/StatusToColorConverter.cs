/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using System.Globalization;

namespace CBTPRDM_TP03.Converters;

/// <summary>Converte o texto do status em uma cor para o selo de status.</summary>
public class StatusToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value as string)?.ToLowerInvariant() switch
        {
            "entregue" => Color.FromArgb("#2E7D32"),               // verde
            "em rota" => Color.FromArgb("#1565C0"),                // azul
            "coletado" => Color.FromArgb("#6A1B9A"),               // roxo
            "entrega não realizada" => Color.FromArgb("#C62828"),  // vermelho
            _ => Color.FromArgb("#616161")                         // cinza
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
