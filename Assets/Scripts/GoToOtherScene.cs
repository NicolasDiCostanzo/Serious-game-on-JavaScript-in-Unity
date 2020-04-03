using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToOtherScene : MonoBehaviour
{
    [SerializeField] string nameSceneToLoad;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(nameSceneToLoad);

    }
}
