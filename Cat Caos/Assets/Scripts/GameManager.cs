using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    [SerializeField] private AudioClip sonidoMuerteJugador;

    private int vidas = 3;
    private int nivel = 1;

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestruirSingleton();
        }
    }
    
    // Método para destruir la instancia
    public void DestruirSingleton()
    {
        Destroy(gameObject);
    }

    public void SumarPoints(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log("Puntos: "+puntosTotales);
        hud.ActualizarPuntos(puntosTotales);
    }

    public void PerderVidas()
    {
        if(vidas >0){
            vidas--;
            Debug.Log("perdiste una tienes: "+vidas);
            hud.DesactivarVida(vidas);
        }
        if(vidas == 0){
            AudioManager.instance.ReproducirSonido(sonidoMuerteJugador);
            Invoke("Morir", 1f);
        }
    }
    public bool RecuperarVida()
    {
        if (vidas >= 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);

        vidas++;
        Debug.Log("ganaste una tienes: "+ vidas);
        return true;
    }
    public void Morir()
    {
        SceneManager.LoadScene("GameOver");
        hud.DesactivarHUD();
    }
    public void CambioNivel()
    {
        nivel++;
        SceneManager.LoadScene(nivel);
    }
}
