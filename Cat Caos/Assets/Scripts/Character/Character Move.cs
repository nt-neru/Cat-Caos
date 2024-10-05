using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    /** Declarando Variables */
    [SerializeField] private float velocidad;
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;
    private bool puedeMoverse = true;

    public bool PuedeMoverse { get => puedeMoverse; set => puedeMoverse = value; }

    // Start se ejecuta cuando el GameObject que contiene el script esta en escena
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //obtiene el componente de nuestro obj.
    }

    // Update una ves por cada fotograma
    void Update()
    {
        if (PuedeMoverse == false)
        {
            return;
        }
        float moveX = Input.GetAxis("Horizontal"); //Obtenemos la entrada (-1, 0, 1). izquierda, quieto, derecha

        mover(moveX);
        gestionarDireccion(moveX);
        LimitarMovimientoEnPantalla();
    }

    /** Mueve al jugador */
    public void mover(float moveX)
    {
        rb.velocity = new Vector2(moveX * velocidad , rb.velocity.y);
    }
    public void gestionarDireccion(float movimiento)
    {
        // si miro a la derecha y quiero ir a la izquierda O si miro a la izquierda y quiero ir a la derecha 
        if ((mirandoDerecha && movimiento < 0) || (!mirandoDerecha && movimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Gira al pj cambiando la scala del transform
            //transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            //transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }
    }

    void LimitarMovimientoEnPantalla()
    {
        Vector3 posicionViewport = Camera.main.WorldToViewportPoint(transform.position);
        posicionViewport.x = Mathf.Clamp01(posicionViewport.x);
        posicionViewport.y = Mathf.Clamp01(posicionViewport.y);

        transform.position = Camera.main.ViewportToWorldPoint(posicionViewport);
    }
}
