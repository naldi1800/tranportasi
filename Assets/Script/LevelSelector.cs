using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject scrollBar;
    public GameObject nextButton, prevButton;
    float scrollPos;
    float[] pos;
    int position = 0;

    public void next()
    {
        if (position < pos.Length - 1)
        {
            position += 1;
            scrollPos = pos[position];
            // AudioManager.Instance.playSFX("ButtonClick");
        }
    }
    public void prev()
    {
        if (position > 0)
        {
            position -= 1;
            scrollPos = pos[position];
            // AudioManager.Instance.playSFX("ButtonClick");
        }

    }
    void Update()
    {
        nextButton.SetActive(true);
        prevButton.SetActive(true);
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {

            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                    float pst = scrollBar.GetComponent<Scrollbar>().value;
                    position = i;
                }
            }
        }
        if (position < 1)
        {
            prevButton.SetActive(false);
        }
        if (position > pos.Length - 2)
        {
            nextButton.SetActive(false);
        }
    }
}
