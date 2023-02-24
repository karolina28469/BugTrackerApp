﻿using BugTracker.Domain.Entities;

namespace BugTracker.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
