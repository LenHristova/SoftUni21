﻿namespace BusTickets.Client.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}
