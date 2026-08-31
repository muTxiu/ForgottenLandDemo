using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public static WinUI Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    // 显示胜利UI：胜利条件达成时调用 WinUI.Instance.ShowWinUI();
    // 注意：如果胜利面板物体在场景里初始为"不激活"状态，Awake不会执行，
    // Instance会为null，此时请从存活物体上直接引用并调用 SetActive(true)。
    public void ShowWinUI()
    {
        gameObject.SetActive(true);
    }

    // 重新开始（与DeadUI一致：加载游戏场景）
    public void RestGameButton()
    {
        SceneManager.LoadScene(1);
    }

    // 返回主菜单（与DeadUI一致：加载开始场景）
    public void BackMainButton()
    {
        SceneManager.LoadScene(0);
    }
}
