using AutoMapper;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.Facades.Interfaces;

namespace BookCatalog.Core.Service.Facades;

public class PublisherFacade : IPublisherFacade
{
    #region Properties

    private readonly IMapper _mapper;
    private readonly IPublisherAppService _publisherAppService;

    #endregion

    #region Constructor

    public PublisherFacade(IMapper mapper,
                       IPublisherAppService publisherAppService)
    {
        _mapper = mapper;
        _publisherAppService = publisherAppService;
    }

    #endregion

    #region Methods

    public async Task<PublisherDTO> GetPublishersByCode(int code)
    {
        var publisherDomain = await _publisherAppService.GetByCodeAsync(code);

        return _mapper.Map<PublisherDTO>(publisherDomain);
    }

    public async Task<IList<PublisherDTO>> ListAllPublishers()
    {
        var publisherDomain = await _publisherAppService.ListAllAsync();

        var result = _mapper.Map<IList<PublisherDTO>>(publisherDomain);

        return result;
    }

    public async Task<IList<PublisherDTO>> ListAllPublishersActive()
    {
        var publisherDomain = await _publisherAppService.ListAllActiveAsync();

        var result = _mapper.Map<IList<PublisherDTO>>(publisherDomain);

        return result;
    }

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion
}