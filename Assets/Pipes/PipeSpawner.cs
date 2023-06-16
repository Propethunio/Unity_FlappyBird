using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    [SerializeField] private GameObject PipePrefab;
    [SerializeField] private float SpawnTimer;

    private float Timer;
    private float Offset = 3f;

    public void Update() {
        if(Timer <= 0) {
            Timer = SpawnTimer;
            Vector3 position = new Vector3(transform.position.x, transform.position.y + Random.Range(-Offset, Offset), transform.position.z);
            Instantiate(PipePrefab, position, transform.rotation);
        } else {
            Timer -= Time.deltaTime;
        }
    }
}