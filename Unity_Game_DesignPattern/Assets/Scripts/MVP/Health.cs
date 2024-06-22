using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
   public event Action HealthChanged;
   
   private const int minHealth = 0;
   private const int maxHealth = 100;
   private int currntHealth;

   public int CurrentHealth
   {
      get => currntHealth;
      set => currntHealth = value;
   }
   
   public int MinHealth => minHealth;
   public int MaxHealth => maxHealth;

   public void Increment(int amount)
   {
      currntHealth += amount;
      currntHealth = Mathf.Clamp(currntHealth,minHealth,maxHealth);
      UpdateHealth();
   }

   public void Decrement(int amount)
   {
      currntHealth -= amount;
      currntHealth = Mathf.Clamp(CurrentHealth,minHealth,maxHealth);
      UpdateHealth();
   }

   public void Restore()
   {
      currntHealth = maxHealth;
      UpdateHealth();
   }

   public void UpdateHealth()
   {
      HealthChanged?.Invoke();
   }
}
