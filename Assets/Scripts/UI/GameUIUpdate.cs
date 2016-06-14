using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIUpdate : MonoBehaviour {

    // Use this for initialization
    public Text puntajeText;
    public Text timerText;
    public Text bombText;
    public GrazeBar grazeBar;

    public void UpdateScoreText(int cant)
    {
        puntajeText.text = "Puntaje: " + cant.ToString();
    }

    public void UpdateTimerText(float seconds)
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(seconds);
        timerText.text = t.Minutes.ToString().PadLeft(2, '0') + ":" + t.Seconds.ToString().PadLeft(2, '0');
    }

    public void SetBombCant(int cant)
    {
        bombText.text = "Bombs: " + cant;
    }

    public void UpdateGrazeBar(float scale)
    {
      grazeBar.setBarScale(scale);
    }
}
