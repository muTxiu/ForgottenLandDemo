using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameCanvas : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(1); 
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
