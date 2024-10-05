using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float tiempoEspera;

    private int posWaypoint;
    private bool isEsperando; 

    void Update()
    {
        // Si no llego al wayPoint, se mueve
        if (transform.position != waypoints[posWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[posWaypoint].position, speed * Time.deltaTime);
        }
        else if(!isEsperando)
        {
            StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar()
    {
        isEsperando = true;
        yield return new WaitForSeconds(tiempoEspera);
        posWaypoint++;
        if( posWaypoint == waypoints.Length)
        {
            posWaypoint = 0;
        }
        isEsperando= false;
    }
}
