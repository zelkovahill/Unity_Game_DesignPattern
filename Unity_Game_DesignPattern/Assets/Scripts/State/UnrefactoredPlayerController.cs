using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    private void GetInput()
    {
        // 걷기 및 점프 컨트롤 처리
    }

    private void Walk()
    {
        
    }
}
