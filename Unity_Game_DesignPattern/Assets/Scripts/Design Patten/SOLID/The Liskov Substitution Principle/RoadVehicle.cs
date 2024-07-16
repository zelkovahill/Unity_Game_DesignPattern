using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 리스코브 치환의 법칙 (The Liskov Substitution Principle)

// 기능이 상속대신 인터페이스를 통해 실행되요.
// Car와 Train 클래스가 더이상 같은 기본 클래스를 공유하지 않아요.
// 같은 기본 클래스에서 RoadVehicle과 RailVehicle을 파생시킬 수도 있으나 이 경우에는 크게 필요하지 않아요.
// 소프트웨어 개발에서는 이를 원 - 타원 문제(Circle Ellipse Problem)라고 해요.
// 모든 실제 등가 관계가 상속으로 전환되지는 않아요.

namespace DesignPattern
{

public interface ITurnable
{
    public void TurnRight();
    public void TurnLeft();
}

public interface IMoveable
{
    public void MoveForward();
    public void MoveBackward();
}

public class RoadVehicle : IMoveable , ITurnable
{
    public void MoveForward()
    {
       
    }

    public void MoveBackward()
    {
        
    }

    public void TurnRight()
    {
       
    }

    public void TurnLeft()
    {
        
    }
}

public class RailVehicle : IMoveable
{
    public float speed = 100;
    
    public virtual void MoveForward()
    {
       
    }

    public virtual void MoveBackward()
    {
        
    }
}

public class Car : RoadVehicle
{
    
}

public class Train : RailVehicle
{
    
}

}