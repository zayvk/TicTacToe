using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text[] xOList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    private string side;
    private int moves;

    // Use this for initialization
    void Start () {
        SetGameControllerReferenceForButtons();
        side = "X";
        gameOverPanel.SetActive(false);
        moves = 0;
        restartButton.SetActive(false);
    }

    void SetGameControllerReferenceForButtons()
    {
        for (int i = 0; i < xOList.Length; i++)
            xOList[i].GetComponentInParent<Space>().SetControllerReference(this);
    }

    public string GetSide()
    {
        return side;
    }

    void ChangeSide()
    {
        if (side == "X")
            side = "O";
        else
            side = "X";
    }

    public void EndTurn()
    {
        moves++;
        if (xOList[0].text == side && xOList[1].text == side && xOList[2].text == side)
            GameOver();
        else if (xOList[3].text == side && xOList[4].text == side && xOList[5].text == side)
            GameOver();
        else if (xOList[6].text == side && xOList[7].text == side && xOList[8].text == side)
            GameOver();
        else if (xOList[0].text == side && xOList[3].text == side && xOList[6].text == side)
            GameOver();
        else if (xOList[1].text == side && xOList[4].text == side && xOList[7].text == side)
            GameOver();
        else if (xOList[2].text == side && xOList[5].text == side && xOList[8].text == side)
            GameOver();
        else if (xOList[0].text == side && xOList[4].text == side && xOList[8].text == side)
            GameOver();
        else if (xOList[2].text == side && xOList[4].text == side && xOList[6].text == side)
            GameOver();
        if (moves >= 9)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Tie!";
            restartButton.SetActive(true);
        }
        ChangeSide();
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = side + " wins!";
        restartButton.SetActive(true);
        for (int i = 0; i < xOList.Length; i++)
            SetInteractable(false);
    }

    void SetInteractable(bool setting)
    {
        for (int i = 0; i < xOList.Length; i++)
            xOList[i].GetComponentInParent<Button>().interactable = setting;
    }

    public void Restart()
    {
        side = "X";
        moves = 0;
        gameOverPanel.SetActive(false);
        SetInteractable(true);
        restartButton.SetActive(false);
        for (int i = 0; i < xOList.Length; i++)
            xOList[i].text = "";
    }

    public void Quit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
