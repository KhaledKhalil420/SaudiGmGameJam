using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    [Header("Put DeathRoom Name")]
    public string DeathRoom1, DeathRoom2, DeathRoom3;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadRandomDeathRoom()
    {
        int RandomNumber = Random.Range(1, 4);
        if(RandomNumber == 1)
        SceneManager.LoadScene(DeathRoom1);
        
        if(RandomNumber == 2)
        SceneManager.LoadScene(DeathRoom2);

        if(RandomNumber == 3)
        SceneManager.LoadScene(DeathRoom3);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
