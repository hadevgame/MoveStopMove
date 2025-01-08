using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWPEnemy : MonoBehaviour
{
    public GameObject enemyWeapon;
    public EnemyAttack enemyAttack;
    void Start()
    {
        
        Spawn();
    }

    public void Spawn() 
    {
        GameObject objectWP = Instantiate(enemyWeapon);
        Collider collider = objectWP.GetComponent<Collider>();
        collider.enabled = false;
        objectWP.transform.position = this.transform.position;
        objectWP.transform.SetParent(this.transform);
        objectWP.transform.rotation = this.transform.rotation;
        WeaponManager weaponManager = objectWP.GetComponent<WeaponManager>();
        Rigidbody rb = objectWP.GetComponent<Rigidbody>();
        enemyAttack.weaponManager = weaponManager;
        Animator enemyAnim = enemyAttack.GetComponent<Animator>();
        enemyAnim.SetBool("IsAttack", false);
        rb.isKinematic = true;
    }
}
