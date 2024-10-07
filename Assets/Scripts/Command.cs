using System;
using UnityEngine;

[Serializable]
public class Command
{
    public CommandType Type { get; private set; }
    public float MoveInput { get; private set; }

    public Command(CommandType type, float moveInput)
    {
        Type = type;
        MoveInput = moveInput;
    }
}

public enum CommandType
{
    MoveLeft,
    MoveRight,
    Jump,
    Idle
}