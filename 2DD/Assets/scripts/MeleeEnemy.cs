using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float speed;
    public float attackWaitTime;

    private GameObject player;
    private Rigidbody2D rb2d;
    private float attackWait;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {

            float distance = Vector3.Distance(player.transform.position, transform.position);
            Vector3 lookPosition = player.transform.position - transform.position;



            transform.up = lookPosition;
            if (distance <= 1.7f)
            {
                if (attackWait <= attackWaitTime)
                {
                    attackWait += Time.deltaTime;
                }
                else
                {
                    Debug.Log("attack");
                    attackWait = 0;
                    Destroy(player);
                }
            }
            else
            {
                rb2d.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
                attackWait = 0;
            }
        }
        else
        {
            Debug.Log("no player");
            rb2d.bodyType = RigidbodyType2D.Static; 
        }

    }
}
