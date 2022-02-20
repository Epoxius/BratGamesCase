using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;

public class EnemyCarController : MonoBehaviour
{
    public int speed;
    public Rigidbody enemyRb;
    public void Update()
    {
        EnemyCarMove();
    }

    public void EnemyCarMove()
    {
        enemyRb.velocity = transform.forward * speed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right"))
        {
            transform.DORotate(new Vector3(0,-other.gameObject.transform.eulerAngles.y, 0), 0.4f);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameManager.Instance.PlayerController.health--;

        }

        if (other.gameObject.CompareTag("Guard"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
