using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftwardsMovement : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    float lvl1speed = 2.7f;
    float lvl2speed = 1.4f;
    float lvl25speed = 1f;
    float lvl3speed = 0.75f;
    float lvl4speed = 0.5f;
    float skyspeed = 0.25f;

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
        else if (spriteRenderer.sortingLayerName == "Lvl.2.5")
        {
            moveLeft(lvl25speed);
        }
        else if (spriteRenderer.sortingLayerName == "Lvl.3")
        {
            moveLeft(lvl3speed);
        }
        else if (spriteRenderer.sortingLayerName == "Lvl.4")
        {
            moveLeft(lvl4speed);
        }
        else if (spriteRenderer.sortingLayerName == "Sky")
        {
            moveLeft(skyspeed);
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
