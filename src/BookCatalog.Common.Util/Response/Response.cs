using BookCatalog.Common.Util.Abstractions;
using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Common.Util.Response;

/// <summary>
/// Standard successful response envelope with a strongly-typed payload.
/// </summary>
public class ResponseSuccess<T> where T : class
{
    /// <summary>
    /// Indicates that the operation succeeded.
    /// </summary>
    public bool Success { get; set; } = true;

    /// <summary>
    /// Successful payload.
    /// </summary>
    public T Data { get; set; } = default!;
}

/// <summary>
/// Standard failure response envelope with a list of error messages.
/// </summary>
public class ResponseFailure
{
    /// <summary>
    /// Always false for failures.
    /// </summary>
    public bool Success { get; set; } = false;

    /// <summary>
    /// List of error messages (human-readable).
    /// </summary>
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}

public class ResponseBaseEntity : ResponseSuccess<Entity>
{
}

/// <summary>
/// Success response envelope specifically for paginated payloads,
/// but abstracted by IPagedResult to avoid coupling to specific DTOs.
/// </summary>
public class ResponsePaged<TDto> : ResponseSuccess<IPagedResult<TDto>> where TDto : class, new() { }

/// <summary>
/// Factory helpers to build success/failure responses consistently.
/// </summary>
public static class ResponseFactory
{
    public static ResponseSuccess<T> Ok<T>(T data) where T : class
        => new() { Data = data };

    public static ResponsePaged<TDto> Page<TDto>(IPagedResult<TDto> page)
        where TDto : class, new()
        => new() { Data = page };

    public static ResponseFailure Fail(params string[] errors)
        => new() { Errors = errors ?? Array.Empty<string>() };

    public static ResponseFailure Fail(IEnumerable<string> errors)
        => new() { Errors = errors ?? Enumerable.Empty<string>() };
}