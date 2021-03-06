﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private Robot _robot;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    [SerializeField] private float _jumpPower = 6f;
    [SerializeField] private float _moveSpeed = 5f;

    void Start()
    {
        _robot = GameObject.FindObjectOfType<Robot>() as Robot;
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

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

        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpPower;
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
}
