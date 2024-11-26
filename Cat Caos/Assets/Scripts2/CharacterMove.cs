using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : Character, IMovable
{
    /** Declarando Variables */
    [SerializeField] private float velocidad = 10f;
    private bool mirandoDerecha = true;
    // private bool puedeMoverse = true;

    // public bool PuedeMoverse { get => puedeMoverse; set => puedeMoverse = value; }

    // Update una ves por cada fotograma
    // void Update()
    // {
    //     // if (PuedeMoverse == false)
    //     // {
    //     //     return;
    //     // }
    //     float moveX = Input.GetAxis("Horizontal"); //Obtenemos la entrada (-1, 0, 1). izquierda, quieto, derecha

    //     Move(moveX);
    // }

    /** Mueve al jugador */
    public void Move(float moveX)
    {
        rb.velocity = new Vector2(moveX * velocidad , rb.velocity.y);
        gestionarDireccion(moveX);
       // LimitarMovimientoEnPantalla();
    }
    public void gestionarDireccion(float moveX)
    {
        // si miro a la derecha y quiero ir a la izquierda O si miro a la izquierda y quiero ir a la derecha 
        if ((mirandoDerecha && moveX < 0) || (!mirandoDerecha && moveX > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Gira al pj cambiando la scala del transform
            //transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            //transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }
    }

    public void LimitarMovimientoEnPantalla()
    {
        Vector3 posicionViewport = Camera.main.WorldToViewportPoint(transform.position);
        posicionViewport.x = Mathf.Clamp01(posicionViewport.x);
        posicionViewport.y = Mathf.Clamp01(posicionViewport.y);

        transform.position = Camera.main.ViewportToWorldPoint(posicionViewport);
    }
}
