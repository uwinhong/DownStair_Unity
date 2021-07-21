using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 1;//摄像机下降速度
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
       transform.Translate(0,-cameraSpeed*Time.deltaTime,0);//Y轴匀速下降，每秒下降cameraSpeed个单位
       

    }
}
