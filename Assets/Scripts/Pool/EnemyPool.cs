using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;
    public GameObject enemyPrefab;
    public int poolSize;
    private List<GameObject> enemyPool;
    private int poolCount;
    
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyPF = Instantiate(enemyPrefab);
            enemyPF.SetActive(false);
            enemyPool.Add(enemyPF);
        }
        poolCount = poolSize;
       
    }
    public GameObject GetEnemyFromPool()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                if (enemyPool[i].gameObject != null)
                {
                    enemyPool[i].SetActive(true);
                    poolCount--;
                    return enemyPool[i];
                }
                else continue;
            }
            
        }
        return null;
    }
}
