using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    public GameObject tunnel;
    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject infoMenu;
    // Start is called before the first frame update
    void Start()
    {
        tunnel.SetActive(true);
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettingsMenu(){
        tunnel.SetActive(false);
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettingsMenu()
    {
        tunnel.SetActive(true);
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
