using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attack_Distance = 1f;
    public float chase_Player_After_Attack = 1f;

    private float current_Attack_Time;
    private float default_Attack_Time = 1f;

    private bool followPlayer, attackPlayer;

    void Awake()
    {
        //script is attached on the enemy child and not the Enemy 
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //allow wnemy to follow player
        followPlayer = true;
        //follow player when we get to the destination
        current_Attack_Time = default_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        
        Attack();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        // if we are not suppose to follow the player it will exit
        if(!followPlayer)
           return;
        
        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            //rotate toward the player
            transform.LookAt(playerTarget);//makes the forwad look at this direction
            myBody.velocity = transform.forward * speed;   //moving forward direction with this speed

            //if it is not equal to zero it means we are moving
            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }else if(Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            //this will stop the movement automaticaly
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }

        
    }

    //attack
    void Attack()
    {
        //exit function is not attack a player 
        if (!attackPlayer)
            return;

        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time > default_Attack_Time)
        {
            //perform the attack
            //will return a randorm value either attack with kick or punch
            enemyAnim.EnemyAttack(Random.Range(0, 3));

            current_Attack_Time = 0f;
        }
        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }




}
