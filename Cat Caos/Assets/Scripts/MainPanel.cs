using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public AudioMixer mixer;
    public AudioSource fxSourse;
    public AudioClip ClickSound;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;

    private void Awake()
    {
        // Cuando el slider cambie de valor, llame a las funciones y estas las setean
        volumeFX.onValueChanged.AddListener(CambiarVolumenFX);
        volumeMaster.onValueChanged.AddListener(CambiarVolumenMaster);
    }

    public void AbrirPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
        ReproducirSonido();
    }

    public void CambiarVolumenMaster(float vol)
    {
        mixer.SetFloat("VolMaster", vol);
    }
    public void CambiarVolumenFX(float vol)
    {
        mixer.SetFloat("VolFX", vol);
    }

    public void ReproducirSonido()
    {
        fxSourse.PlayOneShot(ClickSound);
    }
    public void Inicio(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void PlayLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void Multiplayer(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
