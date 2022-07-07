using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class sceneManager : MonoBehaviour
{
    [Header("Put DeathRoom Name")]
    public string DeathRoom1, DeathRoom2, DeathRoom3;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator ChoseRandomLevel()
    {
        yield return new WaitForSeconds(0.1f);
        //Make a Trigger and Call It Fade
        Anim.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        int RandomNumber = Random.Range(1, 4);
        if(RandomNumber == 1)
        SceneManager.LoadScene(DeathRoom1);
        
        if(RandomNumber == 2)
        SceneManager.LoadScene(DeathRoom2);

        if(RandomNumber == 3)
        SceneManager.LoadScene(DeathRoom3);
    }
    IEnumerator NextLevelT()
    {
        //Make a Trigger and Call It Fade
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
