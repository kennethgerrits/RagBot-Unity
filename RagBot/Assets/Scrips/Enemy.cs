using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Robot _robot;
    private Vector3 _alignmentTopCenter;

    [SerializeField] private GameObject _cloudPoofPrefab;
    [SerializeField] private GameObject _gameoverPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Robot robot = collision.collider.GetComponent<Robot>();
        bool death = collision.collider.GetComponent<Robot>() == robot;

        if (death)
        {
            Instantiate(_cloudPoofPrefab, _robot.transform.position, Quaternion.identity);
            Instantiate(_gameoverPrefab, _alignmentTopCenter, Quaternion.identity);
            robot.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _alignmentTopCenter = new Vector3(12, 7, -4);
        _robot = GameObject.FindObjectOfType<Robot>() as Robot;
    }
}
