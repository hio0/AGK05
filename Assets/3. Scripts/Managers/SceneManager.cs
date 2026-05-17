using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        int scene = PlayerPrefs.GetInt("Stage", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
