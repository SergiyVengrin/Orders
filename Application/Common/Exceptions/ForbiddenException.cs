namespace Application.Common.Exceptions
{
    public sealed class ForbiddenException:Exception
    {
        public ForbiddenException():base("The server refuses action.")
        { }

        public ForbiddenException(int userId):base($"A user with id: {userId} has orders.")
        { }

        public ForbiddenException(string login):base($"A user with login: {login} already exists.")
        { }
    }
}
