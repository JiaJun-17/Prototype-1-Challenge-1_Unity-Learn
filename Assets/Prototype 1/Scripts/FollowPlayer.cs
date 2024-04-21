using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;  //create player variable that can store references, numbers, etc
    [SerializeField] Vector3 offset = new Vector3 (0,4,-7);  //[SerializeField] can make the variable visible in editor, can change at the editor instead of in script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()   //Camera jittery issue, so let vehicle moves first, LateUpdate, making camera following the vehicle
    {
        //offset the camera behind the player by adding to the player's positiom
        //transform.position=player.transform.position + new Vector3(0,4,-7);  //to player's current transform.position
        //avoid hard-coded value, so add a offset variable as private variable
        //(x,y,z) while y is up/down, x is left/right, z is front/back
        transform.position=player.transform.position + offset;
    }
}
