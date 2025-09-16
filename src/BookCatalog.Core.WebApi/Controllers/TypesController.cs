using BookCatalog.Common.Util.Response;
using BookCatalog.Common.Util.Services;
using BookCatalog.Core.Service.Facades.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Core.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class TypesController : MainAPIController
{
    #region Properties

    private readonly IGenreFacade _genreFacade;
    private readonly IPublisherFacade _publisherFacade;

    #endregion

    #region Constructor

    public TypesController(IGenreFacade genreFacade,
                           IPublisherFacade publisherFacade,
                           INotificationHandler<Notification> notificador
                             ) : base(notificador)
    {
        _genreFacade = genreFacade;
        _publisherFacade = publisherFacade;
    }

    #endregion

    #region Methods Genre

    [HttpGet("listAllGenres")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ListAllGenres()
        => CustomResponse(await _genreFacade.ListAllGenres());

    [HttpGet("listAllGenresActive")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ListAllGenresActive()
        => CustomResponse(await _genreFacade.ListAllGenresActive());

    [HttpGet("getGenreByCode/{code}")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> GetGenreByCode(int code)
        => CustomResponse(await _genreFacade.GetGenreByCode(code));

    #endregion

    #region Methods Publisher

    [HttpGet("listAllPublishers")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ListAllPublishers()
        => CustomResponse(await _publisherFacade.ListAllPublishers());

    [HttpGet("listAllPublishersActive")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ListAllPublishersActive()
        => CustomResponse(await _publisherFacade.ListAllPublishersActive());

    [HttpGet("getPublisherByCode/{code}")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> GetPublisherByCode(int code)
        => CustomResponse(await _publisherFacade.GetPublishersByCode(code));

    #endregion
}