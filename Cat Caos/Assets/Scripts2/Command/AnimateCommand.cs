
using UnityEngine;

public class AnimateCommand : ICommand
{
    private CharacterAnimation animation;
    private float horizontalInput;
    private bool isJumping;

    // Constructor de la clase
    public AnimateCommand(CharacterAnimation animation, float horizontalInput, bool isJumping)
    {
        this.animation = animation;
        this.horizontalInput = horizontalInput;
        this.isJumping = isJumping;
    }

    // Ejecutando el comando del personaje
    public void Execute(){
        // Actualiza la animacion cuando hay un cambio relevante
        this.animation.UpdateAnimation(horizontalInput, isJumping);
    }
}
