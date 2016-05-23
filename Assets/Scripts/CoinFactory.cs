using UnityEngine;
using System.Collections;

public class CoinFactory : MonoBehaviour {

    public GameObject coinPrefab;
    private float vertExtent;
    private float horzExtent;

    void Start () {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        StartCoroutine(SpawnCoins());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        Instantiate(coinPrefab, new Vector3(Random.Range(-horzExtent + 2, horzExtent - 2), vertExtent + 1), Quaternion.identity); 
    }
}
