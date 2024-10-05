using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool puedeAtacar = true;
    [SerializeField] private float coolDawnAtaque;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (puedeAtacar == false)
            {
                return;
            }
            puedeAtacar = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            // Perder 1 vida
            GameManager.Instance.PerderVidas();
            // Aplicamos golpe con el jugador
            collision.gameObject.GetComponent<CharacterAttacked>().AplicarGolpe();

            Invoke("ActivarAtaque", coolDawnAtaque); // Llama a la funcion despues de un retraso segun el cooldawn
        }
    }

    public void ActivarAtaque()
    {
        puedeAtacar = true;
        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
