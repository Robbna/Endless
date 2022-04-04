using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("Level_1");
    }
}
