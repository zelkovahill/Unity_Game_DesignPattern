using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // private void RunPlayerCommand(PlayerMover playerMover, Vector3 movement)
    // {
    //     if (playerMover == null)
    //     {
    //         return;
    //     }
    //
    //     if (playerMover.IsValidMove(movement))
    //     {
    //         ICommand command = new MoveCommand(playerMover, movement);
    //         CommandInvoker.ExecuteCommand(command);
    //     }
    // }
}
}
