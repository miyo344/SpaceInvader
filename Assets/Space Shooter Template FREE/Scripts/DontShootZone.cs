using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontShootZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyShot"))
        {
            Destroy(other.gameObject);
        }
    }
}
