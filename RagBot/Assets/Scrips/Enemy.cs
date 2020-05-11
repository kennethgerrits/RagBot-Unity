using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudPoofPrefab;

    //collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool death = collision.collider.GetComponent<Robot>() != null;

        if (death)
        {
            Instantiate(_cloudPoofPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //restartStage();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
