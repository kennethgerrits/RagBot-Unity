using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private Robot _robot;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _jumpPower = 6f;
    [SerializeField] private float _moveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        _robot = GameObject.FindObjectOfType<Robot>() as Robot;
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleRobotMovement();
    }

    private void handleRobotMovement()
    {
        if (!_robot.GetRobotLaunchStatus())
            return;

        Vector3 movementH = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movementH * Time.deltaTime * _moveSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rigidbody2D.velocity = Vector2.up * _jumpPower;

        }
    }
}
