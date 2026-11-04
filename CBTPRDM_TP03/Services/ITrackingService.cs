/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using CBTPRDM_TP03.Models;

namespace CBTPRDM_TP03.Services;

public interface ITrackingService
{
    /// <summary>Busca um pacote pelo código. Retorna null se não existir.</summary>
    Task<PackageModel?> GetPackageAsync(string packageId);
}
