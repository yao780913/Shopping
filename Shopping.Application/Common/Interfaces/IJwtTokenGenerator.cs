namespace Shopping.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(dynamic user);
}