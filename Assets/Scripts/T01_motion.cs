using UnityEngine;
using System.Collections;

public class T01_motion : MonoBehaviour {
    Rigidbody2D body;
    Animator ani;

    public float max_speed = 1f;
    public float speed = 0.1f;
    public float rpu = 1f;
    // Use this for initialization
    void Awake () {
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.x > Camera.main.orthographicSize)
        {
            transform.position = new Vector3(-Camera.main.orthographicSize, transform.position.y);
        }
        if (transform.position.x < -Camera.main.orthographicSize)
        {
            transform.position = new Vector3(Camera.main.orthographicSize, transform.position.y);
        }
        if (transform.position.y > Camera.main.orthographicSize)
        {
            transform.position = new Vector3(transform.position.x, -Camera.main.orthographicSize);
        }
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            transform.position = new Vector3(transform.position.x, Camera.main.orthographicSize);
        }

        if (Input.GetKey(KeyCode.W))
        {

            if (Vector3.Dot(body.velocity, transform.up) < max_speed)
            {
                body.AddForce(transform.up * speed);
            }
            else
            {
               body.velocity = body.velocity.normalized * max_speed;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Vector3.Dot(body.velocity, transform.up) > 0)
            {
                body.AddForce(transform.up * speed * -1);
                if (body.angularVelocity > 0.1) { body.AddTorque(-rpu); }
                if (body.angularVelocity < -0.1) { body.AddTorque(rpu); }
            }
            else
            {
                body.velocity = Vector2.zero;
                body.angularVelocity = 0;
            }
            
        }
            
        if (Input.GetKey(KeyCode.D))
        {

            body.AddTorque(-rpu);
        }

        if (Input.GetKey(KeyCode.A))
        {

            body.AddTorque(rpu);
        }

       
    }

    void Update() {
        ani.SetFloat("anglarspeed", body.angularVelocity/100);
        ani.SetFloat("linspeed", body.velocity.magnitude/5);
    }
}
