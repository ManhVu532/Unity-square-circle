using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject square, circle;
    public int numOfFake = 2;
    public float timeSpawn = 2.0f;
    public Vector2 screenBouds;
    private const int SQUARE = 1;
    private const int CIRCLE = 2;
    enum Point
        {
        ZERO= 0,
        ONE = 1,
        TWO = 2
        }
    // Start is called before the first frame update
    void Start()
    {
        screenBouds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpawnObject();
        StartCoroutine(objectWave());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
        GameObject s = Instantiate(square) as GameObject;
        s.GetComponent<Object>().SetPoint((int)Point.ONE);
        GameObject c = Instantiate(circle) as GameObject;
        c.GetComponent<Object>().SetPoint((int)Point.TWO);

        s.transform.position = new Vector3(Random.Range(-screenBouds.x+0.75f, screenBouds.x-0.75f), Random.Range(-screenBouds.y+0.75f, screenBouds.y-0.75f), 10);
        c.transform.position = new Vector3(Random.Range(-screenBouds.x + 0.75f, screenBouds.x - 0.75f), Random.Range(-screenBouds.y + 0.75f, screenBouds.y - 0.75f), 10);
        

        for (int i = 0; i< numOfFake; i++)
        {
            GameObject fk = Instantiate(Random.Range(SQUARE, CIRCLE) == SQUARE ? square : circle) as GameObject;
            fk.GetComponent<Object>().SetPoint((int)Point.ZERO);


            fk.transform.position = new Vector3(Random.Range(-screenBouds.x + 0.5f, screenBouds.x - 0.5f), Random.Range(-screenBouds.y + 0.75f, screenBouds.y - 0.75f), 10);
        }
    }

    IEnumerator objectWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            SpawnObject();
        }
    }
}
