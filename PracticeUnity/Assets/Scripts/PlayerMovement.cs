using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Use other components properties
    public Rigidbody rb;

    public float fowardForce = 2000f;
    public float sideForce = 500f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //When using physics use FixedUpdate instead of Update
    void FixedUpdate()
    {
      //Adds foward force
      //x y z force mode
      rb.AddForce(0,0,fowardForce * Time.deltaTime);

      if (Input.GetKey("d") || Input.GetKey("right"))
      {
        rb.AddForce(sideForce*Time.deltaTime, 0,0, ForceMode.VelocityChange);
      }
      if (Input.GetKey("a") || Input.GetKey("left"))
      {
        rb.AddForce(-sideForce*Time.deltaTime, 0,0,ForceMode.VelocityChange);
      }
      if (rb.position.y < -1)
      {
        FindObjectOfType<GameManager>().EndGame();
      }
    }
}
