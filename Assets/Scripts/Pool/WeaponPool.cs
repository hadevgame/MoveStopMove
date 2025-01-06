using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPool : MonoBehaviour
{
    public GameObject weaponPrefab;
    public int poolSize;
    private List<GameObject> weaponPool;
    public static WeaponPool instance;
    private int weaponsRemaining;

    private void Awake()
    {
        if (!instance) 
        {
            instance = this;
        }
    }
    void Start()
    {
        weaponPool = new List<GameObject>();
        for(int i =0; i < poolSize; i++) 
        {
            GameObject weaponPF = Instantiate(weaponPrefab);
            weaponPF.SetActive(false);
            weaponPool.Add(weaponPF);
        }
        weaponsRemaining = poolSize;
    }

    public GameObject GetWeaponFromPool() 
    {
        for(int i = 0; i < weaponPool.Count; i++) 
        {
            if (!weaponPool[i].activeInHierarchy)
            {
                weaponPool[i].SetActive(true);
                weaponsRemaining--;
                return weaponPool[i];

            }
        }
        return null;
    }

    public void ReturnToPool(GameObject weapon) 
    {
        weapon.SetActive(false);
        weapon.transform.position = this.transform.position;
        weapon.transform.SetParent(this.transform);
        weaponsRemaining++;
    }
}
