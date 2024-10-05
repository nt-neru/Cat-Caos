using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacked : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int fuerzaGolpe;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AplicarGolpe()
    {
        //AudioManager.instance.ReproducirSonido();
        this.GetComponent<CharacterMove>().PuedeMoverse = false;
        Vector2 direccionGolpe;
        if (rb.velocity.x > 0) //si viende desde la derecha
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }

        rb.AddForce(direccionGolpe * fuerzaGolpe);

        StartCoroutine(EsperarActivarMove());
    }

    IEnumerator EsperarActivarMove()
    {
        // Esperar antes de comprobar si esta en el suelo
        yield return new WaitForSeconds(0.1f);

        while (this.gameObject.GetComponent<CharacterJump>().EstaEnSuelo() == false)
        {
            yield return null; //  para esperar un frame antes de continuar y no devuelve nada
        }

        //caundo ya esta en el suelo
        this.GetComponent<CharacterMove>().PuedeMoverse = true;
    }
}
