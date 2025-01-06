using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigibody;
    [SerializeField] private FixedJoystick joyStick;
    [SerializeField] private float moveSpeed;
    public bool move;
    public bool canAttack = true;
    private void Update()
    {
        rigibody.velocity = new Vector3(joyStick.Horizontal * moveSpeed, rigibody.velocity.y, joyStick.Vertical * moveSpeed);

        if (joyStick.Horizontal != 0  || joyStick.Vertical != 0 ) 
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            transform.rotation = Quaternion.LookRotation(rigibody.velocity);
            move = true;
        }
        else
        {
            animator.SetBool("IsIdle", true);
            move = false;
            canAttack = true;
        }
        
    }
    
}
