using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Material[] listMaterial;
    public GameObject enemyPrefab;
    void Start()
    {
        Spawn();
    }

    void Spawn() 
    {
        Instantiate(enemyPrefab);
        enemyPrefab.transform.position = this.transform.position;
        int random = Random.Range(1, 8);
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
                    materials[i] = listMaterial[random];
                }
                renderer.materials = materials;
            }
        }
    }
}
