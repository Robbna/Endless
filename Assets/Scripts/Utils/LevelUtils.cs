using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelUtils : MonoBehaviour
{
    public static Scene getCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }

    public static void loadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
