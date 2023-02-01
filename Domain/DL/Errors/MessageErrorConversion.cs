﻿using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.MessageErrors;

namespace Domain.DL.Errors;
internal class MessageErrorConversion
{
    public static IEnumerable<string> Convert(BinaryFlag flag)
    {
        List<string> errors = new();
        if (flag == UserIdInvalid)
        {
            errors.Add("The user id is invalid.");
        }
        if (flag == EukaryoteIdInvalid)
        {
            errors.Add("The lifeform id is invalid.");
        }
        if (flag == TimeStampInvalid)
        {
            errors.Add("The timestamp is invalid.");
        }
        if (flag == LocationInvalid)
        {
            errors.Add("The location is invalid.");
        }
        return errors;
    }
}
