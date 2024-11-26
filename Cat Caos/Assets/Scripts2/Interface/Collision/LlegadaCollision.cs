using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaCollision : ICollision
{
    public void HandleCollision (Collider2D other)
    {
        ControladorPuntaje.Instance.SumaPuntuacionLlegada();
        GameManager.Instance.Marcador();
    }
}
