using BookCatalog.Common.Util.Messages;
using FluentValidation;
using System.Linq.Expressions;

namespace BookCatalog.Common.Util.Validators;

/// <summary>
/// Classe base genérica para validadores FluentValidation, com métodos auxiliares reutilizáveis.
/// </summary>
/// <typeparam name="T">Tipo da classe a ser validada.</typeparam>
public abstract class BaseValidator<T> : AbstractValidator<T>
{
    /// <summary>
    /// Aplica uma regra de campo obrigatório com mensagem personalizada.
    /// </summary>
    /// <typeparam name="TProperty">Tipo da propriedade.</typeparam>
    /// <param name="expression">Expressão da propriedade a ser validada.</param>
    /// <param name="fieldName">Nome do campo para compor a mensagem.</param>
    protected void RuleRequired<TProperty>(Expression<Func<T, TProperty>> expression, string fieldName)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage(ValidationMessages.RequiredField(fieldName));
    }

    /// <summary>
    /// Aplica uma regra de validação de tamanho mínimo em uma string.
    /// </summary>
    /// <param name="expression">Expressão da propriedade string.</param>
    /// <param name="fieldName">Nome do campo para compor a mensagem.</param>
    /// <param name="minLength">Valor mínimo de caracteres permitidos.</param>
    protected void RuleMinLength(Expression<Func<T, string>> expression, string fieldName, int minLength)
    {
        RuleFor(expression)
            .MinimumLength(minLength)
            .WithMessage(ValidationMessages.MinLength(fieldName, minLength));
    }

    /// <summary>
    /// Aplica uma regra de validação de tamanho máximo em uma string.
    /// </summary>
    /// <param name="expression">Expressão da propriedade string.</param>
    /// <param name="fieldName">Nome do campo para compor a mensagem.</param>
    /// <param name="maxLength">Valor máximo de caracteres permitidos.</param>
    protected void RuleMaxLength(Expression<Func<T, string>> expression, string fieldName, int maxLength)
    {
        RuleFor(expression)
            .MaximumLength(maxLength)
            .WithMessage(ValidationMessages.MaxLength(fieldName, maxLength));
    }

    /// <summary>
    /// Aplica uma regra de validação de formato de e-mail.
    /// </summary>
    /// <param name="expression">Expressão da propriedade string.</param>
    /// <param name="fieldName">Nome do campo para compor a mensagem.</param>
    protected void RuleEmail(Expression<Func<T, string>> expression, string fieldName)
    {
        RuleFor(expression)
            .EmailAddress()
            .WithMessage(ValidationMessages.EmailInvalid(fieldName));
    }

    /// <summary>
    /// Aplica uma regra de validação de faixa numérica inclusiva.
    /// </summary>
    /// <param name="expression">Expressão da propriedade numérica.</param>
    /// <param name="fieldName">Nome do campo para compor a mensagem.</param>
    /// <param name="min">Valor mínimo permitido.</param>
    /// <param name="max">Valor máximo permitido.</param>
    protected void RuleRange(Expression<Func<T, int>> expression, string fieldName, int min, int max)
    {
        RuleFor(expression)
            .InclusiveBetween(min, max)
            .WithMessage(ValidationMessages.Range(fieldName, min, max));
    }
}