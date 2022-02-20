using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Scripts")] 
    public EnemyCarManager enemyCarManager;
    public PlayerController PlayerController;
    public UIManager uIManager;
    
    [Header("Lists")]
    public List<Transform> carlist = new List<Transform>();
    public List<NavMeshAgent> motorcadeList = new List<NavMeshAgent>();

    [Header("Booleans")]
    public bool isTurning;
    public bool isStart;
    public bool isDone;
    public bool isFail;
    


    public static GameManager Instance { get; set; }
    public CameraController cameraController;
    public Transform playerTransform;

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        Fail();
    }

    public void StartGame()
    {
        isStart = true;
        uIManager.startButton.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        uIManager.restartButton.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
        uIManager.nextLevelButton.SetActive(true);
    }

    public void Fail()
    {
        if (PlayerController.health == 0)
        {
            isFail = true;
            uIManager.restartButton.SetActive(true);
        }
    }
}