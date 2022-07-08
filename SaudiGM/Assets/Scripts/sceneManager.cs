using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class sceneManager : MonoBehaviour
{
    [Header("Put DeathRoom Name")]
    public string DeathRoom;

    public Animator Anim;

    public void LoadNextLevel()
    {
        StartCoroutine(NextLevelT());
    }

    public void LoadRandomDeathRoom()
    {
        StartCoroutine(ChoseRandomLevel());
    }

    void Update()
    {
        //Remove After Realese
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator ChoseRandomLevel()
    {
        yield return new WaitForSeconds(0.1f);
        //Make a Trigger and Call It Fade
        Anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        int RandomNumber = Random.Range(1, 4);
        SceneManager.LoadScene(DeathRoom);
    }
    IEnumerator NextLevelT()
    {
        //Make a Trigger and Call It Fade
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
