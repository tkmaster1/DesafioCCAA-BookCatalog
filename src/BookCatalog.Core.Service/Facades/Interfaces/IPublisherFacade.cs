using BookCatalog.Core.Service.DTOs;

namespace BookCatalog.Core.Service.Facades.Interfaces;

public interface IPublisherFacade : IDisposable
{
    /// <summary>
    /// Listar todas as editoras
    /// </summary>
    /// <returns></returns>
    Task<IList<PublisherDTO>> ListAllPublishers();

    /// <summary>
    /// Listar todas as editoras ativos
    /// </summary>
    /// <returns></returns>
    Task<IList<PublisherDTO>> ListAllPublishersActive();

    /// <summary>
    /// Obter por código
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<PublisherDTO> GetPublishersByCode(int code);
}