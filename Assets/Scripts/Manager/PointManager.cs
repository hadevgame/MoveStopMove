using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    public TextMeshProUGUI pointUIText;
    public GameObject player;
    public ParticleSystem auraParticle;
    private int currentPoint = 0;
    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    public void UpdatePoint() 
    {
        currentPoint += 1;
        pointUIText.text = currentPoint.ToString();
        Vector3 newScale = player.transform.localScale * (1 + 0.1f);
        player.transform.localScale = newScale;
        auraParticle.gameObject.SetActive(true);
        auraParticle.Play();
    }
     
    

}
