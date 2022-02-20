using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float dragSpeed;
    public float forwardSpeed;
    public bool isTurning;
    public int health;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;

    void Start()
    {
    }


    void Update()
    {
        if (!GameManager.Instance.isDone && !GameManager.Instance.isFail && GameManager.Instance.isStart)
        {
            Move();
        }
    }


    public void Move()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.fixedDeltaTime);
        Vector3 direction = Vector3.right * dynamicJoystick.Horizontal;

        transform.Translate(direction * dragSpeed * Time.deltaTime * 2);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Right"))
        {
            GameManager.Instance.isTurning = true;
            transform.DORotate(new Vector3(0, other.gameObject.transform.eulerAngles.y, 0), 0.4f);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.isDone = true;
            GameManager.Instance.uIManager.nextLevelButton.SetActive(true);
        }
    }
}