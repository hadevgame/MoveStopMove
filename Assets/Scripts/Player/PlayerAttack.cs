using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public WeaponManager weaponManager;
    private SpawnWP spawn;
    public float cooldown;
    [SerializeField] private Animator animator;
    Vector3 direction;
    
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }
    private void Start()
    {
       spawn = SpawnWP.instance;
    }
    public void Attack(Collider other)
    {
        if (playerMovement.move == false && playerMovement.canAttack == true)
        {
            cooldown = 1f;
            playerMovement.canAttack = false;
            Vector3 targetPos = other.transform.position;
            direction = targetPos - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("IsAttack", true);
            //weaponManager.MoveToTarget(direction);
        }
    }
    public void MoveWeaponToTarget()
    {
        Debug.Log("attack");
        weaponManager.MoveToTarget(direction);
    }

}
