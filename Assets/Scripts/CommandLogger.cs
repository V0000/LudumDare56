using System.Collections.Generic;
using UnityEngine;

public static class CommandLogger
{
    public static List<Command> Commands { get; private set; } = new List<Command>();
    static float max = 0;
    static float min = 1000;
    public static void LogCommand(Command command)
    {
        //Debug.Log($"Commands {Commands.Count}");
        Commands.Add(command);
    }
}