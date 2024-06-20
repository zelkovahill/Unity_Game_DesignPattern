using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMovable
{
    public float MoveSpeed { get; set; }
    public float Acceleration { get; set; }

    public void GoForward();
    public void Reverse();
    public void TurnLeft();
    public void TurnRight();
}

public interface IDamageable
{
    public float Health { get; set; }
    public int Defense { get; set; }
    public void Die();
    public void TakeDamage();
    public void RestoreHealth();
}

public interface IUnitStates
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }
}

public interface IExplodable
{
    public float Mass { get; set; }
    public float ExplosiveForce { get; set; }
    public float FuseDelay { get; set; }
    public void Explode();
}


public class ExplodingBarrel : MonoBehaviour,IDamageable,IExplodable
{
    public float Health { get; set; }
    public int Defense { get; set; }
    
    public float Mass { get; set; }
    public float ExplosiveForce { get; set; }
    public float FuseDelay { get; set; }
    
    
    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public void RestoreHealth()
    {
        throw new System.NotImplementedException();
    }
    
    public void Explode()
    {
        throw new System.NotImplementedException();
    }
}

public class EnemyUnit : MonoBehaviour, IDamageable, IMovable , IUnitStates
    
{
    public float Health { get; set; }
    public int Defense { get; set; }
    
    public float MoveSpeed { get; set; }
    public float Acceleration { get; set; }
    
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }
    
    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public void RestoreHealth()
    {
        throw new System.NotImplementedException();
    }

    
    public void GoForward()
    {
        throw new System.NotImplementedException();
    }

    public void Reverse()
    {
        throw new System.NotImplementedException();
    }

    public void TurnLeft()
    {
        throw new System.NotImplementedException();
    }

    public void TurnRight()
    {
        throw new System.NotImplementedException();
    }
    
}
