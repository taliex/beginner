using UnityEngine;
using System.Collections;

public class MoveByInput : MonoBehaviour {   

    Rigidbody2D body;     

    public float max_speed = 1f;
    public float speed = 0.1f;
    public float rpu = 1f;

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
        if (Input.GetKey(KeyCode.W)) {

            if (Vector3.Dot(body.velocity, transform.up) < max_speed)
            {
                body.AddForce(transform.up * speed);
            }
            else {
                
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Vector3.Dot(body.velocity,transform.up) > 0)
            {
                body.AddForce(transform.up* speed * -1);
            }
            else {
                body.velocity = Vector2.zero;
            }
        }
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
