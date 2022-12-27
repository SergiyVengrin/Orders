﻿namespace Application.Common.Exceptions
{
    public sealed class NotFoundException:Exception
    {
        public NotFoundException():base("Entity not found.")
        { }

        public NotFoundException(int id):base($"Entity with id: {id} not found.")
        { }
    }
}
