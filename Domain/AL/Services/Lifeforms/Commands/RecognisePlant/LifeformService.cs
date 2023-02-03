﻿using Domain.DL.CQRS.Commands.Lifeforms;
using Shared.ResultPattern.Abstract;

namespace Domain.AL.Services.Lifeforms;
public partial class LifeformService
{
    public Task<Result> RecognisePlant(RecognisePlant command)
    {
        return Task.Run(() => _commandBus.Dispatch(command));
    }
}
