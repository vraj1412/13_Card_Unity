using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartTime : MonoBehaviour
{
    public int startTime=3;
    public TextMeshProUGUI textMeshProUGUI;
    public GameStartTime gameStartTime; 
    public IEnumerator StartTime()
    {

        
     
        for (int i = startTime; i >= 0; i--)
        {

            if (i > 0)
            {
                textMeshProUGUI.text = i.ToString();

            }
            else
            {
                textMeshProUGUI.text = "Go!!";
                
                
                break;
            }
            yield return new WaitForSeconds(1);

        }

        yield return new WaitForSeconds(1);
        textMeshProUGUI.gameObject.SetActive(false);
        StopCoroutine(StartTime());

    }
}
