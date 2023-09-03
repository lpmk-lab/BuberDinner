namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJWTokenGenerator
{

  string GenerateToken(Guid Id,string firstName,string lastName);
}