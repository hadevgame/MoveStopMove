using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTargetPoint : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        target.SetActive(true);
        target.transform.position = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        target.SetActive(false);
    }
}
