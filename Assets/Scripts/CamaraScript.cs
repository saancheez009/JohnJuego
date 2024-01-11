using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject John;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Posición actual de la cámara
        Vector3 posicion = transform.position;
        // Posición de John
        posicion.x = John.transform.position.x;
        // La posición actual toma la posición de John
        transform.position = posicion;
    }
}
