using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bubblesort : MonoBehaviour
{
    // public float[] arrayToSort;
    public static Bubblesort Instance { get; private set; }
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;
    public int Monedas = 0;
    public float[] arreglo;


   
    // Start is called before the first frame update

    
    private void Start()
    {
        arreglo= new float[2];
        MostrarBubbleSort();
    }
//envio mi arreglo y traigo los valores que tienen, luego los muestro en pantalla
    public void MostrarBubbleSort()
    {
        ControladorPuntaje.Instance.Puntuaciones(arreglo);
        ControladorPuntaje.Instance.MonedasRecogidas(Monedas);
        texto2.text += " " + Monedas;
        for (int i = 0; i < 1; ++i)
        {
            texto1.text += " " + arreglo[i];       
        }
        //luego ocupar ValoresBubblesort 
    }

    /*Genera valores aleatorio y actualiza a text1*/
    public void ValoresBubblesort(float[] array)
    {
 
        int n= array.Length;
        for(int i= 0; i<= n-2;i++){
            for(int j= 0; j<= n-i-2;j++){
                if(array[j]>array[j+1]){
                    // guado temporalmente al array en aux
                    float aux = array[j];
                    array[j]= array[j+1];
                    // lo hago igual a la componente aux
                    array[j+1] =aux;
                }
            }
        }  
    }
}
