using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        ResetPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0);
            _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;

        _rigidbody2D.velocity = Vector2.zero;
    }

    public float ReturnVelocityY()
    {
        return _rigidbody2D.velocity.y;
    }
}
