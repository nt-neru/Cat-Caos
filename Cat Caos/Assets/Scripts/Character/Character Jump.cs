using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    /* Fields */
    private Rigidbody2D rb;
    private bool doubleJumpUsed = false;

    /* Serialized Fields */
    [Header("References")]
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private AudioClip sonidoSalto;
    [SerializeField] private Transform groundCheck;

    [Header("Settings")]
    [SerializeField] private float fuerzaSalto;
	[SerializeField] private float doubleJumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtenemos la ref. al rigidbody2D del PJ
    }

    void Update()
    {
        // Detectamos si se presiona la tecla espacio y si el personaje esta tocando el suelo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si toca el suelo
            if (EstaEnSuelo()){
                Saltar();
            }
            else if(!doubleJumpUsed){
                DobleSalto();
            }
        }

        // Cuando el doble salto ha sido usado y tocamos de nuevo el suelo...
        if (doubleJumpUsed && EstaEnSuelo()){
            // Volvemos a permitir el uso del doble salto.
            doubleJumpUsed = false;
        }
    }

    /** Hace saltar al Jugador*/
    public void Saltar()
    {
        Debug.Log("Salto1");
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        
        // Aplicamos una fuerza hacia arriba con la fuerza del salto que elijamos en el inspector
        rb.AddForce(Vector2.up * (fuerzaSalto * Time.fixedDeltaTime), ForceMode2D.Impulse);
        // Reproducir audio
        ReproducirSalto();
    }
    public void DobleSalto(){
        Debug.Log("Salto2...");
        rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
        
        // Aplicamos una fuerza hacia arriba con la fuerza del salto que elijamos en el inspector
        rb.AddForce(Vector2.up * (doubleJumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        doubleJumpUsed = true;
        ReproducirSalto();
    }

    public void ReproducirSalto(){
        if (sonidoSalto != null){
            AudioManager.instance.ReproducirSonido(sonidoSalto);
        }
    }

    /* Verifica si esta en el suelo */
    public bool EstaEnSuelo()
    { 
        // Creamos un rayo desde el objeto colocado en los pies del personaje
        Ray2D ray = new Ray2D(groundCheck.position, Vector2.down);
        
        // Lanzamos el rayo y almacenamos la colisión del rayo con los objetos en la capa "Suelo"
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 0.3f, capaSuelo);

        // Si el rayo colisiona con algo, dibujamos el rayo en rojo; si no colisiona, en verde
        Color rayColor = hit.collider != null ? Color.red : Color.green;
        Debug.DrawRay(ray.origin, ray.direction * 0.3f, rayColor);

        // Devolvemos "true" si el rayo ha detectado suelo y "false" si no
        return hit.collider is not null;

    }
}