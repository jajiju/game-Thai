using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float maxSpeed = 100f;
    public float speed = 50f;
    public float jumpPower = 50f;

    public bool grounded;
    public bool goingUp;

    private Animator anim;
    public Rigidbody2D rb2d;
    public Collider2D cl2d;

	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        cl2d = gameObject.GetComponent<Collider2D>();
	}

    void Update()
    {
        anim.SetBool("goingUp", goingUp);
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.AddForce((Vector2.up * jumpPower));
        }

        if (rb2d.velocity.y >= 0) goingUp = true; else goingUp = false;
    }

	void FixedUpdate () {
        Vector3 easeVelocity = rb2d.velocity;

        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed) rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        if (rb2d.velocity.x < -maxSpeed) rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
    }
}
