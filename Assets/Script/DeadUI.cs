using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadUI : MonoBehaviour
{
    public void RestGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BackMainButton()
    {
        SceneManager.LoadScene(0);
    }
}
