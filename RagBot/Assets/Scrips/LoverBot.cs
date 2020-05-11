using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoverBot : MonoBehaviour
{
    private static int _nextLevelIndex = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool foundLover = collision.collider.GetComponent<Robot>() != null;

        if(foundLover)
        {
            _nextLevelIndex++;
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }


    // Init functions
    private void Awake()
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
