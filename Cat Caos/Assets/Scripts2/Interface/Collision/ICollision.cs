using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollision
{
    void HandleCollision(Collider2D other);
}
