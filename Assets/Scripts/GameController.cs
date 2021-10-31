using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int point;

    public int totalTime = 10;
    private bool isStart;
    private int time;
    public Text txtScore, txtTime, txtFinalScore, txtResult;
    public Button btnRestart, btnStart, btnExit1, btnExit2;
    private int tempTime;
    public GameObject panel, startPanel;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        btnRestart.onClick.AddListener(ReStart);
        btnStart.onClick.AddListener(StartGame);
        btnExit1.onClick.AddListener(ExitGame);
        btnExit2.onClick.AddListener(ExitGame);
        Time.timeScale = 0;
        isStart = false;
        startPanel.SetActive(true);
        panel.SetActive(false);
        cam = Camera.main;
        tempTime = (int)Time.time;
        point = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            GameProcess();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        panel.SetActive(false);
        isStart = true;
    }

    void GameProcess()
    {
        time = (int)Time.time - tempTime;
        int remainTime = totalTime - time;
        txtTime.text = remainTime.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if(hit.collider != null)
            {
                point += hit.transform.gameObject.GetComponent<Object>().GetPoint();
                txtScore.text = point.ToString();
                Destroy(hit.transform.gameObject);
            }
        }
        if(remainTime <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        int lastPoint = LoadPrefs();
        Time.timeScale = 0;
        panel.SetActive(true);
        txtFinalScore.text = point.ToString();
        if (point >= 10)
            txtResult.text = "<color=#FFF>Highest point: " + lastPoint + "</color>\nYour Win!";
        else
            txtResult.text = "<color=#FFF>Highest point: " + lastPoint + "</color>\nYour Lose!";

        SavePrefs();
    }

    void ExitGame()
    {
        Application.Quit();
    }

    public void SavePrefs()
    {
        if (point > LoadPrefs())
        {
            PlayerPrefs.SetInt("Point", point);
            PlayerPrefs.Save();
        }
    }

    public int LoadPrefs()
    {
       return PlayerPrefs.GetInt("Point", 0);
    }


    void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
