using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletspeed;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.MovePosition(transform.position + transform.up * bulletspeed * Time.deltaTime);  
    }

    void OnTriggerEnter2D (Collider2D other)
    {

        string tag = other.gameObject.tag;

        if (tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (tag == "Border")
        {
            Destroy(gameObject);

        }

    }
}
