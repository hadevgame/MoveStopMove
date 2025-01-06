using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public WeaponManager weaponManager;
    private SpawnWP spawn;
    public static PlayerAttack instance;
    public float cooldown;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

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
            cooldown = 2f;
            playerMovement.canAttack = false;
            Vector3 targetPos = other.transform.position;
            Vector3 direction = targetPos - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("IsAttack", true);
            weaponManager.MoveToTarget(direction);
            
        }
    }
    
}
