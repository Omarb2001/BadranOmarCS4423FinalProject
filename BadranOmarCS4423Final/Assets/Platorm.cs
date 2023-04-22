using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platorm : MonoBehaviour
{
    public Transform up;

    public Transform down;

    public bool upwards;

    public float speed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        platform();
        
    }
    void platform(){
    if(upwards){
            transform.position = Vector2.MoveTowards(transform.position, up.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, up.position) < .2f)
                upwards = false;
        }

        if(!upwards){
            transform.position = Vector2.MoveTowards(transform.position, down.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, down.position) < .2f)
                upwards = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("something");
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other) {
         other.transform.SetParent(null);
    }
}
