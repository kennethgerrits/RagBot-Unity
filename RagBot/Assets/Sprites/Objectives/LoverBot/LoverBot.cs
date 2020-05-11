using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverBot : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool foundLover = collision.collider.GetComponent<Robot>() != null;

        if(foundLover)
        {
            Destroy(gameObject);
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
