using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMovement : MonoBehaviour
{
    private float Horizontal;
    public float Speed;
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    public float JumpForce;
    public bool Grounded;
    private float valor=0.13f;
    public GameObject BalaPrefab;
    private float ultimoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //toma valores -1 izq , 0 parado y 1 derecha
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
     

        animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * valor, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, valor))
            Grounded = true;
        else
            Grounded = false;
        animator.SetBool("Grounded", Grounded);

        if (Input.GetKeyDown(KeyCode.W)&& Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > ultimoDisparo + 0.25f)
        {
            Shoot();
            ultimoDisparo = Time.time;
        }
        //si pulsa espacio, dispara
    }

    private void Jump()
    {
        rigidBody2D.AddForce(Vector2.up * JumpForce);
        
    }

    private void Shoot()
    {
        Vector3 direccion = Vector3.right;
        if (transform.localScale.x == -1.0f)
            direccion = Vector3.left;
        GameObject bala = Instantiate(
        BalaPrefab,
        transform.position + direccion * 0.1f,
        Quaternion.identity
        );
        bala.GetComponent<BalaScript>()
        .setDireccion(direccion);

    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(Horizontal * Speed, rigidBody2D.velocity.y);
    }
}
