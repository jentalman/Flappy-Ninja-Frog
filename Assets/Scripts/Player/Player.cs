using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{

    private int _score;
    
    private PlayerMover _mover;
    private Animator _animator;

    public UnityAction OnPlayerDie;
    public UnityAction<int> OnScoreChangedEvent;


    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Velocity", _mover.ReturnVelocityY());
    }

    public void ResetGame()
    {
        _score = 0;
        OnScoreChangedEvent?.Invoke(_score);
        _mover.ResetPlayer();
    }

    public void Die()
    {
        OnPlayerDie.Invoke();
    }

    public void IncreaseScore()
    {
        _score++;
        OnScoreChangedEvent?.Invoke(_score);
    }
}
