/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using CBTPRDM_TP03.Models;

namespace CBTPRDM_TP03.Services;

/// <summary>Simula uma consulta de rastreamento usando dados fictícios.</summary>
public class MockTrackingService : ITrackingService
{
    public async Task<PackageModel?> GetPackageAsync(string packageId)
    {
        // Simula a latência de uma chamada de rede
        await Task.Delay(800);

        var now = DateTime.Now;

        var packages = new List<PackageModel>
        {
            new()
            {
                PackageId = "LGX-48215",
                Status = "Em rota",
                ShippingDate = now.AddDays(-4),
                EstimatedDeliveryDate = now.AddDays(3),
                CurrentLocation = "Hub regional - Campinas/SP",
                History =
                {
                    new TrackingEvent { Date = now.AddDays(-4), Description = "Pedido recebido pela transportadora", Location = "Curitiba/PR" },
                    new TrackingEvent { Date = now.AddDays(-3), Description = "Coletado no remetente", Location = "Curitiba/PR" },
                    new TrackingEvent { Date = now.AddDays(-1), Description = "Em rota para o hub regional", Location = "Rodovia Régis Bittencourt" },
                    new TrackingEvent { Date = now.AddHours(-6), Description = "Recebido no hub regional", Location = "Campinas/SP" }
                }
            },
            new()
            {
                PackageId = "TRK-90317",
                Status = "Entregue",
                ShippingDate = now.AddDays(-7),
                EstimatedDeliveryDate = now.AddDays(-2),
                CurrentLocation = "Endereço do destinatário - Recife/PE",
                History =
                {
                    new TrackingEvent { Date = now.AddDays(-7), Description = "Coletado no remetente", Location = "Belo Horizonte/MG" },
                    new TrackingEvent { Date = now.AddDays(-5), Description = "Transferido para o centro de triagem", Location = "Salvador/BA" },
                    new TrackingEvent { Date = now.AddDays(-3), Description = "Entrega em andamento", Location = "Recife/PE" },
                    new TrackingEvent { Date = now.AddDays(-2), Description = "Entregue ao destinatário", Location = "Recife/PE" }
                }
            },
            new()
            {
                PackageId = "MVP-27064",
                Status = "Coletado",
                ShippingDate = now.AddHours(-10),
                EstimatedDeliveryDate = now.AddDays(5),
                CurrentLocation = "Ponto de coleta - Porto Alegre/RS",
                History =
                {
                    new TrackingEvent { Date = now.AddHours(-10), Description = "Coletado no remetente", Location = "Porto Alegre/RS" }
                }
            },
            new()
            {
                PackageId = "ENT-55102",
                Status = "Entrega não realizada",
                ShippingDate = now.AddDays(-6),
                EstimatedDeliveryDate = now.AddDays(1),
                CurrentLocation = "Unidade de entrega - Goiânia/GO",
                History =
                {
                    new TrackingEvent { Date = now.AddDays(-6), Description = "Coletado no remetente", Location = "Florianópolis/SC" },
                    new TrackingEvent { Date = now.AddDays(-3), Description = "Chegou à unidade de entrega", Location = "Goiânia/GO" },
                    new TrackingEvent { Date = now.AddDays(-1), Description = "Tentativa de entrega sem sucesso: destinatário ausente", Location = "Goiânia/GO" }
                }
            }
        };

        return packages.FirstOrDefault(p =>
            string.Equals(p.PackageId, packageId, StringComparison.OrdinalIgnoreCase));
    }
}
