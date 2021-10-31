using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    int point;
    GameObject prefab;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetPoint(int point)
    {
        this.point = point;
    }

    public int GetPoint()
    {
        return point;
    }

    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }
    public GameObject GetPrefab()
    {
        return prefab;
    }

}
