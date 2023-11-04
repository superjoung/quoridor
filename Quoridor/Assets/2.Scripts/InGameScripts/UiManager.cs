using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static GameObject[] panelBox = new GameObject[2]; // 0 - Turn, 1 - history
    public static int turnAnchor = 0; // GameManager에 있는 Turn과 비교하는 비교군

    private void Start()
    {
        panelBox[0] = GameObject.Find("TurnPanel");
        panelBox[1] = GameObject.Find("HistoryPanel");
    }

    public void HistoryPanelPop()
    {
        if (!panelBox[1].transform.GetChild(0).gameObject.activeSelf) // History Panel Active == false
        {
            panelBox[1].transform.GetChild(0).gameObject.SetActive(true);
        }
        else // History Panel Active == true
        {
            panelBox[1].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public static IEnumerator EnemyPanelPop() // TurnPanel child → 0 = player, 1 = enemy
    {
        if (turnAnchor != GameManager.Turn)
        {
            turnAnchor = GameManager.Turn;
            panelBox[0].transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            panelBox[0].transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public static IEnumerator PlayerPanelPop() // TurnPanel child → 0 = player, 1 = enemy
    {
        if (turnAnchor != GameManager.Turn)
        {
            turnAnchor = GameManager.Turn;
            panelBox[0].transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            panelBox[0].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
