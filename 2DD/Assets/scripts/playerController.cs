using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float timeBetwenShots;

    public float speed;
    public GameObject bullet;
    public Transform FirePoint;
    public float fireRate;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();

        Move();

        Shoot();
    }


    void LookAtMouse ()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y);

            transform.up = direction;
    }

    void Move()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        Vector2 velocity = movement * speed * Time.deltaTime;

        rb2d.MovePosition(velocity + rb2d.position);
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && timeBetwenShots >= fireRate)
        {
            Instantiate(bullet, FirePoint.position, transform.rotation);
            timeBetwenShots = 0;
        }

        timeBetwenShots += Time.deltaTime;

        if (timeBetwenShots > fireRate)
        {
            timeBetwenShots = fireRate;
        }
    }

}
