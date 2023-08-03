using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelAnimation : MonoBehaviour
{
    public Animator animator;

    private int restartLevelTrigger = Animator.StringToHash("RestartLevel");

    public void PlayRestartAnimation()
    {
        animator.SetTrigger(restartLevelTrigger);
        Invoke("RestartLevel", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
