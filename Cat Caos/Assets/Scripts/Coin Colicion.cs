// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CoinColicion : MonoBehaviour
// {
//     [SerializeField] private AudioClip sonidoMoneda;
//     [SerializeField] private int valor = 1;

//     private void OnTriggerEnter2D(Collider2D collicion)
//     {
//         if (collicion.CompareTag("Player"))
//         {  //Solo ejecuta si es el jugador quien coliciona con la moneda
//             AudioManager.instance.ReproducirSonido(sonidoMoneda);
//             GameManager.Instance.SumarPoints(valor);
//             Destroy(this.gameObject);
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinColicion : MonoBehaviour
{
    public static CoinColicion Instance { get; private set; }
    [SerializeField] private AudioClip sonidoMoneda;
    [SerializeField] private int valor = 1;
    

    private bool flag = false; // Bandera para indicar si hubo una colisión

    private void OnTriggerEnter2D(Collider2D collicion)
    {
        if (collicion.CompareTag("Player"))
        {
            flag = true; // Marcar la bandera como true al detectar una colisión
            //print("Colission!!!");
        }
    }

    private void Update()
    {
        if (flag)
        {
            print("Colission!!!");
            AudioManager.instance.ReproducirSonido(sonidoMoneda);
            ControladorPuntaje.Instance.SumarPuntaje(valor);
           // GameManager.Instance.SumarPoints(valor);
            Destroy(this.gameObject);

            flag = false; // Resetear la bandera
        }

    }

     
}