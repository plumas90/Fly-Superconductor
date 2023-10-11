using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float pipeSpeed = 4f;
    public float persent = 100f;
    public GameObject Barricade;
    private void Start()
    {
        int a= Random.Range(0,100);
        if (a <= persent) 
        {
            Barricade.SetActive(true);
        }
    }

    void Update()
    {
        if (!GameManager.Instance.IsDead)
        {
            transform.Translate(-pipeSpeed * Time.deltaTime, 0, 0);

            if (transform.position.x <= -4.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
