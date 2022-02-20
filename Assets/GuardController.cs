using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour
{
    public NavMeshAgent guardAI;
    public int followDistance;
    public int guardSpeed;


    void Start()
    {
    }


    void Update()
    {
        if (!GameManager.Instance.isDone && !GameManager.Instance.isFail && GameManager.Instance.isStart)
        {
            GuardFollow();
        }
    }

    public void GuardFollow()
    {
        if (GameManager.Instance.isTurning)
        {
            transform.Translate(Vector3.forward *
                                guardSpeed *
                                Time.fixedDeltaTime);
        }
        else
        {
            if (guardAI != null)
            {
                guardAI.SetDestination(GameManager.Instance.playerTransform.position +
                                       GameManager.Instance.playerTransform.forward * followDistance);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Right"))
        {
            for (int i = 0; i < GameManager.Instance.motorcadeList.Count; i++)
            {
                Debug.Log("durdu");
                GameManager.Instance.motorcadeList[i].isStopped = true;
                GameManager.Instance.isTurning = true;
                transform.DORotate(new Vector3(0, 90, 0), 0.4f);
            }

            this.transform.DORotate(new Vector3(0, other.gameObject.transform.eulerAngles.y, 0), 0.4f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Right"))
        {
            for (int i = 0; i < GameManager.Instance.motorcadeList.Count; i++)
            {
                Debug.Log("durdu");
                GameManager.Instance.isTurning = false;
                GameManager.Instance.motorcadeList[i].isStopped = false;
            }
        }
    }
}