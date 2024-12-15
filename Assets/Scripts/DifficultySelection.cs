using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelection : MonoBehaviour
{
    public void SelectEasy()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void SelectNormal()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void SelectHard() 
    { 
        SceneManager.LoadSceneAsync(4); 
    }
    public void BackToMainMenu()
    {

        SceneManager.LoadSceneAsync(0);
    }
}
