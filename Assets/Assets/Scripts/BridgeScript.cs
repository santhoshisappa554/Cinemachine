using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public float bridgedestroytime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine("BridgeDestroy");
        }
        
    }
    IEnumerator BridgeDestroy()
    {
        yield return new WaitForSeconds(bridgedestroytime);
        Destroy(this.gameObject);
    }
}
