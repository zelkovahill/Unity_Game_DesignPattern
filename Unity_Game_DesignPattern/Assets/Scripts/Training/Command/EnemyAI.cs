using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command{



public class EnemyAI : MonoBehaviour
{
    [SerializeField] private CharacterMover characterMover;

    private void OnEnable(){
        CommandManager.instance.OnCommandsExecute += CalculateMovement;
    }

    private void OnDisable(){
        CommandManager.instance.OnCommandsExecute -= CalculateMovement;
    }


    private void CalculateMovement(){
        Vector2[] directions = new Vector2[]
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        int randomIndex = Random.Range(0, directions.Length);
        Vector2 direction = directions[randomIndex];

        MoveCommand moveCommand = new MoveCommand(characterMover, direction);
        CommandManager.instance.AddCommand(moveCommand);
        }

    }
    
}

