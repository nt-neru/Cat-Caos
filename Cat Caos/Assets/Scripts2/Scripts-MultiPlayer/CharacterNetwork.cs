using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public class CharacterNetwork : NetworkBehaviour
{
    protected Rigidbody2D rb;

    protected virtual void Start() // Acceso a las subclases y abierto a la sobreescritura de estas
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
