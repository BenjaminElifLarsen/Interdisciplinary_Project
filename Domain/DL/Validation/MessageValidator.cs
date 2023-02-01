using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.Validation.Messages;
using Shared.SpecificationPattern.Composite.Extensions;
using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.MessageErrors;

namespace Domain.DL.Validation;
internal class MessageValidator
{
    private readonly InsertMessage _message;
    private readonly MessageValidatorData _validatorData;

    public MessageValidator(InsertMessage message, MessageValidatorData validatorData)
    {
        _message = message;
        _validatorData = validatorData;
    }

    public BinaryFlag Validate()
    {
        BinaryFlag flag = new();
        flag += new IsMessageUserIdSat().And(new IsMessageUserIdValid(_validatorData.UserIds)).IsSatisfiedBy(_message) ? 0 : UserIdInvalid;
        flag += new IsMessageEukaryoteIdSat().And(new IsMessageEukaryoteIdValid(_validatorData.EukaryoteIds)).IsSatisfiedBy(_message) ? 0 : EukaryoteIdInvalid;
        flag += new IsMessageMomentSat().IsSatisfiedBy(_message) ? 0 : TimeStampInvalid;
        flag += new IsMessageLatitudeSat().And(new IsMessageLongtitudeSat()).IsSatisfiedBy(_message) ? 0 : LocationInvalid;
        return flag;
    }
}

internal class MessageValidatorData
{
    public IEnumerable<int> UserIds { get; set; }
    public IEnumerable<int> EukaryoteIds { get; set; }

    public MessageValidatorData(IEnumerable<int> userIds, IEnumerable<int> eukaryoteIds)
    {
        UserIds = userIds;
        EukaryoteIds = eukaryoteIds;
    }
}