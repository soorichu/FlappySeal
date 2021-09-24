using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play, 
        GameOver
    }

    State state;
    int score;

    public SealController seal;
    public GameObject blocks;
    public Text scoreLabel;
    public Text stateLabel;

    void Start()
    {
        Ready();
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.Play:
                if (seal.isDead)
                {
                    GameOver();
                }
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Fire1"))
                {
                    Reload();
                }
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
        seal.SetSteerActive(false);
        blocks.SetActive(false);

        scoreLabel.text = "Score : " + 0;
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready";
    }

    void GameStart()
    {
        state = State.Play;
        seal.SetSteerActive(true);
        blocks.SetActive(true);
        seal.Flap();

        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }

    void GameOver()
    {
        state = State.GameOver;
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach(ScrollObject so in scrollObjects)
        {
            so.enabled = false;
        }

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
    }

    void Reload()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void IncreaseScore()
    {
        score++;
        scoreLabel.text = "Score : " + score;
    }
}
