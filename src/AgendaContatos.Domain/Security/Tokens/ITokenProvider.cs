﻿namespace AgendaContatos.Domain.Security.Tokens
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
