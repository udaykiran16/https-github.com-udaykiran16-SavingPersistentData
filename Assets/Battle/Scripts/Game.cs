
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    public int shots;
    public int hits;

    [SerializeField]
    private Text hitsText;
    [SerializeField]
    private Text shotsText;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject[] targets;
    private bool isPaused = false;

    private void Awake()
    {
        Pause();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        hits = PlayerPrefs.GetInt("hits", 0);
        shots = PlayerPrefs.GetInt("shots", 0);
        shotsText.text = shots.ToString();
        hitsText.text = hits.ToString();
    }

    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }



    public void AddShot()
    {

        shots = PlayerPrefs.GetInt("shots", 0);
        shots += 1;
        PlayerPrefs.SetInt("shots", shots);
        shotsText.text = shots.ToString();
    }

    public void AddHit()
    {
        hits = PlayerPrefs.GetInt("hits", 0);
        hits += 1;
        PlayerPrefs.SetInt("hits", hits);
        hitsText.text = hits.ToString();
    }

    public void DeleteScores()
    {
        PlayerPrefs.DeleteAll();
    }



}
