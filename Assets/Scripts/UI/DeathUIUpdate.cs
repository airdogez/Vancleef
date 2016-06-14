using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathUIUpdate : MonoBehaviour {
    // Use this for initialization
    public Text puntajeText;
    public Button restartButton;

    public void UpdateScoreText(int cant)
    {
        puntajeText.text = "Puntaje final: " + cant.ToString();
    }

    public void Restart()
    {
      Application.LoadLevel("Game");
    }

}
