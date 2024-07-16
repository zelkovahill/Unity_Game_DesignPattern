using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{

public enum PlayerControllerState
{
    Idle,
    Walk,
    jump
}

public class UnrefactoredPlayerController : MonoBehaviour
{
    public PlayerControllerState state;

    private void Update()
    {
        GetInput();
        
        switch(state)
        {
            case PlayerControllerState.Idle:
                Idle();
                break;
            case PlayerControllerState.Walk:
                Walk();
                break;
            case PlayerControllerState.jump:
                Jump();
                break;
        }
    }

    private void GetInput()
    {
        // 걷기 및 점프 컨트롤 처리
    }

    private void Walk()
    {
        // 걷기 로직
    }

    private void Idle()
    {
        // 대기 상태 로직
    }

    private void Jump()
    {
        // 점프 로직
    }
}

}