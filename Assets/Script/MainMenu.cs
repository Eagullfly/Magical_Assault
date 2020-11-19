using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level01";
    public string menuSceneName = "MainMenu";

    void Start()
    {
        if (Time.timeScale == 0)
        {
            //Debug.Log("Something's wrong");
            Time.timeScale = 1f;

        }
    }

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Debug.Log("Exiting..");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
