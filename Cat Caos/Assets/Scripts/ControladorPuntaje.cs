using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControladorPuntaje : MonoBehaviour
{
    
    public static ControladorPuntaje Instance { get; private set; }
   [SerializeField] private int CantidadPuntos;
   
    public int PuntosTotales { get { return CantidadPuntos; } }
    public float[] arreglo;
    [SerializeField] private HUD hud;
    private void Awake(){
        arreglo= new float[2]; 

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            DestruirSingleton();
        }
    }
    // Sumar Puntajes y los guardo en cantidad de puntos
    public void SumarPuntaje(int puntos){
        CantidadPuntos += puntos ; 
        hud.ActualizarPuntos(CantidadPuntos);
        Debug.Log("Puntoss: "+ CantidadPuntos);
    }

   //cuando los pj llegan a la meta sumo los puntos y los agrego al arreglo
   public void SumaPuntuacionLlegada()
    {
        for (int i = 0; i < 2; ++i){
            arreglo[i] += 20;
            Debug.Log("Puntos: "+ arreglo[i]);
        }         
    }
//recibo un arreglo y lo hago igual al arreglo que tengo de las puntuaciones 
 public void Puntuaciones(float[] array){
  
    for (int i = 0; i < 1; ++i)
        {
            array[i] = arreglo[i];
            Debug.Log("Puntos2: "+ arreglo[i]);
            Debug.Log("puntosplayer: "+ PuntosTotales);
        }

 }
//  public void MonedasRecogidas()
//  {
//     Debug.Log("monedas: "+ PuntosTotales);
//  }
 public void DestruirSingleton(){
    Destroy(gameObject);
 }

}
