using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public float speed;

    public void SetPlayer(Transform _player) {
        player = _player;
    }

    void Update()
    {
        if (player != null) {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.x = Mathf.Lerp(this.transform.position.x, player.position.x, interpolation);
            position.z = Mathf.Lerp(this.transform.position.z, player.position.z, interpolation);

            this.transform.position = position;
        }    
    }
}
