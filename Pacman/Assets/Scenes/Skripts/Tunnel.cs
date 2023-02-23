using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter2D(Collider2D other) {
        // Propojení tunelů
        Vector3 pos = other.transform.position;
        pos = this.connection.position;
        other.transform.position = pos;
    }
}
