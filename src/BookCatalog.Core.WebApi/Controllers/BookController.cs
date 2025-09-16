using BookCatalog.Common.Util.DTOs;
using BookCatalog.Common.Util.Response;
using BookCatalog.Common.Util.Services;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Facades.Interfaces;
using BookCatalog.Core.Service.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Core.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class BookController : MainAPIController
{
    #region Properties

    private readonly IBookFacade _bookFacade;

    #endregion

    #region Constructor

    public BookController(IBookFacade bookFacade,
        INotificationHandler<Notification> notificador) : base(notificador)
    {
        _bookFacade = bookFacade;
    }

    #endregion

    #region Methods Public

    [HttpPost("getBooks")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseSuccess<PaginationDTO<BookDTO>>), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> GetBooks([FromBody] BookFilterDTO filterDTO)
        => CustomResponse(await _bookFacade.ListByFilters(filterDTO));

    [HttpGet("getBookByCode/{code}")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseSuccess<BookDTO>), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> GetBookByCode(int code)
        => CustomResponse(await _bookFacade.GetByCode(code, GetCurrentUserId()));

    [HttpGet("user-books-report")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> GetUserBooksReport(CancellationToken ct)
    => CustomResponse(await _bookFacade.GetUserBooksReport(GetCurrentUserId(), ct));

    [HttpPost("saveNewBook")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> SaveNewBook([FromBody] BookRequestDTO requestDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _bookFacade.CreateBook(requestDTO, GetCurrentUserId());

        return CustomResponse(id);
    }

    [HttpPut("editBook")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ChangeBook([FromBody] BookRequestDTO requestDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return CustomResponse(await _bookFacade.UpdateBook(requestDTO, GetCurrentUserId()));
    }

    [HttpPut("deactivateBook/{code}")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> DeactivateBook(int code)
       => CustomResponse(await _bookFacade.ActivateEndDeactivateBook(code, GetCurrentUserId(), false));

    [HttpPut("activateBook/{code}")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ActivateBook(int code)
        => CustomResponse(await _bookFacade.ActivateEndDeactivateBook(code, GetCurrentUserId(), true));

    #endregion

    #region Methods Private

    private string GetCurrentUserId()
    {
        return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
    }

    #endregion
}
