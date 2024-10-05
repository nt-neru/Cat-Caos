using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColiisionEnemy : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoGolpe;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Espina"))
        {
            GameManager.Instance.PerderVidas();
            this.gameObject.GetComponent<CharacterAttacked>().AplicarGolpe();
            AudioManager.instance.ReproducirSonido(sonidoGolpe);
        }
        if (other.CompareTag("Vacio"))
        {
            GameManager.Instance.Morir();
        }
        if (other.CompareTag("LLegada"))
        {
            GameManager.Instance.CambioNivel();
        }
    }

}
