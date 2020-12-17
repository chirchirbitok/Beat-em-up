using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;

    public GameObject hit_Fx_Prefab;
    

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    
    //detect collision
    void DetectCollision()
    {
        //will create a sphere at that position with that radius 
        //invisible sphere that will detect collision on game object on a default layer
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        //if we have a hit
        if(hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFX_Pos = hit[0].transform.position;
                //where the effect will be seen
                hitFX_Pos.y += 1.3f;

                //where the game object is facing
                // if it is greater than zero means we are facing the left
                if(hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                } else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }

                Instantiate(hit_Fx_Prefab, hitFX_Pos, Quaternion.identity);

                //if it is left arm or leg we pass either the enemy is damaged or not
                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) ||
                    gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }

            if (is_Enemy)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
            }

            gameObject.SetActive(false);
        }
        
    }
}
