using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacioCollision : ICollision
{
    public void HandleCollision (Collider2D other)
    {
        GameManager.Instance.Morir();
    }
}
