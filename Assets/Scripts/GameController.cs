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

    private void Start()
    {
        coin = 0;
    }
}
