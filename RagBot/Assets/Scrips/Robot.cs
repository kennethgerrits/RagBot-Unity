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
    [SerializeField] private int _jumpPower = 2;
    [SerializeField] private float _moveSpeed = 5f;


    // Init functions
    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
        _levelController = GameObject.FindObjectOfType<LevelController>() as LevelController;
        _initialPosition = transform.position;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _initialPosition);

        if (transform.position.y > 10 ||
            transform.position.y < -20 ||
            transform.position.x > 30 ||
            transform.position.x < -20)
        {
            _levelController.RestartLevel();
        }

        handleRobotMovement();
    }

    private void handleRobotMovement()
    {
        if (!_robotWasLaunched)
            return;

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _moveSpeed;

        Vector3 movementV = new Vector3(0f, Input.GetAxis("Vertical") * _jumpPower, 0f);
        transform.position += movementV * Time.deltaTime * _moveSpeed;

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

}
