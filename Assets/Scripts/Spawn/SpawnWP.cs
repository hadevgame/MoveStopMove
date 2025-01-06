using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWP : MonoBehaviour
{
    private WeaponPool pool;
    private PlayerAttack playerAttack;
    public static SpawnWP instance;

    private void Awake()
    {
        if (!instance) 
        {
            instance = this;
        }
    }
    private void Start()
    {
        pool = WeaponPool.instance;
        playerAttack = PlayerAttack.instance;
        Spawn();
    }

    public void Spawn() 
    {
        GameObject weapon = pool.GetWeaponFromPool();
        WeaponManager weaponManager = weapon.GetComponent<WeaponManager>();
        Rigidbody rb = weapon.GetComponent<Rigidbody>();
        playerAttack.weaponManager = weaponManager;
        Animator playerAnim = playerAttack.GetComponent<Animator>();
        playerAnim.SetBool("IsAttack",false);
        weapon.transform.position = this.transform.position;
        weapon.transform.SetParent(this.transform);
        weapon.transform.rotation = this.transform.rotation;
        rb.isKinematic = true;
    }
}
