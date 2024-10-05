using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAdd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada = GameManager.Instance.RecuperarVida();
            if (vidaRecuperada)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
