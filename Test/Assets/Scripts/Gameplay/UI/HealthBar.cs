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

   //убирает одно сердце на UI, начиная справа
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
    // добавляет одно сердце на UI, начиная слева
    public void plusHeart()
    {
        for (int i =  0; i <hearts.Length; i++)
        {
            if (hearts[i].sprite == empty)
            {
                hearts[i].sprite = full;
                break;
            }

        }
    }
}
