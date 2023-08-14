using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreView : MonoBehaviour
{
    public TextMeshProUGUI tHigh;

    private HighScore h;

    // Start is called before the first frame update
    void Start()
    {
        h = new HighScore();
        tHigh.text = h.getAll();
    }

    // Update is called once per frame
    void Update() { }
}
