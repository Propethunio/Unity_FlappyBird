using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    [SerializeField] float MoveSpeed;

    private void Update() {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        if(transform.position.x < -12) {
            Destroy(gameObject);
        }
    }
}