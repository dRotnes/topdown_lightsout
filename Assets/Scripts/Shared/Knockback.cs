using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce;
    public float knockbackTime;

    public void Knock(GameObject target)
    {
        Vector2 difference = target.transform.position - transform.position;
        difference = difference.normalized * knockbackForce;
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockCoroutine(rb));

    }

    private IEnumerator KnockCoroutine(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
    }
}
