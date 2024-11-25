using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaCollision : ICollision
{
    public void HandleCollision (Collider2D other)
    {
        GameManager.Instance.CambioNivel();
    }
}
