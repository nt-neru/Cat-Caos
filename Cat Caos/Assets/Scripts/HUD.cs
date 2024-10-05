using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntos;
    [SerializeField] private GameObject[] vidas;

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }
    public void ActivarVida(int i)
    {
        vidas[i].SetActive(true);
    }
    public void DesactivarVida(int i)
    {
        vidas[i].SetActive(false);
    }
    public TextMeshProUGUI ObtenerPuntos(){
        return puntos;
    }
    public void DesactivarHUD(){
        this.gameObject.SetActive(false);
    }
}
