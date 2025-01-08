using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
public class SpawnEnemy : MonoBehaviour
{
    public Material[] listMaterial;
    public Transform[] listSpawnPoint;
    private EnemyPool enemyPool;
    public int enemyCount;
    private int currentPoint = 0;
    void Start()
    {
        enemyPool = EnemyPool.instance;
        
        InvokeRepeating("Spawn", 0f,1f);
        //Spawn();
    }
    private void Update()
    {
        if (enemyPool.poolSize <= 0 || enemyCount <=0) 
        {
            CancelInvoke("Spawn");
        }
    }

    void Spawn() 
    {
        GameObject enemyPrefab = enemyPool.GetEnemyFromPool();
        enemyPrefab.transform.position = listSpawnPoint[currentPoint].transform.position;
        currentPoint+=1;
        if (currentPoint >= listSpawnPoint.Length)
        {
            currentPoint = 0;
        }
        enemyPrefab.SetActive(true);
        enemyCount--;
        int randomColor = Random.Range(0, 7);
        Transform[] childs = enemyPrefab.GetComponentsInChildren<Transform>();
        foreach (Transform child in childs)
        {
            // Kiểm tra nếu đối tượng con có Renderer
            SkinnedMeshRenderer renderer = child.GetComponent<SkinnedMeshRenderer>();
            if (renderer != null)
            {
                // Lấy danh sách các vật liệu của Renderer
                Material[] materials = renderer.sharedMaterials;
                // Duyệt qua từng vật liệu của Renderer
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = listMaterial[randomColor];
                }
                renderer.materials = materials;
            }
        }
        
    }
}
