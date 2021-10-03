using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image[] hearts;

    [SerializeField]
    private Sprite full;

    [SerializeField]
    private Sprite empty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void minusHeart()
    {
        for (int i = hearts.Length-1; i >= 0; i--)
        {
            if(hearts[i].sprite == full)
            {
             hearts[i].sprite = empty;
               break;
            }
           
        }
    }
}
