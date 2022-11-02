using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LP.TurnBasedStratey
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject Player = null;
        [SerializeField] private GameObject Enemy = null;
        [SerializeField] private Slider PlayerHealth = null;
        [SerializeField] private Slider EnemyHealth = null;
        [SerializeField] private Button FightBTN = null; 
        [SerializeField] private Button HealBTN = null;
        [SerializeField] private Button BlockBTN = null;
        [SerializeField] private bool ChangeState;
        

        public bool Isplayerblocking = false;

        private bool isPlayersturn = true;

        

        private void Fight(GameObject target, float damage)
        {
            if (target == Enemy)
            {
                EnemyHealth.value -= damage;
            }
            else
            {
                PlayerHealth.value -= damage;
            }
            ChangeTurn();
        }
        private void Heal(GameObject target, float amount)
        {
            if (target == Enemy)
            {
                EnemyHealth.value += amount;
            }
            else
            {
                PlayerHealth.value += amount;
            }
            ChangeTurn();
        }
       
            

        private void Block(GameObject target, float avoid)
        {
            Isplayerblocking = true;
            if (target = Player)
            {
                PlayerHealth.value -= avoid;
            }
            
            ChangeTurn();
        }
        

        public void BtnFight()
        {
            Fight(Enemy, 10);
        }
        public void BtnHeal()
        {
            Heal(Player, 5);
        }
        public void BtnBlock()
        {
            Block(Player, 1);
        }
       
        
        private void ChangeTurn()
        {
            isPlayersturn = !isPlayersturn;
            
            if (!isPlayersturn)
            {
                StartCoroutine(Enemyturn());
                FightBTN.interactable = false;
                HealBTN.interactable = false;
                BlockBTN.interactable = false;

               
            }
            else
            {
                
                FightBTN.interactable = true;
                HealBTN.interactable = true;
                BlockBTN.interactable = true;
            }
        }
        private void Playerblocking()
        {
            Isplayerblocking = !Isplayerblocking;

            if (Isplayerblocking)
            {
                

            }
            else
            {
               
            }
        }


        private IEnumerator Enemyturn()
        {
           
            yield return new WaitForSeconds(2.5f);

            int random = 0;
            random = Random.Range(1 , 3);
         
            if (random == 1)
            {
                 
                Fight(Player, 9);
            }
            else 
            {
                Heal(Enemy, 4);
            }
           
        }
    }
}


