using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private IMovable moveable;
    private float moveX;

    // Constructor de la clase
    public MoveCommand(IMovable moveable, float moveX)
    {
        this.moveable = moveable;
        this.moveX = moveX;
    }

    // Ejecutando el comando del personaje
    public void Execute(){
        this.moveable.Move(this.moveX);
    }
}
