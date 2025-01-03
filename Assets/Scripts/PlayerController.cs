using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigibody;
    [SerializeField] private FixedJoystick joyStick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool move;
   
    private void Update()
    {
        rigibody.velocity = new Vector3(joyStick.Horizontal * moveSpeed, rigibody.velocity.y, joyStick.Vertical * moveSpeed);

        if (joyStick.Horizontal != 0  || joyStick.Vertical != 0 ) 
        {
           
            animator.SetBool("IsIdle", false);
            transform.rotation = Quaternion.LookRotation(rigibody.velocity);
            move = true;
        }
        else
        {
            animator.SetBool("IsIdle", true);
            move = false;
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy")  ) 
        {
            Attack(other);
            
        }
    }

     void Attack(Collider other) 
    {
        if(move == false) 
        {
            Vector3 targetPos = other.transform.position;
            Vector3 direction = targetPos - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("IsAttack", true);
        }
    }

    

   
}
