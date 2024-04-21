using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Inherit from MonoBahaviour class which is already made in Unity
public class PlayerController : MonoBehaviour
{
    //Public Variables
    //If public modifier, then it will be visible in the inspector window
    //Variable like speed/turnSpeed etc should start with small letter
    [SerializeField] float speed; //assign speed to 5.0 //private can only be used within the class  //public can be used outside of the class
    [SerializeField] private float horsePower = 0; //can change the value in Unity Editor
    [SerializeField] float rpm;
    public float turnSpeed = 25.0f;  //put f because pc won't recognize if the value is a float or not
    public float horizontalInput; //to control Left or Right (pressing Left key or Right key)
    public float forwardInput;  //to control Forward or Backward (pressing Up or Down key)

    private Rigidbody playerRB;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelIsOnGround;
 
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //We get player's input//
        horizontalInput = Input.GetAxis("Horizontal"); //Input is a method (Edit->Project Setting->Input Manager)
        forwardInput = Input.GetAxis("Vertical"); //get the user's vertical input (front or back)

        if(IsOnGround()) //if true, can move the wheel, if false, cannot move the wheel
        {
        //We move the vehicle forward or backward//
        //Translate is one of the methods
        //v1 transform.Translate(0,0,1); // (float x, float y, float z)
        //v3 transform.Translate(Vector3.forward); //same as (0,0,1)
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); //Time.deltaTime is 1 unit per sec. 
        // =(x * Time * 5), (y * Time * 5), (z * Time * 5)
        playerRB.AddRelativeForce(Vector3.forward * horsePower * forwardInput); //* forwardInput because we want to control it

        //We turn the vechile to Left or Right//
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // translate cannot because it is unlogical for car driving by changing direction of Left and Right
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);  //why up? because while car turn to Left or Right, value Y is changing in Rotation

        speed = Mathf.RoundToInt(playerRB.velocity.magnitude * 2.237f); //for kph, change 2.237 to 3.6
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = (speed % 30) * 40; //give the remainder value
        rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround() //speed and RPM will stop when the car is leaving the ground
    {
        wheelIsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelIsOnGround++;
            }
        }

        if(wheelIsOnGround == 4)
        {
            return true;
        }
        
        else
        {
            return false;
        }
    }
}
