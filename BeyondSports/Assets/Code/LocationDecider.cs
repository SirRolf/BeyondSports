using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocationDecider : MonoBehaviour
{
    static string path = "Assets/Data/match_data.dat";

    private StreamReader reader = new StreamReader(path);

    private float frameCount = 0;

    void Start()
    {
        string[] tokens = ReadString(frameCount, 1).Split(';');
        for (int i = 0; i < tokens.Length - 1; i++)
        {
            string[] individualPlayerData = tokens[i].Split(',');
            Debug.Log(individualPlayerData[1]);
        }

        frameCount++;
    }

    private string ReadString(float line, int dataObject)
    {
        for (int i = 0; i < line; i++)
        {
            reader.ReadLine();
        }
        string[] tokens = reader.ReadLine().Split(':');
        reader.Close();
        return tokens[dataObject];
    }
}
