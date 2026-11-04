/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
namespace CBTPRDM_TP03.Models;

/// <summary>Representa um pacote rastreado.</summary>
public class PackageModel
{
    public string PackageId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ShippingDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public string CurrentLocation { get; set; } = string.Empty;
    public List<TrackingEvent> History { get; set; } = new();
}
