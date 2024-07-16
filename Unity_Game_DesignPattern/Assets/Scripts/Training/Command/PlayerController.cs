using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command{


    [RequireComponent(typeof(CharacterAttack))]
    [RequireComponent(typeof(CharacterMover))]
    public class PlayerController : MonoBehaviour
{
    private CharacterMover characterMover;
    private CharacterAttack characterAttack;

    private void Awake(){
        characterMover = GetComponent<CharacterMover>();
        characterAttack = GetComponent<CharacterAttack>();
    }

    private void Update(){
         Move();
        Attack();

    }

    private void Move(){
        Vector2 inputVector = Vector2.zero;

        if(Input.GetKeyDown(KeyCode.W)){
            inputVector = new Vector2(0,1);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            inputVector = new Vector2(0,-1);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            inputVector = new Vector2(-1,0);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            inputVector = new Vector2(1,0);
        }

        if(inputVector == Vector2.zero){
            return;
        }

       
    }

    private void Attack(){
        if(Input.GetMouseButtonDown(1)){
            CommandManager.instance.AddCommand(new AttackCommand(characterAttack));
        
        
    }
}

}
}


