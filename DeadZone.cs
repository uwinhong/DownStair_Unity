using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Player")){//碰撞检测：一旦和Player发生碰撞，则Player死亡

                Player.isDead=true;
                //Debug.Break();

            }
        }
    

    
    
}
