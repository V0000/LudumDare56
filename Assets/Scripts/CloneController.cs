using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloneController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int delayFrames = 100;
    private Rigidbody2D rb;
    private int commandNumber;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        delayFrames = Random.Range(0, delayFrames);
        
        commandNumber = Mathf.Max(3, CommandLogger.Commands.Count - delayFrames);
    }
    
    void Update()
    {
        ExecuteCommands(commandNumber++);
    }

    private void ExecuteCommands(int num)
    {
        if (num >= CommandLogger.Commands.Count)
        {
            commandNumber--;
            return;
        }
        if (num < 0)
        {
            commandNumber++;
            return;
        }
        Command command = CommandLogger.Commands[num];
            switch (command.Type)
            {
                case CommandType.MoveLeft:
                    Move(command.MoveInput);
                    break;
                case CommandType.MoveRight:
                    Move(command.MoveInput);
                    break;
                case CommandType.Jump:
                    Jump();
                    break;
                case CommandType.Idle:
                    break;
            }
    }

    private void Move(float moveInput)
    {
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
    }
}