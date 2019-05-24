using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class TrumpController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float x, y;
    private Vector3 move;
    //Create an animation  variable 
    private Animation animation;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        x = CrossPlatformInputManager.GetAxis("Horizontal");
        y = CrossPlatformInputManager.GetAxis("Vertical");
      
        move = new Vector3(x, 0, y);
        //Set Velocity of the model
        rigidbody.velocity = move * 5f;
        
        //Set the model face the direction we move the joystick
        if(x!=0 && y != 0)
        {
            //Keep rotations about x and z axis the same while change the one in the y axis
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x,y) * Mathf.Rad2Deg,transform.eulerAngles.z);
        }

        //Check if joystick is moved alteast in some way and animate accordingly
        if(x!=0 || y != 0)
        {
            animation.Play("walk");
        }
        else
        {
            animation.Play("idle");
        }
    }
}
