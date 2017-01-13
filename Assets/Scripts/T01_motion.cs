using UnityEngine;
using System.Collections;

public class T01_motion : MonoBehaviour {
    Rigidbody2D body;
    Animator ani;

    public float max_speed;
    public float speed;
    public float maxrot;
    public float rot;

    float movementspeed;
    float fireratecheck=0;

    public GameObject[] shooterpos = new GameObject[4];
    public GameObject bullet;
    //public GameObject sparks;
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
        //motion
        //tranverse
        if (Input.GetKey(KeyCode.W))
        {

            if (body.velocity.magnitude < max_speed)
            {
                movementspeed += speed;
            }
            else
            {
                movementspeed = max_speed;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (body.velocity.magnitude > 0.1)
            {
                movementspeed -= speed;
            }
            else
            {
                movementspeed = 0;
            }
        }

        body.velocity = new Vector2(transform.up.x,transform.up.y)*movementspeed;
        //rotation
        if (Input.GetKey(KeyCode.A))
        {
            if ( body.angularVelocity < maxrot)
            {
                body.angularVelocity += rot;
            }
            else
            {
                body.angularVelocity = maxrot;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (body.angularVelocity > -maxrot)
            {
                body.angularVelocity -= rot;
            }
            else
            {
                body.angularVelocity = -maxrot;
            }
        }
        //fire
        if (Input.GetKey(KeyCode.J)) {
            fireratecheck += Time.deltaTime;
            if (fireratecheck > 0.05f) { 
                int i = (int)Random.Range(0, 4);
                /*GameObject bul = (GameObject)*/Instantiate(bullet, shooterpos[i].transform.position, shooterpos[i].transform.rotation);
                //Instantiate(sparks, shooterpos[i].transform.position, shooterpos[i].transform.rotation);
                
                fireratecheck = 0;
            }
        }

       
    }

    void Update() {
        ani.SetFloat("anglarspeed", body.angularVelocity/maxrot);
        ani.SetFloat("linspeed", body.velocity.magnitude/max_speed);
    }
}
