using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timeconter : MonoBehaviour
{
    [SerializeField] private float timeup = 20;
    [SerializeField] private Text gameOverText = null;

    private Text timerText = null;

    // Use this for initialization
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        timerText = GetComponent<Text>();
        timerText.text = ((int)timeup).ToString();

        Invoke("GameOver", timeup);
    }

    // Update is called once per frame
    void Update()
    {
        timeup -= Time.deltaTime;
        if (0 >= timeup) timeup = 0;
        timerText.text = ((int)timeup).ToString();

    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
