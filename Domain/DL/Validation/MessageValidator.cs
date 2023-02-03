using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Validation.Messages;
using Domain.DL.Validation.ReadModels;
using Shared.SpecificationPattern.Composite.Extensions;
using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.MessageErrors;

namespace Domain.DL.Validation;
internal sealed class MessageValidator
{
    private readonly PostMessage _message;
    private readonly MessageValidationData _validationData;

    public MessageValidator(PostMessage message, MessageValidationData validationData)
    {
        _message = message;
        _validationData = validationData;
    }

    public BinaryFlag Validate()
    {
        BinaryFlag flag = new();
        flag += new IsMessageUserIdSat().And(new IsMessageUserIdValid(_validationData.UserIds)).IsSatisfiedBy(_message) ? 0 : UserIdInvalid;
        flag += new IsMessageEukaryoteIdSat().And(new IsMessageEukaryoteIdValid(_validationData.EukaryoteIds)).IsSatisfiedBy(_message) ? 0 : EukaryoteIdInvalid;
        flag += new IsMessageMomentSat().IsSatisfiedBy(_message) ? 0 : TimeStampInvalid;
        flag += new IsMessageLatitudeSat().And(new IsMessageLongtitudeSat()).IsSatisfiedBy(_message) ? 0 : LocationInvalid;
        return flag;
    }
}

internal sealed class MessageValidationData
{
    public IEnumerable<UserId> UserIds { get; private set; }
    public IEnumerable<LifeformId> EukaryoteIds { get; private set; }

    public MessageValidationData(IEnumerable<UserId> userIds, IEnumerable<LifeformId> eukaryoteIds)
    {
        UserIds = userIds;
        EukaryoteIds = eukaryoteIds;
    }
}