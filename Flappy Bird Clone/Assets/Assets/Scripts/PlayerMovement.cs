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

    //Para el port a Android
    bool previousWasTouching = false;
    bool isTouching = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<gameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isDead == false && gameManager.gameIsPaused == false || Input.GetMouseButtonDown(0) && isDead == false && gameManager.gameIsPaused == false && gameManager.juegoEnMarcha == true)
        {
            Jump();
        }

        //Para el port a Android
        isTouching = Input.touchCount > 0; //comprueba si se está pulsando la pantalla
        if (isTouching && !previousWasTouching && isDead == false && gameManager.gameIsPaused == false && gameManager.juegoEnMarcha == true) //comprueba si se está pulsando la pantalla en este frame y no se pulsó en el anterior (entre otras cosas))
        {
            Jump();
            previousWasTouching = isTouching;
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

        FindObjectOfType<AudioManager>().Play("Jump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.juegoEnMarcha == true && isDead == false)
        {
            manager.AddScore(1);
            FindObjectOfType<AudioManager>().Play("Score");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.juegoEnMarcha == true && isDead == false) {
            isDead = true;
            manager.GameOver();

            //reproduce los sonidos correspondientes si el jugador acaba de morir
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<AudioManager>().Play("Oof");
        }
    }


}
