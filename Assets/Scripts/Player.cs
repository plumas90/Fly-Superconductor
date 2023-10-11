using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpHeight = 6f;
    public GameObject attackPrefab;
    public GameObject attackPosition;
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsDead)
        {
            //if (Input.GetMouseButtonDown(0)) //���콺 �׽�Ʈ�� �Ʒ� ������ư���θ� ����Ϸ�
            //{
            //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpHeight, 0);
            //}
            transform.Rotate(0, 0, -1f);
            if (Input.GetKeyDown(KeyCode.Z)) //pc �׽�Ʈ�� ����
            {
                Instantiate(attackPrefab, attackPosition.transform.position, Quaternion.Euler(0, 0, 90));
            }
            if (Input.GetKeyDown(KeyCode.X)) //pc �׽�Ʈ�� ����
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpHeight, 0);
            }
        }
    }

    public void JumpBtn()
    {
        if (!GameManager.Instance.IsDead)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpHeight, 0);
        }
    }
    public void electricBtn()
    {
        if (!GameManager.Instance.IsDead)
        {
            Instantiate(attackPrefab, attackPosition.transform.position, Quaternion.Euler(0, 0, 90));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Target")
        {
            GameManager.Instance.IsDead = true;
            GameManager.Instance.End();
        }
    }
}
