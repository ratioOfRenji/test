using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BonusMover : MonoBehaviour
{
    private void Move()
    {
        transform.Translate(10 * Time.deltaTime * Vector3.up);
    }
    private void Update()
    {
        Move();
    }
}
