using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudPoofPrefab;
    [SerializeField] private GameObject _gameover;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Robot robot = collision.collider.GetComponent<Robot>();
        bool death = collision.collider.GetComponent<Robot>() == robot;

        if (death)
        {
            Instantiate(_cloudPoofPrefab, transform.position, Quaternion.identity);
            Instantiate(_gameover, new Vector3(10, 7, 0), Quaternion.identity);
            Destroy(robot);
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
