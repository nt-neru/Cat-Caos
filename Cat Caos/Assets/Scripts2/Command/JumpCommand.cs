using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    CharacterJump characterJump;

    // Constructor de la clase
    public JumpCommand(CharacterJump characterJump)
    {
        this.characterJump = characterJump;
    }

    // Ejecutando el comando del personaje
    public void Execute(){
        this.characterJump.verifyJump();
    }
}
