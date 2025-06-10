using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string msg;
    private StringBuilder sb = new StringBuilder(1200);
    
    void Update()
    {
        sb.Clear();
        
        for (int i = 0; i < 100; i++)
        {
            sb.Append("Message ").Append(i).Append("\n");
            //msg += $"Message {i}\n";
        }

        Debug.Log(sb);
    }
}
