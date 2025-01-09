using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public GameObject objectParent;
    private Vector3 startScale;
    
    void Start()
    {
        startScale = objectParent.transform.localScale;
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectParent.transform.localScale != startScale) 
        {
            startScale = objectParent.transform.localScale;
            this.gameObject.SetActive(true);
            this.gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
