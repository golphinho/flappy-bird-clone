using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftwardsMovement : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    float lvl1speed = 1;
    float lvl2speed = 1;
    float lvl3speed = 1;
    float lvl4speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
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
    }

    void moveLeft(float lvlnSpeed)
    {
        transform.position = transform.position + (Vector3.left * lvlnSpeed) * Time.deltaTime;
    }
}
