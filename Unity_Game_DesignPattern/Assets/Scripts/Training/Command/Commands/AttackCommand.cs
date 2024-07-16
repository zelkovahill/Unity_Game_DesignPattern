using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command{
    public class AttackCommand : ICommand
    {
            private CharacterAttack characterAttack;



            public AttackCommand(CharacterAttack _characterAttack){
                characterAttack = _characterAttack;
            }


        public void Execute(){
            characterAttack.Attack();

        }

        public Sprite GetSprite(){
            return CommandManager.instance.commandSprites.attack;

        }

    
    }
    
}

