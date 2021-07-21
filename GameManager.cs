using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;//重新开始按钮
  

    public GameObject player;//玩家
    void Start()
    {
        restartButton.gameObject.SetActive(false);//按钮先隐藏

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.isDead)
        {
            player.SetActive(false);//玩家死亡，隐藏

            restartButton.gameObject.SetActive(true);//按钮出现


        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//按下按钮，重新加载场景
    }
}
