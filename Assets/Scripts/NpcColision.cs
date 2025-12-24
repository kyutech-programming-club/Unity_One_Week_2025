using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcColision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "pack")
        {
            Rigidbody2D packRd2D = other.gameObject.GetComponent<Rigidbody2D>();
            packRd2D.AddForce((other.transform.position - transform.position).normalized * 5, ForceMode2D.Impulse);

        }
    }
}
