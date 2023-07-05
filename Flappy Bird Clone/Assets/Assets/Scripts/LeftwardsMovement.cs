using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftwardsMovement : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    float lvl1speed = 2.6f;
    float lvl2speed = 1.3f;
    float lvl3speed = 0.75f;
    float lvl4speed = 0.5f;

    void Start()
    {        
        
        if (GetComponent<SpriteRenderer>() == null)
        {
            GetComponentInChildren<SpriteRenderer>();

        }
        else {

            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {        
        //Logra el parallax effect distribuyendo los diferentes objetos en distintas capas, y dándoles distintas velocidades a cada una
        if(spriteRenderer.sortingLayerName == "Lvl.1")
        {
            moveLeft(lvl1speed);
        }
        else if (spriteRenderer.sortingLayerName == "Lvl.2")
        {
            moveLeft(lvl2speed);
        }
        else if (spriteRenderer.sortingLayerName == "Lvl.3")
        {
            moveLeft(lvl3speed);
        }
        else if (spriteRenderer.sortingLayerName == "Lvl.4")
        {
            moveLeft(lvl4speed);
        }

        //Destruye el objeto cuando sale de la pantalla para ahorrar recursos
        if (transform.position.x <= -14)
        {            
            GameObject.Destroy(gameObject);
        }
    }

    void moveLeft(float lvlnSpeed)
    {
        transform.position = transform.position + (Vector3.left * lvlnSpeed) * Time.deltaTime;
    }
}
