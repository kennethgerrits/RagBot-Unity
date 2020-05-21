using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoverBot : MonoBehaviour
{
    private LevelController _levelController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool foundLover = collision.collider.GetComponent<Robot>() != null;

        if(foundLover)
        {
            _levelController.LoadNextLevel();
        }
    }

    // Init
    void Start()
    {
        _levelController = GameObject.FindObjectOfType<LevelController>() as LevelController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
