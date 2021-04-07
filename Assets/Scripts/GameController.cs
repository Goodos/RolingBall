using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{
    public UnityAction endGameEvent;
    public float score;
    public int coin;
    public bool canMove = false;

    private void Start()
    {
        canMove = false;
        coin = 0;
    }
}
