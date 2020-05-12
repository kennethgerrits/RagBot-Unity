using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robot : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;
    private LineRenderer _lineRenderer;
    private bool _robotWasLaunched;
    private LevelController _levelController;

    [SerializeField] private float _launchPower = 250;


    // Init
    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
        _levelController = GameObject.FindObjectOfType<LevelController>() as LevelController;
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _initialPosition);

        // Resets level once player gets shot into Oblivion.
        if (transform.position.y > 15 ||
            transform.position.y < -20 ||
            transform.position.x > 40 ||
            transform.position.x < -20)
        {
            _levelController.RestartLevel();
        }

    }

    // Mouse interaction
    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;

        if (_robotWasLaunched)
            return;
        _lineRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
        _lineRenderer.enabled = false;

        if (_robotWasLaunched)
            return;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        _rigidBody2D.AddForce(directionToInitialPosition * _launchPower);
        _rigidBody2D.gravityScale = 1;
        _robotWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        if (_robotWasLaunched)
            return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

    public bool GetRobotLaunchStatus()
    {
        return _robotWasLaunched;
    }

}
