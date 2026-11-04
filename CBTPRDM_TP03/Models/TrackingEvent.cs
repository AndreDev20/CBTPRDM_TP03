/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
namespace CBTPRDM_TP03.Models;

/// <summary>Um evento do histórico de rastreamento (postagem, triagem, entrega...).</summary>
public class TrackingEvent
{
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
