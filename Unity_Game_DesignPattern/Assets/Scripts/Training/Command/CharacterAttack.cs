using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private float attackDamage;

        public void Attack(){
            Debug.Log(gameObject.name + " dealt " + attackDamage + " damage!");
        }
        
    }
    

}
