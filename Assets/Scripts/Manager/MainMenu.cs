using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playCamera;
    [SerializeField] Canvas playCanvas;
    [SerializeField] Canvas playercanvas;
    [SerializeField] Canvas shopWeaponCanvas;
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] GameObject playerAttackRange;
    [SerializeField] GameObject player;
    [SerializeField] Image vibOn;
    [SerializeField] Image vibOff;
    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;
    private bool vibIsOn = true;
    private bool soundIsOn = true;
    public void PlayGame() 
    {
        playCamera.gameObject.SetActive(true);
        gameObject.SetActive(false);
        playCanvas.gameObject.SetActive(true);
        playercanvas.gameObject.SetActive(true);
        playerAttackRange.gameObject.SetActive(true);
    }

    public void SwitchVib() 
    {
        if(vibIsOn == true) 
        {
            vibOn.gameObject.SetActive(false);
            vibOff.gameObject.SetActive(true);
            vibIsOn = false;
        }
        else 
        {
            vibOn.gameObject.SetActive(true);
            vibOff.gameObject.SetActive(false);
            vibIsOn = true;
        }
    }

    public void OnOffSound() 
    {
        if (soundIsOn == true)
        {
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
            soundIsOn = false;
        }
        else
        {
            soundOn.gameObject.SetActive(true);
            soundOff.gameObject.SetActive(false);
            soundIsOn = true;
        }
    }

    public void OpenWeaponShop() 
    {
        mainMenuCanvas.gameObject.SetActive(false);
        player.SetActive(false);
        shopWeaponCanvas.gameObject.SetActive(true);
    }
}
