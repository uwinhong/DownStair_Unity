using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class groundManager : MonoBehaviour
{
    readonly float initPositionY = 0;//初始地板Y坐标
    [Range(2, 6)] public float spacingY;//地板Y坐标间隔
    [Range(-3, 3)] public float spacingX;//地板X坐标间隔
    public List<Transform> grounds;
    //static int groundNumber = -1;
    readonly int MAX_GROUND_COUNT = 10;//地板列表中最多容纳的地板数
    readonly int MIN_GROUND_UNDER_PLAYER =3;//玩家脚下至少出现的地板数
    public Transform player;
    public Text displayeCountFloor;//楼层显示

    
    void Start()
    {
        grounds = new List<Transform>();
        for (int i = 0; i < MAX_GROUND_COUNT; ++i)
        {
            SpawnGround();

        }
    }

    float NewGroundPositionY()//借用List清单来计算下一块地板的Y坐标
    {
        if (grounds.Count == 0)
        {
            return initPositionY;
        }
        int LowerIndex = grounds.Count - 1;//上一块地板的索引
        return grounds[LowerIndex].position.y - spacingY;//上一块地板的Y坐标减去固定Y间隔


    }

    void SpawnGround()//生成地板函数
    {

        GameObject newGround = Instantiate((GameObject)Resources.Load("object/ground"));//加载Resources/object下面的ground预设体
        //Instantiate(newGround);//实例化[error!]
        spacingX = Random.Range(-3, 3);//随机X坐标
        newGround.transform.position = new Vector3(spacingX, NewGroundPositionY(), 0);//在场景上放置地板
        grounds.Add(newGround.transform);//添加当前地板到地板清单

    }

    void ControlGroundCount()//控制地板的数量小于等于MAX_GROUND_COUNT
    {
        if (grounds.Count > MAX_GROUND_COUNT)
        {
            Destroy(grounds[0].gameObject);//摧毁0号索引地板
            grounds.RemoveAt(0);//移除0号索引地板

        }
    }

    public void ControlSpawnGround()//控制地板的生成:玩家脚下最少要有MIN_GROUND_UNDER_PLAYER个地板
    {
        int groundsCountUnderPlayer = 0;//当前玩家脚下地板数量

        foreach (Transform ground in grounds)//遍历grounds，检查在玩家脚下的地板数量
        {

            if (ground.position.y < player.position.y)
            {
                ++groundsCountUnderPlayer;
            }
        }
        //Debug.Log(groundsCountUnderPlayer);
        if (groundsCountUnderPlayer < MIN_GROUND_UNDER_PLAYER)//小于MIN_GROUND_UNDER_PLAYER
        {
            //Debug.Break();
            SpawnGround();//生成
            ControlGroundCount();//检查MAX
        }
    }

    void FloorDisplayer(){
        float playerPositionY=player.transform.position.y;
        float deep=Mathf.Abs(playerPositionY-initPositionY);//计算玩家已经走过的深度
        float FloorCount=(deep/spacingY)+1;//计算楼层,初值为一楼
        //Debug.Log(Player.egg);
        displayeCountFloor.text="地下"+FloorCount.ToString("0000")+"楼";
    }



    void Update()
    {
        ControlSpawnGround();//每帧检查玩家脚下地板数量
        FloorDisplayer();//每帧显示当前楼层

    }
}
