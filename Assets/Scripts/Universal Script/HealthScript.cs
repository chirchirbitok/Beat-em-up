using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    
    public float health = 200f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    //denote if the player is holding the script otherwise the enemy is holding the script
    public bool is_Player;
    public bool is_Enemy;
    private HealthUI health_UI;
    private HealthUIEnemy health_UI_Enemy;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
        if (is_Player)
        {
            health_UI = GetComponent<HealthUI>();
        }
        
            health_UI_Enemy = GetComponent<HealthUIEnemy>();
        
        
    } 

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;
        //display health UI/value
        if (is_Player)
        {
            health_UI.DisplayHealth(health);

        }
        else
        {
            health_UI_Enemy.DisplayHealth1(health);
        }
        








        //if life is less than 0
        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;
            if (is_Player)
            {
                //SceneManager.LoadScene("GameOver");
            }
            else
            {
                
                
                
            }
            
            //if is player deactivate enemy script
            if (is_Player)
            {
                //while the player is dead the enemy will not continue to hit the player
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }
            return;
        }
        //means enemy is holding the script
        if (!is_Player)
        {
            if(knockDown)
            {
                //50-50 chance to knock down the enemy\
                //randomizee if you are to knock down the enemy or not
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }else{
                    
                    if(Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }
        }

        
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
