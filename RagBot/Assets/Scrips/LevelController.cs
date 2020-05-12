using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 0;
    private List<string> _levelNames;

    private void Start()
    {
        _levelNames = new List<string>
        {
            "level1",
            "level2",
            "level3"
        };
    }

    public void LoadNextLevel()
    {
        _nextLevelIndex++;
        string nextLevelName = _levelNames[_nextLevelIndex];
        SceneManager.LoadScene(nextLevelName);
    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
