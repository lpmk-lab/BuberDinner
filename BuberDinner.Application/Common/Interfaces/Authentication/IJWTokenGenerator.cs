using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJWTokenGenerator
{

  string GenerateToken(User user);
}