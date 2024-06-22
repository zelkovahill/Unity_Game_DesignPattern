using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
   [SerializeField] private Health health;
   [SerializeField] private Slider healthSlider;

   private void Start()
   {
      if (health != null)
      {
         health.HealthChanged += OnHealthChanged;
      }
      UpdateView();
   }

   private void OnDestroy()
   {
      if (health != null)
      {
         health.HealthChanged -= OnHealthChanged;
      }
   }


   public void Damage(int amount)
   {
      health?.Decrement(amount);
   }
   
   public void Heal(int amount)
   {
      health?.Increment(amount);
   }

   public void Reset()
   {
      health?.Restore();
   }

   public void UpdateView()
   {
      if (health == null)
      {
         return;
      }

      if (healthSlider != null && health.MaxHealth != 0)
      {
         healthSlider.value= (float) health.CurrentHealth/ (float) health.MaxHealth;
      }
   }

   public void OnHealthChanged()
   {
      UpdateView();
   }
}
