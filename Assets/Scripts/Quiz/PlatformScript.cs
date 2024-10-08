using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    float torqueAmount = 0.1f;
    bool collided = false;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rb2d.AddTorque(torqueAmount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !collided) 
        {
            Invoke("ResetAngle", 3);
            collided = true;
            Debug.Log("Collision!");
        }
    }

    void ResetAngle()
    {
        rb2d.SetRotation(0);
        collided = false;
        Debug.Log("Reset!");
    }
}
