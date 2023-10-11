using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float shootSpeed= 2f;
    public AudioClip shoot;
    public AudioSource shootSound;

    private void Start()
    {
        shootSound.PlayOneShot(shoot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{collision.tag}");
        if (collision.tag == "Target")
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (!GameManager.Instance.IsDead)
        {
            transform.Translate(0, -shootSpeed * Time.deltaTime, 0);

            if (transform.position.x >= 4.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
