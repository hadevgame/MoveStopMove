using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LooseCanvas : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    private int time = 5;
    private void Start()
    {
        textTime.text = time.ToString();
        InvokeRepeating("SetTime",1f, 1f);
    }

    private void Update()
    {
        if(time < 0) 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void BackMainMenu() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    void SetTime() 
    {
        time -= 1;
        textTime.text = time.ToString();
    }



    
}
