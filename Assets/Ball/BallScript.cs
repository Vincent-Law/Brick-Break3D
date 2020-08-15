using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position;
        }
        if (Input.touchCount >= 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Touch Pressed");
            }

            if (Input.touches[0].phase == TouchPhase.Ended && !inPlay)
            {
                inPlay = true;
                rb.AddForce(Vector3.forward * speed);
                Debug.Log("Touch Lifted/Released");
            }
        }
        if (speed < 450)
        {
            speed = 450;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("loseBall"))
        {
            Debug.Log("Ball was Missed");
            rb.velocity = Vector3.zero;
            inPlay = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy (other.gameObject);
        }
    }
}
