namespace GrantAdvance.Backend.Application.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);