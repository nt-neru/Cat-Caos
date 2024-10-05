using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    /** Declarando variables */
    private Animator animator; // Representa al componente Animator del PJ

    private void Start()
    {
        animator = GetComponent<Animator>(); //Obtenemos la referencia al componente
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f){ // Comparamos el valor del movimiento (-1 / 0 / 1)
            animator.SetBool("isRunning", true); // Activar animacion caminar
        }
        else{
            animator.SetBool("isRunning", false); // Desactivar animacion de caminar
        }
    }

    // Cuando el personaje colisiona con un Objeto, desactiva animacion de saltr
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isJumping", false); // desactiva la animacion saltar
    }
    // Cuando el PJ deja de colisionar con un obj, activa animacion de salto
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", true); // Activa animacion saltar
    }
}
