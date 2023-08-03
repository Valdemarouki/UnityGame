using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    public string sceneName; // the name of the scene to restart

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
}

