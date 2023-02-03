﻿using Shared.CQRS.Commands;

namespace Domain.DL.CQRS.Commands.Messages;
public sealed class PostMessage : ICommand
{
    public int UserId { get; set; }
    public int EukaryoteId { get; set; }
    public DateTime Moment { get; set; }
    public long Latitude { get; set; }
    public long Longtitude { get; set; }

    public PostMessage()
    {

    }

    internal PostMessage(int userId, int eukaryoteId, DateTime moment, long latitude, long longtitude)
    {
        UserId = userId;
        EukaryoteId = eukaryoteId;
        Moment = moment;
        Latitude = latitude;
        Longtitude = longtitude;
    }
}