using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private LoopType loopType;
    [SerializeField] private Collider playerCollider;
    
    [Header("Variables for Loop Type - Game Win")]
    [Tooltip("Button that player has to press upon reaching the goal")]
    [SerializeField] private KeyCode buttonToAdvance;
    [SerializeField] private int nextLevel;
    
    private enum LoopType
    {
        GameOver,
        GameWin
    }
    private bool _isPlayerTouching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlayerTouching) return;
        ExecuteGameLoop(loopType);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == FindObjectOfType<PlayerMovement>().GetComponent<Collider>())
        {
            _isPlayerTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == FindObjectOfType<PlayerMovement>().GetComponent<Collider>())
        {
            _isPlayerTouching = false;
        }
    }

    private void ExecuteGameLoop(LoopType enumType)
    {
        switch (enumType)
        {
            case LoopType.GameWin:
            {
                if (Input.GetKeyDown(buttonToAdvance)) SceneManager.LoadScene(nextLevel);
                break;
            }
            case LoopType.GameOver:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
}
