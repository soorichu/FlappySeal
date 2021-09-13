using System.Collections;
using UnityEngine;

public class SealController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float maxHeight;
    public float flapVelocity;
    public bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }
    }

    public void Flap()
    {
        if (isDead || rb.isKinematic)
        {
            return;
        }

        rb.velocity = new Vector2(0.0f, flapVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        isDead = true;
        animator.SetBool("flap", false);
    }


}
