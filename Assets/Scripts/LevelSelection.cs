using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void SelectLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
    public void BackToDifficultySelection()
    {

        SceneManager.LoadSceneAsync(1);
    }
}
