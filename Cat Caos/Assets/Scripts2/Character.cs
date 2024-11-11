using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected virtual void Start() // Acceso a las subclases y abierto a la sobreescritura de estas
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
