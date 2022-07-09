using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] Slider slider;
    public static bool IsPaused = false;
    public float Volume;
    [SerializeField] AudioMixer Output;

    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && IsPaused)
        {
            //Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            IsPaused = false;
            PauseMenuUI.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape)  && !IsPaused)
        {
            //Time.timeScale = 0;
            IsPaused = true;
            Cursor.visible = true;
            PauseMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SetVolume(float vol){
        Volume = slider.value;
        Output.SetFloat("Volume", Volume);
    }

}
