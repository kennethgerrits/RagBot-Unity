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

    [SerializeField] private float _launchPower = 250;

    // Init functions
    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
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
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    // Mouse interaction
    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
        _lineRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        _rigidBody2D.AddForce(directionToInitialPosition * _launchPower);
        _rigidBody2D.gravityScale = 1;
        _robotWasLaunched = true;

        _lineRenderer.enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

}
