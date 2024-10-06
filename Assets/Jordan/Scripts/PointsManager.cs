using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class PointsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text stat;
    public static int points;
    void Start()
    {
        points = 0;
    }
    private void Update()
    {
        stats();
    }

    // Update is called once per frame

    public void stats()
    {
        stat.text = points.ToString();
    }
}
