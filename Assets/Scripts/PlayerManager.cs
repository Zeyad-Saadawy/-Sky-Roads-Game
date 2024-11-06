using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    GameObject player;
    bool onetimemusic = true;
    void Start()
    {
        gameOver = false;
        onetimemusic= true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            player.SetActive(false);
            if (onetimemusic && !Player.muted)
            {
                print("game over music is playing");
                FindObjectOfType<AudioManager>().Stop("gameplay");
                FindObjectOfType<AudioManager>().Play("screens");
                onetimemusic = false;
            }
        }
    }
}
