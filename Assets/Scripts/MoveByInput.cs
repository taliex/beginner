using UnityEngine;
using System.Collections;

public class MoveByInput : MonoBehaviour {   

    Rigidbody2D body;     

    public float max_speed = 10f;
    public float speed = 0.1f;
    public float rpu = 1f;

    float movementSpeed = 0f;
    float fiction = 0.5f;

	// Use this for initialization
	void Awake () {
        body = GetComponent<Rigidbody2D>();

            }
	
	// Update is called once per frame
	void FixedUpdate () {
        //stay in screen
        if (transform.position.x > Camera.main.orthographicSize) {
            transform.position = new Vector3(-Camera.main.orthographicSize, transform.position.y);
        }
        if (transform.position.x < -Camera.main.orthographicSize) {
            transform.position = new Vector3(Camera.main.orthographicSize, transform.position.y);
        }
        if (transform.position.y > Camera.main.orthographicSize) {
            transform.position = new Vector3(transform.position.x,-Camera.main.orthographicSize);
        }
        if (transform.position.y < -Camera.main.orthographicSize) {
            transform.position = new Vector3(transform.position.x, Camera.main.orthographicSize);
        }

        //input and move

        // Fiction
        if (movementSpeed < 0)
            movementSpeed = 0;
        if (movementSpeed > 0)
        {
            movementSpeed -= fiction;
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.W)) {

            if (movementSpeed < max_speed)
            {
                movementSpeed += speed;
                transform.position += transform.up * Time.deltaTime * movementSpeed;
            }
            else {
                Debug.Log("MAX");
                Debug.Log(movementSpeed);
                movementSpeed = max_speed;
            }
        }
        //if (input.getkey(keycode.s))
        //{
        //    if (vector3.dot(body.velocity,transform.up) > 0)
        //    {
        //        body.addforce(transform.up* speed * -1);
        //    }
        //    else {
        //        body.velocity = vector2.zero;
        //    }
        //}
        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(new Vector3(0,0,1),-rpu);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,1), rpu);
        }
              
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider == true) {
            
        

            Destroy(collision.gameObject);
            Destroy(gameObject);
            
           
        }
    }
    
}
