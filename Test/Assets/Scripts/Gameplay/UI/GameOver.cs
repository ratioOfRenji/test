using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOverUi;
    void Update()
    {
        if(player == null)
        {
            StartCoroutine(waitBeforeStop());
            IEnumerator waitBeforeStop()
            {
                yield return new WaitForSeconds(1);
                 gameOverUi.SetActive(true);
            }

        }
    }
    public void restart()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
