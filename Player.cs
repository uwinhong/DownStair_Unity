using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceX;//水平推力
    public Rigidbody2D playerRigidBody2d;//获取玩家
    public static bool isDead;//是否死亡
    
    

    void Start()
    {
        
        isDead=false;
    }

    void Movement()
    {
        float direction = Input.GetAxis("Horizontal");//获取移动方向，-1为左，1为右，0为静止
        if (direction != 0)
        {
            Vector2 newDirection = new Vector2(direction * forceX, 0);//获取力的大小，转化为Vector2
            playerRigidBody2d.AddForce(newDirection);//施力
        }

    }


    void Update()
    {
        Movement();//实时检测
    }
}
