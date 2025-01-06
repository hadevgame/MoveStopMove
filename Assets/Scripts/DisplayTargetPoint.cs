using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTargetPoint : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public static DisplayTargetPoint instance;
    private GameObject objecOnTarget;
    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (objecOnTarget == null) 
        {
            target.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            objecOnTarget = other.gameObject;
            target.SetActive(true);
            target.transform.position = other.transform.position;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        target.SetActive(false);
    }
}
