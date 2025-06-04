using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hp = 100;
    public int mp = 100;

    public bool isGodMode = false;

    public void InitPlayerData()
    {
        hp = 100;
        mp = 100;
        isGodMode = false;
    }
}
