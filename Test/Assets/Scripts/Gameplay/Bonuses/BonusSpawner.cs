using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Bonus;
    

    public void InitBonus(Transform transform)
    {
        int i = Random.Range(1,10);
        //int BonusType = Random.Range(0, 2);
        if(i == 9)
        {
            Instantiate(Bonus[0], transform.position, transform.rotation);
        }
    }
}
