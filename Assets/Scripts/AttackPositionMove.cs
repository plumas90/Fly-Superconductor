using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPositionMove : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
       transform.localPosition = new Vector2 (0,target.transform.position.y);
    }
}
