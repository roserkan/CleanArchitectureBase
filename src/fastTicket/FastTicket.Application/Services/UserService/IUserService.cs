﻿using Core.Security.Entities;

namespace FastTicket.Application.Services.UserService;

public interface IUserService
{
    public Task<User?> GetByEmail(string email);
    public Task<User> GetById(Guid id);
    public Task<User> Update(User user);
}
