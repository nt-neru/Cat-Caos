// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CharacterColiisionEnemy : MonoBehaviour
// {
//     [SerializeField] private AudioClip sonidoGolpe;

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Espina"))
//         {
//             GameManager.Instance.PerderVidas();
//             this.gameObject.GetComponent<CharacterAttacked>().AplicarGolpe();
//             AudioManager.instance.ReproducirSonido(sonidoGolpe);
//         }
//         if (other.CompareTag("Vacio"))
//         {
//             GameManager.Instance.Morir();
//         }
//         if (other.CompareTag("LLegada"))
//         {
//             GameManager.Instance.CambioNivel();
//         }
//     }

// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColiisionEnemy : MonoBehaviour
{

    [SerializeField] private AudioClip sonidoGolpe;
    private bool flag = false; // Bandera para el patrón Dirty Flag
    private Collider2D collisionCollider; // Para guardar el collider que causa la colisión

    private void OnTriggerEnter2D(Collider2D other)
    {
        flag = true; // Marcar la bandera como true al detectar una colisión
        collisionCollider = other; // Guardar el collider
    }

    private void Update()
    {
        if (flag)
        {
            if (collisionCollider != null)
            {
                // if (collisionCollider.CompareTag("Espina"))
                // {
                //     GameManager.Instance.PerderVidas();
                //     this.gameObject.GetComponent<CharacterAttacked>().AplicarGolpe();
                //     AudioManager.instance.ReproducirSonido(sonidoGolpe);
                //     print("Collision!!!");
                // }

                if (collisionCollider.CompareTag("Vacio"))
                {
                    GameManager.Instance.Morir();
                    print("Collision!!!");
                }

                if (collisionCollider.CompareTag("LLegada"))
                {
                    GameManager.Instance.CambioNivel();
                    ControladorPuntaje.Instance.SumaPuntuacionLlegada();
                    print("Collision!!!");
                }

                if (collisionCollider.CompareTag("LLegadaa"))
                {
                    GameManager.Instance.Marcador();    
                    ControladorPuntaje.Instance.SumaPuntuacionLlegada();      
                    print("Collision!!!");
                }
              
                
            }

            flag = false; // Resetear la bandera
        }
    }
}