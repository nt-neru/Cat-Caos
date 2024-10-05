using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinColicion : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoMoneda;
    [SerializeField] private int valor = 1;

    private void OnTriggerEnter2D(Collider2D collicion)
    {
        if (collicion.CompareTag("Player"))
        {  //Solo ejecuta si es el jugador quien coliciona con la moneda
            AudioManager.instance.ReproducirSonido(sonidoMoneda);
            GameManager.Instance.SumarPoints(valor);
            Destroy(this.gameObject);
        }
    }
}
