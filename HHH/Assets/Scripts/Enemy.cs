using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float followSpeed = 2f;
    
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;

    private void OnEnable() {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate() {
        Vector2 followVec = (playerRb.position - rb.position).normalized;
        rb.MovePosition(rb.position + followVec * 2f * Time.fixedDeltaTime);
        rb.rotation = Mathf.Atan2(followVec.y, followVec.x) * Mathf.Rad2Deg - 90f;
    }
}
