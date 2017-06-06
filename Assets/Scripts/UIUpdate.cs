using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUpdate : MonoBehaviour {

    // Use this for initialization
    public Text coinsText;

    public void UpdateCoinText(int cant)
    {
        coinsText.text = "Coins: " + cant.ToString();
    }
}
