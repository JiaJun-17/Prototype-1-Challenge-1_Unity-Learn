using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3 (30,0,10);

    // Start is called before the first frame update
    void Start() //Awake()
    {

    }

    // Update is called once per frame
    void LateUpdate() //LateUpdate() is used when there is a camera following the player
    {
        transform.position = plane.transform.position + offset;
    }
}
