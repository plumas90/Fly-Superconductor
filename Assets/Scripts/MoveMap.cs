using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float SetOffpositionX = -41.6f;
    public float speed = 0.5f;
    private void OnEnable()
    {
        transform.localPosition = new Vector2(-11.65f, -2f);
    }

    void Update()
    {
        if (!GameManager.Instance.IsDead)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);

            if (transform.localPosition.x <= SetOffpositionX)
            {
                gameObject.SetActive(false);

            }
        }
    }
}