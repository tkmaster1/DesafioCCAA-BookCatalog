using AutoMapper;
using BookCatalog.Common.Util.DTOs;
using BookCatalog.Common.Util.Messages;
using BookCatalog.Common.Util.Response;
using BookCatalog.Common.Util.Services;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Facades.Interfaces;
using BookCatalog.Core.Service.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookCatalog.Core.WebApi.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class AuthController : MainAPIController
{
    #region Properties

    private readonly AuthorizationSettings _authorizationSettings;
    private readonly IAuthFacade _authFacade;

    #endregion

    #region Constructor

    public AuthController(IAuthFacade authFacade,
        IOptions<AuthorizationSettings> authorizationSettings,
        INotificationHandler<Notification> notificador) : base(notificador)
    {
        _authFacade = authFacade;
        _authorizationSettings = authorizationSettings.Value;
    }

    #endregion

    #region Methods

    [HttpPost("login")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseSuccess<LoginResponseDTO>), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 401)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> Login(LoginRequestDTO loginUser)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        var result = await _authFacade.LoginAsync(loginUser);

        switch (result)
        {
            case { IsLockedOut: true }:
                return CustomResponse(null, true, ValidationMessages.MSG_USERBLOCKED);
            case { Succeeded: false }:
                return CustomResponse(null, true, result.Message);
        }

        var jwt = await _authFacade.GerarJwtAsync(loginUser.Email, _authorizationSettings);
        return CustomResponse(jwt);
    }

    [HttpPost("registerUser")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseSuccess<LoginResponseDTO>), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 401)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDTO registerUser)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _authFacade.RegisterUserAsync(registerUser);

        switch (result)
        {
            case { IsLockedOut: true }:
                return CustomResponse(null, true, ValidationMessages.MSG_USERBLOCKED);
            case { Succeeded: false }:
                return CustomResponse(null, true, result.Message);
        }

        var jwt = await _authFacade.GerarJwtAsync(registerUser.Email, _authorizationSettings);
        return CustomResponse(jwt);
    }

    [HttpGet("forgotYourPassword")]
    [Consumes("application/Json")]
    [Produces("application/Json")]
    [ProducesResponseType(typeof(ResponseBaseEntity), 200)]
    [ProducesResponseType(typeof(ResponseFailure), 400)]
    [ProducesResponseType(typeof(ResponseFailure), 401)]
    [ProducesResponseType(typeof(ResponseFailure), 403)]
    [ProducesResponseType(typeof(ResponseFailure), 409)]
    [ProducesResponseType(typeof(ResponseFailure), 500)]
    [ProducesResponseType(typeof(ResponseFailure), 502)]
    public async Task<IActionResult> ForgotYourPassword([FromQuery] string email)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _authFacade.ForgotPassword(email);

        return CustomResponse(result);
    }

    #endregion
}