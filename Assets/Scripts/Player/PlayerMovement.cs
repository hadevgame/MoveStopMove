using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigibody;
    [SerializeField] private FixedJoystick joyStick;
    [SerializeField] private float moveSpeed;
    public Canvas looseCanvas;
    public Canvas playCanvas;
    public bool move;
    public bool canAttack = true;
    public bool isDead = false;
    private void Update()
    {
        if(isDead == false) 
        {
            rigibody.velocity = new Vector3(joyStick.Horizontal * moveSpeed, rigibody.velocity.y, joyStick.Vertical * moveSpeed);

            if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
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
        else 
        {
            rigibody.velocity = new Vector3(0, 0, 0);
            StartCoroutine(DeadDelayed());
        }
    }

    private IEnumerator DeadDelayed()
    {
        //Collider collider = this.GetComponent<Collider>();
        //Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        //rigidbody.useGravity = false;
        //collider.enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(3f);
        //Destroy(this.gameObject);
        looseCanvas.gameObject.SetActive(true);
        playCanvas.gameObject.SetActive(false);
    }

}
