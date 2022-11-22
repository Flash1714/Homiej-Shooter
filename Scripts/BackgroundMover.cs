using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private float width = 56.88f;
    private float height = 32.19f;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) return;  
        if(target.position.x - transform.position.x > (1.5 * width))
        {
            transform.position = new Vector2(transform.position.x + (3 * width), transform.position.y);
        }
        else if (target.position.x - transform.position.x < (-1.5 * width))
        {
            transform.position = new Vector2(transform.position.x - (3 * width), transform.position.y);
        }
        else if (target.position.y - transform.position.y > (1.5 * height))
        {
            transform.position = new Vector2(transform.position.x , transform.position.y + (3 * height));
        }
        else if (target.position.y - transform.position.y < (-1.5 * height))
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - (3 * height));
        }
    }
}
