using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinaCollision : ICollision
{
    private AudioClip sonidoGolpe;

    void Awake(){
        sonidoGolpe = Resources.Load<AudioClip>("Sounds/slap");
    }

    public void HandleCollision (Collider2D other)
    {
        GameManager.Instance.PerderVidas();
        // var characterAttacked = other.GetComponent<CharacterAttacked>();
        // if (characterAttacked != null)
        // {
        //     characterAttacked.AplicarGolpe();
        // }
        AudioManager.instance.ReproducirSonido(sonidoGolpe);

        // codigo anterior
            // GameManager.Instance.PerderVidas();
            // this.gameObject.GetComponent<CharacterAttacked>().AplicarGolpe();
            // AudioManager.instance.ReproducirSonido(sonidoGolpe);
    }
}
