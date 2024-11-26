using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaCollision2 : ICollision
{
    public void HandleCollision (Collider2D other)
    {
        GameManager.Instance.Marcador();
        ControladorPuntaje.Instance.SumaPuntuacionLlegada();
    }
}
