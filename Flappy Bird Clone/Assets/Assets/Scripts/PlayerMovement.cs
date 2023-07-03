using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    Rigidbody2D rigidBody;

    public gameManager manager;

    bool isDead = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<gameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isDead == false)
        {
            Jump();
        }

        //Destruye el objeto si se sale de la pantalla (para ahorrar recursos en la pantalla de Game Over)
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

        //Hace que en el menú de inicio el objeto no caiga
        if (gameManager.juegoEnMarcha == true)
        {
            rigidBody.WakeUp();            
        }
    }

    private void Jump() //Cambia la velocidad del cuerpo, añadiéndole una cierta velocidad hacia arriba y haciendo que "salte"
    {
        //Opción más realista que cambiar la velocidad, pero menos cómoda a la hora de jugar:
        //rigidBody.AddForce(new Vector2(0f, jumpForce / Time.deltaTime), ForceMode2D.Force);

        //Lo mismo pero expresado de otra forma:
        //rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse)

        rigidBody.velocity = new Vector2 (0f, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.juegoEnMarcha == true)
        {
            manager.AddScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.juegoEnMarcha == true) {
            isDead = true;
            manager.GameOver();
        }
    }


}
