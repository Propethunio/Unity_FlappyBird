using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private KeyCode JumpKey;
    [SerializeField] private float FlapStrenght;

    private Rigidbody2D rb;
    private Vector2 Direction = Vector2.up;
    private bool isAlive = true;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetKeyDown(JumpKey)) {
            switch(GameManager.Instance.State) {
                case GameManager.GameState.Start:
                    GameManager.Instance.StartGame();
                    break;
                case GameManager.GameState.Playing:
                    rb.velocity = Direction * FlapStrenght;
                    break;
                case GameManager.GameState.GameOver:
                    break;
            }
        }
        if(transform.position.y > 5 || transform.position.y < -5) {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(isAlive) {
            GameManager.Instance.AddPoint();
        }
    }

    private void GameOver() {
        isAlive = false;
        GameManager.Instance.GameOver();
    }
}