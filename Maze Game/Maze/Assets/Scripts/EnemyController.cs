using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
public float min = 0f;
public float max = 0f;

    void Start()
    {
        min = transform.position.x;
        max = transform.position.x+1;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, max-min)+min, transform.position.y, transform.position.z);
        transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
    }
}
