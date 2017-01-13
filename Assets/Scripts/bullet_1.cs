using UnityEngine;
using System.Collections;

public class bullet_1 : MonoBehaviour {

    public float speed;
    Rigidbody2D body;
	// Use this for initialization
	void Awake () {
        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.up * speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > Camera.main.orthographicSize| transform.position.x < -Camera.main.orthographicSize|transform.position.y > Camera.main.orthographicSize | transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
       
    }

    void OnCollisionTrigger2D() {
        Destroy(gameObject);
    }
}
