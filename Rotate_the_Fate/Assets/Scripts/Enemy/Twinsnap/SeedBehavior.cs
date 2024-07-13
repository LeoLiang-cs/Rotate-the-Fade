using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehavior : MonoBehaviour
{
    public float seedSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * (seedSpeed * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Cupid").GetComponent<CupidHealth>().TakeSeedDamage(transform);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }

    }
}
