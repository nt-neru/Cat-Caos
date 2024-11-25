using UnityEngine;
using Cinemachine;
using FishNet.Object;
//using FishNet.Component.Model;

public class CameraFollow : NetworkBehaviour
{
    private CinemachineVirtualCamera virtualCamera; // Cámara virtual de Cinemachine
    private Transform target; // El objeto a seguir (Character copia)

    void Start()
    {
        // Verificar si este cliente es el dueño del objeto
        if (IsOwner)
        {
            // Obtener la cámara virtual Cinemachine en el objeto donde este script se adjunta
            virtualCamera = GetComponent<CinemachineVirtualCamera>();

            // Verificar que el objeto tenga el componente CinemachineVirtualCamera
            if (virtualCamera == null)
            {
                Debug.LogError("CinemachineVirtualCamera no encontrado en el objeto.");
                return;
            }

            // Buscar el objeto "Character (copia)" en la escena
            target = GameObject.Find("Character (copia)")?.transform;

            // Verificar si el objeto fue encontrado
            if (target != null)
            {
                // Asignar el objeto al que se debe seguir (el jugador local)
                virtualCamera.Follow = target;
            }
            else
            {
                Debug.LogWarning("No se encontró un objeto llamado 'Character (copia)' en la escena.");
            }
        }
        else
        {
            // Si este cliente no es el dueño, no hace nada.
            Debug.Log("Este cliente no es el propietario de 'Character (copia)', la cámara no se moverá.");
        }
    }

    // Este método será llamado cuando el objeto cambie de propietario.
  
}