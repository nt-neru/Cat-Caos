using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class PanelGame : MonoBehaviour
{
    private AudioSource fxSourse;
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private TextMeshProUGUI puntos;

    void Start(){
        int punto = ControladorPuntaje.Instance.PuntosTotales;
        puntos.text = "Recogiste: " + punto.ToString()+"puntos";
    }

    public void ReproducirSonido()
    {
        fxSourse.PlayOneShot(ClickSound);
    }

    public void PlayLevel(string level)
    {
        SceneManager.LoadScene(level);
        GameManager.Instance.DestruirSingleton();
        ControladorPuntaje.Instance.DestruirSingleton();
    }
}
