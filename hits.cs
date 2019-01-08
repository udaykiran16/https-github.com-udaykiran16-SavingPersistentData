using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace
{
    class hits
    {
        private List<GameObject> bullets = new List<GameObject>();
        private int shots;
        private int hits;

        [SerializeField]
        private Text hitsText;
        [SerializeField]
        private Text shotsText;
        [SerializeField]
        private GameObject menu;
        [SerializeField]
        private GameObject[] targets;
        private bool isPaused = false;

        public List<GameObject> Bullets
        {
            get
            {
                return bullets;
            }

            set
            {
                bullets = value;
            }
        }

        public int Shots
        {
            get
            {
                return shots;
            }

            set
            {
                shots = value;
            }
        }

        public int Hits
        {
            get
            {
                return hits;
            }

            set
            {
                hits = value;
            }
        }

        void start()
        {
            Cursor.lockState = UnityEngine.CursorLockMode.Confined;
            Hits = PlayerPrefs.GetInt("hits", 0);
            Shots = PlayerPrefs.GetInt("shots", 0);
            shotsText.text = Shots.ToString();
            hitsText.text = Hits.ToString();
        }
    }
}
