using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasAliveManager : MonoBehaviour
{
    public static CanvasAliveManager instance;
    private EnemyPool enemyPool;
    public TextMeshProUGUI textAlive;
    private int countAlive;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    void Start()
    {
        enemyPool = EnemyPool.instance;
        countAlive = enemyPool.poolSize;
        textAlive.text = countAlive.ToString();
    }

    public void UpdateAlive() 
    {
        countAlive-=1;
        textAlive.text = countAlive.ToString();
    }
}
