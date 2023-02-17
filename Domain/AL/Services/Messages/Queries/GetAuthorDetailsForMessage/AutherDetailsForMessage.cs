using Domain.DL.Models.MessageModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.AL.Services.Messages.Queries.GetAuthorDetails;
public sealed class AutherDetailsForMessage : BaseReadModel
{
    public string Username { get; set; }

    public AutherDetailsForMessage(string username)
    {
        Username = username;
    }
}

internal sealed class AutherDetailsForMessageQuery : BaseQuery<Author, AutherDetailsForMessage>
{
    public override Expression<Func<Author, AutherDetailsForMessage>> Map()
    {
        return e => new(e.Username);
    }
}
