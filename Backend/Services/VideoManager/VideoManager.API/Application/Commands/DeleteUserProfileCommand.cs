﻿using Application.Contracts;

namespace VideoManager.API.Application.Commands;

public class DeleteUserProfileCommand : ICommand
{
    public string Id { get; set; }

    public DeleteUserProfileCommand(string id)
    {
        Id = id;
    }
}
