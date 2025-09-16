namespace BookCatalog.Common.Util.Messages;

/// <summary>
/// Contém mensagens padrão de validação utilizadas na aplicação.
/// </summary>
public static class ValidationMessages
{
    /// <summary>
    /// Mensagem genérica de campo obrigatório.
    /// </summary> 
    public static string RequiredField(string fieldName)
        => $"O campo {fieldName} é obrigatório.";

    /// <summary>
    /// Mensagem para tamanho mínimo de caracteres.
    /// </summary>
    public static string MinLength(string fieldName, int length) =>
        $"O campo {fieldName} deve conter no mínimo {length} caracteres.";

    /// <summary>
    /// Mensagem para tamanho máximo de caracteres.
    /// </summary>
    public static string MaxLength(string fieldName, int length) =>
        $"O campo {fieldName} deve conter no máximo {length} caracteres.";

    /// <summary>
    /// Mensagem para campos fora do intervalo permitido.
    /// </summary>
    public static string Range(string fieldName, int min, int max) =>
        $"O valor do campo {fieldName} deve estar entre {min} e {max}.";

    /// <summary>
    /// Mensagem para formatos inválidos (ex: e-mail, CPF).
    /// </summary>
    public static string InvalidFormat(string fieldName) =>
        $"O campo {fieldName} está em um formato inválido.";

    /// <summary>
    /// Mensagem para campos que devem ser únicos (ex: e-mail, usuário).
    /// </summary>
    public static string AlreadyExists(string fieldName) =>
        $"Já existe um registro com o mesmo valor para {fieldName}.";

    /// <summary>
    /// Mensagem genérica de falha em validação.
    /// </summary>
    public static string ValidationError(string fieldName) =>
        $"Erro de validação no campo {fieldName}.";

    public static string EmailInvalid(string fieldName) =>
       $"O campo {fieldName} deve conter um e-mail válido.";

    #region Messages

    /// <summary>
    /// Mensagem de Objeto nulo
    /// </summary>
    public static string MSG_NULL_OBJECT(string fieldName) =>
        $"O objeto {fieldName} está nulo.";

    public static string MSG_PAGESIZE(string fieldName) =>
        $"O tamanho máximo da página permitido é de {fieldName}.";

    public static string MSG_SUCCESSFUL(string fieldName) =>
        $"{fieldName} realizado(a) com sucesso.";

    public const string MSG_SUCCESSLOGINFUL = "Login realizado com sucesso.";

    public const string MSG_SUCCESSREGISTERFUL = "Usuário registrado com sucesso.";

    public const string MSG_FAILED = "Usuário ou Senha incorretos.";

    public const string MSG_USERBLOCKED = "Usuário bloqueado.";

    public const string MSG_USERNOTFOUND = "Usuário não encontrado.";

    #endregion
}