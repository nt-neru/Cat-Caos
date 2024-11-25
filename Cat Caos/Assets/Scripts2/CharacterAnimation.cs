using UnityEngine;

public class CharacterAnimation : Character
{
    private Animator animator;
    private float lastHorizontalInput = 0f; // Para controlar cambios en el movimiento horizontal
    private bool wasJumping = false; // Controla el estado de salto para evitar actualización continua
    
    protected override void Start() // Sobreescribiendo el metodo de la clase base 
    {
        animator = GetComponent<Animator>();
    }
    // Este método actualizará la animación del personaje basándose en las entradas del jugador
    public void UpdateAnimation(float horizontalInput, bool isJumping)
    {
        // Si el valor de horizontalInput cambia (es decir, si el jugador empieza a moverse)
        if (Mathf.Abs(horizontalInput) > 0f && lastHorizontalInput != horizontalInput)
        {
            animator.SetBool("isRunning", true); // Activar animación de correr
        }
        else if (Mathf.Abs(horizontalInput) == 0f)
        {
            animator.SetBool("isRunning", false); // Desactivar animación de correr
        }

        lastHorizontalInput = horizontalInput; // Guardar el último estado del input horizontal

        // Si el estado de salto cambia (de "en el aire" a "en el suelo" o viceversa)
        if (isJumping && !wasJumping)
        {
            animator.SetBool("isJumping", true); // Activar animación de salto
        }
        else if (!isJumping && wasJumping)
        {
            animator.SetBool("isJumping", false); // Desactivar animación de salto
        }

        wasJumping = isJumping; // Actualizar el estado del salto
    }
}
