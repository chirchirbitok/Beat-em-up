using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;

    private float rotation_Y = -90f;

    private float rotation_Speed = 15f;8
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    //Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        DetectMovement();
        AnimatePlayerWalk();
    }

    //Movement
    void DetectMovement()
    {
        // Movement
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed)
            );

    }

    //Rotation
    void RotatePlayer()
    {
        //greater than zero means value 1 moving to the right side
         if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            //Quaternion.Euler is for rotation of the player while moving
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
        }//less than zero moving to the left side
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            //Math.Abs to return absolute value which is a positive value 
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    }

    //animate player walk
    void AnimatePlayerWalk()
    {
        //if not pressing any button horizontal or vertical the get axis row will return zero
        //it means we are pressing then we will call the animator walk
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 ||
               Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0) {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }
    }
}
