using UnityEngine;
using System.Collections;

public class ParallaxController : MonoBehaviour
{
    enum Direction
    {
        LEFT = -1,
        RIGHT = 1,
    };

    public enum TypeOfAstralBody
    {
        BigPlanet = 0,
        RingPlanet = 1,
        FarPlanets = 2,
        Stars = 3,
    };


    public TypeOfAstralBody typeOfBody;
    public float xMargin;
    private float yStart;

    private float speedX;
    private float speedY;

    private Direction dir;
    private bool waiting = false;

    void Start()
    {
        yStart = 7.5f;
        if (typeOfBody != TypeOfAstralBody.Stars)
            ResetStartPos();
        else
            speedX = 0.01f;
    }

    void Update()
    {
        if (!waiting)
        {
            if (typeOfBody != TypeOfAstralBody.Stars)
            {
                transform.Translate(new Vector3((int)dir * speedX, -speedY, 0f));
                if (transform.position.y < -yStart)
                    ResetStartPos();
            }
            else
            {
                transform.Translate(Vector3.left * speedX);
                if (transform.position.x <= -18)
                    transform.position = new Vector3(18f, 0f, 0f);
            }
        }
    }

    private void ResetStartPos()
    {
        waiting = true;

        switch (typeOfBody)
        {
            case TypeOfAstralBody.BigPlanet:
                speedX = Random.Range(0.005f, 0.015f);
                speedY = Random.Range(0.005f, 0.015f);
                break;
            case TypeOfAstralBody.FarPlanets:
                speedX = Random.Range(0.005f, 0.01f);
                speedY = Random.Range(0.005f, 0.01f);
                break;
            case TypeOfAstralBody.RingPlanet:
                speedX = Random.Range(0.01f, 0.025f);
                speedY = Random.Range(0.01f, 0.025f);
                break;
            case TypeOfAstralBody.Stars:
                break;
        }

        float startPosX = Random.Range(xMargin + 5f, -xMargin - 5f);
        float startPosY = yStart;

        if (startPosX > xMargin || startPosX < -xMargin)
            startPosY = Random.Range(0, yStart);

        transform.position = new Vector3(startPosX, startPosY, 0f);

        if (startPosX < 0)
            dir = Direction.RIGHT;
        else
            dir = Direction.LEFT;
        StartCoroutine(RandomWait());
    }

    IEnumerator RandomWait()
    {
        yield return new WaitForSeconds(Random.Range(5f, 12f));
        waiting = false;
    }
}
