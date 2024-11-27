using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;
using FishNet.Object.Synchronizing;

public class CharacterMoveNetwork : CharacterNetwork, IMovable
{
    /** Declarando Variables */
    [SerializeField] private float velocidad = 10f;
    private bool mirandoDerecha = true;


    // Usamos NetworkVariable para sincronizar la posición del personaje si no usamos NetworkTransform
    //public NetworkVariable<Vector2> syncedPosition = new NetworkVariable<Vector2>();

    // El NetworkObject se asegura de que este objeto esté sincronizado con la red
    private NetworkObject networkObject;
    
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
    private void Awake()
    {
        networkObject = GetComponent<NetworkObject>();
    }

    /** Mueve al jugador */
    // Método que se ejecuta cada frame, sincrónico en red
    [ServerRpc(RequireOwnership = false)]
    public void Move(float moveX)
    {
        // Si el objeto no tiene autoridad, no se puede mover
        if (networkObject.IsOwner) 
        {
            rb.velocity = new Vector2(moveX * velocidad, rb.velocity.y);
            gestionarDireccion(moveX);

            // Sincroniza la posición con todos los clientes
            //syncedPosition.Value = transform.position;
            //LimitarMovimientoEnPantalla();
        }
        else
        {
            // Los clientes que no son propietarios actualizan la posición en función de la sincronización
            //transform.position = syncedPosition.Value;
        }

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
