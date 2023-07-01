using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
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
}
