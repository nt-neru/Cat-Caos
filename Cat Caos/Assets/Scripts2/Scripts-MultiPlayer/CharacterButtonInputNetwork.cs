using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object; // Necesario para la autoridad en FishNet
using FishNet.Managing; // Espacio de nombres para NetworkManager en FishNet

public class CharacterButtonInputNetwork : NetworkBehaviour  
{
    [SerializeField] private KeyCode spaceKey = KeyCode.Space;

    // Referencias a los scripts del personaje
    [SerializeField] private CharacterMoveNetwork scriptMove;
    [SerializeField] private CharacterJump scriptJump;
    [SerializeField] private CharacterAnimation scriptAnimation;

    private float lastHorizontalInput = 0f;
    private bool wasJumping = false;

    private void Update()
    {
        // Si el objeto tiene la autoridad (propietario del jugador)
        if (IsOwner)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        // El código común para el manejo de entradas y acciones, ya sea en red o no
        float horizontalInput = Input.GetAxis("Horizontal");
        bool isJumping = !scriptJump.EstaEnSuelo();

        // Solo realizar el movimiento si hay un cambio en la entrada horizontal
        if (horizontalInput != lastHorizontalInput)
        {
            RunMoveCommand(horizontalInput);
        }

        // Solo saltar si el jugador presiona la tecla de salto
        if (Input.GetKeyDown(spaceKey))
        {
            RunJumpCommand();
        }

        // Actualizamos la animación si hay cambios
        if (horizontalInput != lastHorizontalInput || isJumping != wasJumping)
        {
            RunAnimateCommand(horizontalInput, isJumping);
        }

        lastHorizontalInput = horizontalInput;
        wasJumping = isJumping;
    }

    public void RunMoveCommand(float moveX)
    {
        if (scriptMove != null)
        {
            // Ejecutar el comando de movimiento
            CommandQueue.Instance.AddCommand(new MoveCommand(scriptMove, moveX));
        }
    }

    public void RunJumpCommand()
    {
        if (scriptJump != null)
        {
            // Ejecutar el comando de salto
            CommandQueue.Instance.AddCommand(new JumpCommand(scriptJump));
        }
    }

    public void RunAnimateCommand(float moveX, bool isJumping)
    {
        if (scriptAnimation != null)
        {
            // Ejecutar el comando de animación
            CommandQueue.Instance.AddCommand(new AnimateCommand(scriptAnimation, moveX, isJumping));
        }
    }
}
