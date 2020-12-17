using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//chaining combos using enum
//the state that the player  is in
public enum ComboState{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private bool activateTimerToReset;
    //default combo timer 
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;
    private ComboState current_Combo_State;
    
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    //when we start the game we are not going to have any combo state
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttack();
        ResetComboState();
    }

    void ComboAttack()
    {
        //GetKeyDown will detect it once even when you hold it 
        //Combo attacks code
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(current_Combo_State == ComboState.PUNCH_3 ||
                current_Combo_State == ComboState.KICK_1 ||
                current_Combo_State == ComboState.KICK_2) 
                //return in a void function simply exit the function thus bellow code will not execute  
                return;

            //we are moving the combo state from none to punch one
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;


            if(current_Combo_State == ComboState.PUNCH_1) {
                player_Anim.Punch_1();
            }
            if (current_Combo_State == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }
            if (current_Combo_State == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }

        }

        
        if (Input.GetKeyDown(KeyCode.X))
        {
            //if the current combo is punch 3 or kick 2
            //return meaning exit because we have no combo to perform 
            if(current_Combo_State == ComboState.KICK_2 ||
                current_Combo_State == ComboState.PUNCH_3)
                return;

            //if the current combo state is NONE, or Punch_1 or Punch_2 
            //then we can set current combo state to kick 1 to chain the combo
            if(current_Combo_State == ComboState.NONE ||
                current_Combo_State == ComboState.PUNCH_1 ||
                current_Combo_State == ComboState.PUNCH_2) {

                current_Combo_State = ComboState.KICK_1;

            } else if(current_Combo_State == ComboState.KICK_1){
                 
                //move to kick2
                current_Combo_State++;
            }
             
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.KICK_1)
            {
                player_Anim.Kick_1();
            }
            if (current_Combo_State == ComboState.KICK_2)
            {
                player_Anim.Kick_2();
            }
        }
    }


    //reset combo state
    void ResetComboState() {
        if (activateTimerToReset)
        {
            //if activateTimerToReset = true it will start subtracting 
            current_Combo_Timer -= Time.deltaTime;
            if(current_Combo_Timer < 0f)
            {
                current_Combo_State = ComboState.NONE;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
