using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColliable
{
    void OnCollide(Collider2D other);
}
