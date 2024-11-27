using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraPuntos : MonoBehaviour
{

    private int VidaBarra = 29;
    private int valor = 0;
    public float[] arreglo;
    public Slider BarraPunto;
    // Start is called before the first frame update

    public void Start()
    {
        arreglo= new float[2];
        IniciarBarra();
    }

   // realizo un for para poder iterar en los valores del arreglo y asi poder darlo como valor a value 
    public void IniciarBarra(){
        ControladorPuntaje.Instance.Puntuaciones(arreglo);
         Debug.Log("arreglo: "+ arreglo);
         
         for (int i = 0; i < 1; ++i){
             
                BarraPunto.maxValue = VidaBarra;
                BarraPunto.value = arreglo[i];          
         }

    
    }

    // public void AcualizarBarra(){           
    //         if(valor <= VidaBarra){
    //         BarraPunto.value = valor;
    //         valor++;
    //     }
               
    // }

}
