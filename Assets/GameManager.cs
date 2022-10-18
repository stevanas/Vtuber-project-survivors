using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timerSeconds = 90;
    public TextMeshProUGUI timerText;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public TextMeshProUGUI bulletsMagazineText;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        Vector2 v = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, v, cursorMode);
    }
    void Update()
    {
        if (timerSeconds > 0)
        {
            timerSeconds -= Time.deltaTime;
        }
        else
        {
            timerSeconds = 0;
        }

        DisplayTime(timerSeconds);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //float milliseconds = timeToDisplay % 1 * 1000;

        //timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    public void UpdateWeaponUI(int curBullets, int magazineSize)
    {
        if (curBullets == -100)
        {
            Debug.Log("Reloaddd");
            bulletsMagazineText.color = Color.yellow;
            bulletsMagazineText.text = "Reloading...";
        }
        else
        {
            bulletsMagazineText.color = Color.white;
            bulletsMagazineText.text = curBullets.ToString() + "/" + magazineSize.ToString();
        }
    }
}
