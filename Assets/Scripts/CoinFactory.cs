using UnityEngine;
using System.Collections;

public class CoinFactory : MonoBehaviour
{

    public GameObject coinPrefab;
    public int level = 0;
    private Transform objectLayer;
    private float vertExtent;
    private float horzExtent;
    private float startTimeSegments = 0;
    public Sprite[] sprites;

    void Start()
    {
        objectLayer = GameObject.Find("Layer_Objects").transform;
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        level = 0;
        StartCoroutine(SpawnCoins());
    }

    // Update is called once per frame
    void Update()
    {
        float segmentTime = Time.time - startTimeSegments;
        if (segmentTime >= 60)
        {
            level++; //limitar o arreglar
            startTimeSegments = Time.time;
        }
    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        GameObject coin = (GameObject)Instantiate(coinPrefab, new Vector3(Random.Range(-horzExtent + 2, horzExtent - 2), vertExtent + 1), Quaternion.identity);
        coin.transform.parent = objectLayer;
        if (level < 4)
            coin.GetComponent<Coin>().setSprite(sprites[level]); //OOR exception en la variable level (max index value de 4)
        coin.GetComponent<Coin>().setScore((level + 1) * 10);
        StartCoroutine(SpawnCoins());
    }
}
