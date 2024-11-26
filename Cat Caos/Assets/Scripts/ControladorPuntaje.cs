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
    public float[] arreglomoneda;
    public HUD hud;
    private void Awake(){
        arreglo= new float[2]; 

        if(ControladorPuntaje.Instance == null)
        {
            ControladorPuntaje.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else {
            Destroy(gameObject);
        }
    }
    // Sumar Puntajes y los guardo en cantidad de puntos
    public void SumarPuntaje(int puntos){
        CantidadPuntos += puntos ; 
       // hud.ActualizarPuntos(CantidadPuntos);
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
  
    for (int i = 0; i < 2; ++i)
        {
            array[i] = arreglo[i];
            Debug.Log("Puntos2: "+ arreglo[i]);
            Debug.Log("puntosplayer: "+ CantidadPuntos);
        }

 }
 public void MonedasRecogidas()
 {
    Debug.Log("monedas: "+ CantidadPuntos);
 }

}

//cambiar el sumarpuntaje ya que lo tiene el manager 
    