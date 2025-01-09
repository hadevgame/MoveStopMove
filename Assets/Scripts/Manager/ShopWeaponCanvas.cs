using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopWeaponCanvas : MonoBehaviour
{

    public void ExitShop() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
