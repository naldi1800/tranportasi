using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour
{
    public TextMeshProUGUI textName;

    [Header("UI")]
    public GameObject saveUI;
    public GameObject pauseUI;
    public GameObject winUI;
    public GameObject loseUI;

    // Start is called before the first frame update
    void Start()
    {
        // saveScore();
    }

    // Update is called once per frame
    void Update() { }

    public void openScoreSave()
    {
        if (winUI)
            winUI.SetActive(false);

        if (loseUI)
            loseUI.SetActive(false);

        if (pauseUI)
            pauseUI.SetActive(false);

        if (saveUI)
            saveUI.SetActive(true);
    }

    public void closeScoreSave()
    {
        if (saveUI)
            saveUI.SetActive(false);
    }

    public void saveScore()
    {
        string levelString = SceneManager.GetActiveScene().name;
        levelString = levelString.Substring(6, 1);
        int level = int.Parse(levelString);
        HighScore h = new HighScore();
        GameController gm = gameObject.GetComponent<GameController>();
        // Debug.Log(level + "-" + textName.text + "-" + gm.timer);
        h.Save(level, textName.text, gm.timerCounterUI.text);
    }
}
