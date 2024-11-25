using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private CharacterMove characterMove;
    private float moveX;

    // Constructor de la clase
    public MoveCommand(CharacterMove characterMove, float moveX)
    {
        this.characterMove = characterMove;
        this.moveX = moveX;
    }

    // Ejecutando el comando del personaje
    public void Execute(){
        this.characterMove.Move(this.moveX);
    }
}
