using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class NewCanvas : MonoBehaviour
{
    private TextMeshProUGUI winTextMesh, targetTextMesh;
    public GameObject winText, targetText, pauseMenu, fade;
    protected bool gamePaused;
    public Color startColor, endColor;

  
    private void Awake()
    {
        Resume();

        fade.GetComponent<Image>().color = endColor;
        fade.GetComponent<Image>().DOColor(startColor, 1f);


    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ReturnToWorld()
    {
        Time.timeScale = 1f;
        gamePaused = false;

        StartCoroutine(timing());

        IEnumerator timing()
        {
            fade.GetComponent<Image>().DOColor(endColor, 0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(1);
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        gamePaused = false;

        StartCoroutine(timing());

        IEnumerator timing()
        {
            fade.GetComponent<Image>().DOColor(endColor, 0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(0);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

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

    public void VariableType()
    {
        targetTextMesh.text = $"Sort the boxes to their variable type";
    }

    public void InvalidInput(float targetNum)
    {
        targetTextMesh.text = $"Target: {targetNum} \n Output: Invalid Statement";
    }


    public void IfStatmentStart(bool targetIsTrue)
    {
        targetTextMesh.text = $"Form An Output That is: {targetIsTrue} \n Your Output: ";
    }

    public void IfStatmentOutput(bool targetIsTrue, bool outputIsTrue)
    {
        targetTextMesh.text = $"Form An Output That is: {targetIsTrue} \n Your Output: {outputIsTrue}";
    }
}
