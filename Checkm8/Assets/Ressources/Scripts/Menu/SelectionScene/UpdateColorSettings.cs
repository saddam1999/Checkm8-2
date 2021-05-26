﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author : Maxime Quertan
 * 
 * Manage : Save the choices of players, before the start
 * 
 * Using : ???
 */
public class UpdateColorSettings : MonoBehaviour
{
    public SpriteRenderer piece;
    public int numPlayer;

    void Update()
    {
       switch(numPlayer)
       {
           case 1:
                GameSettings.colorP1 = piece.color;
                break;
           case 2:
                GameSettings.colorP2 = piece.color;
                break;
       }

    }
}
