using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int worldLevelID;

    public GameObject title, playButton, exitButton, fade;

    public Color startColor,endColor;

    private void Awake()
    {
        title.SetActive(false);
        playButton.SetActive(false);
        exitButton.SetActive(false);
        fade.GetComponent<Image>().color = startColor;



        StartCoroutine(timing()); 

        IEnumerator timing()
        {
            yield return new WaitForSeconds(0.3f);

            title.SetActive(true);

            title.GetComponent<RectTransform>().transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            title.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), .3f);
            yield return new WaitForSeconds(0.3f);
            playButton.SetActive(true);

            playButton.GetComponent<RectTransform>().transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            playButton.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.3f);
            yield return new WaitForSeconds(0.3f);
            exitButton.SetActive(true);

            exitButton.GetComponent<RectTransform>().transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            exitButton.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.3f);
        }

    }

    public void PlayGame()
    {
        StartCoroutine(timing());

        IEnumerator timing()
        {
            fade.GetComponent<Image>().DOColor(endColor, 0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(worldLevelID);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
