namespace ErrorHandling
{
    public abstract class DomainException: System.Exception
    {

        public DomainException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base (message)
        {
        }
    }

    public class BadRequestException : DomainException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }

    public class AuthorizationtException : DomainException
    {
        public AuthorizationtException(string message) : base(message)
        {
        }
    }

    public class BadGatewayException : DomainException
    {
        public BadGatewayException(string message) : base(message)
        {
        }
    }
}
