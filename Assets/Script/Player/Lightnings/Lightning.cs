using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    //spawn e movimento dei fulmini
    public void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);
    }

    protected virtual void Move(float speed) {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }
}
