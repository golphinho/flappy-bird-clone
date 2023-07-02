using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftwardsMovement : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    float lvl1speed = 2f;
    float lvl2speed = 1.3f;
    float lvl3speed = 0.75f;
    float lvl4speed = 0.5f;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {        
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

        if (transform.position.x <= -14) //Destruye el objeto cuando sale de la pantalla para ahorrar recursos
        {            
            GameObject.Destroy(gameObject);
        }
    }

    void moveLeft(float lvlnSpeed)
    {
        transform.position = transform.position + (Vector3.left * lvlnSpeed) * Time.deltaTime;
    }
}
