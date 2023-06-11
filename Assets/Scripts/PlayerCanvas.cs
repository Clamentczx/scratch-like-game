using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCanvas : MonoBehaviour
{
    private TextMeshProUGUI winTextMesh, targetTextMesh;
    public GameObject winText, targetText;

    public void CanvasInit()
    {
        winTextMesh = winText.GetComponent<TextMeshProUGUI>();
        winText.SetActive(false);
        targetTextMesh = targetText.GetComponent<TextMeshProUGUI>();
    }

    public void PlayerWin()
    {
        winText.SetActive(true);
        winTextMesh.text = "You Win";
    }

    public void SetNumber(float targetNum, float playerNum)
    {
        targetTextMesh.text = $"Target: {targetNum} \n Output: {playerNum}";

    }

}
