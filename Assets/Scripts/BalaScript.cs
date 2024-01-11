using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;             // Factor velocidad de la bala
    private Rigidbody2D Rigidbody2D;        // Físicas asociadas a la bala
    private Vector2 Direccion;          // Direccion de la bala
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Carga de físicas
    }
    private void FixedUpdate()
    {   // Cálculo de la velocidad de la bala
        if (Direccion.x< 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Direccion.x > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Rigidbody2D.velocity = Direccion * Speed;
    }
    public void setDireccion(Vector2 direccion)
    {
        Direccion = direccion;
    }

    public void destroyBala()
    {
        Destroy(gameObject);
    }

}
