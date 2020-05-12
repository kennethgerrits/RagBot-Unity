using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 2f;
    [SerializeField] private float _moveSpeed = 5f;
    private Robot _robot;


    // Start is called before the first frame update
    void Start()
    {
        _robot = GameObject.FindObjectOfType<Robot>() as Robot;
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

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _moveSpeed;

        Vector3 movementV = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.position += movementV * Time.deltaTime * _moveSpeed;

    }
}
