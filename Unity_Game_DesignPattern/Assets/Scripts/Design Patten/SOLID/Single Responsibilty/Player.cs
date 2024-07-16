using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 단일 책임 원칙 (Single Responsibility Principle)
// 플레이어가 무언가에 충돌하면 소리를 재생하고, 입력을 관리하고, 이동을 처리 합니다.
// 지금은 비교적 짧은 클래스지만 프로젝트를 진행하다 보면 점점 유지하기 어려워 질 수 있어요.
// Player 클래스를  더 작은 여러 클래스로 분할해 보아요.

// 단일 책임 원칙을 따라 작업할 때 염두에 둘 만한 목표
// 가독성 : 클래스가 짧으면 읽기 쉬워져요. 엄격하고 직관적인 규칙은 없지만 많은 개발자가 라인의 수를 200~300줄로 제한해요. 
// 확장성 : 작은 클래스에서 상속하기가 더 쉬워요. 의도치 않은 기능 장애를 걱정할 필요 없이 클래스를 수정하거나 대체해보아요.
// 재사용성 : 게임의 다른 부분에 재사용할 수 있도록 클래스를 작은 모듈형으로 디자인해보야요.

namespace DesignPattern
{

[RequireComponent(typeof(PlayerAudio), typeof(PlayerInput),
    typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAudio playerAudio;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
}

public class PlayerAudio : MonoBehaviour
{
    
}

public class PlayerInput : MonoBehaviour
{
    
}

public class PlayerMovement : MonoBehaviour
{
    
}

}