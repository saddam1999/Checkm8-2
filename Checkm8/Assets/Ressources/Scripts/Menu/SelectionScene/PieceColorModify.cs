﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author : Samuel Goubeau
 * 
 * Manage : Change the color of sprite when the player click on buttons
 * 
 * Using : Canvas.Canvas-P1.ColInc, Canvas.Canvas-P1.ColDec, Canvas.Canvas-P2.ColInc, Canvas.Canvas-P2.ColDec
 */
public class PieceColorModify : MonoBehaviour
{
    private int colorChoose;

    // [White, Black, Red, Green, Blue, Cyan, Gray, Magenta, Yellow]
    public static Color[] colors = { new Color(1f, 1f, 1f), new Color(0f, 0f, 0f), new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f),
                                    new Color(0f, 1f, 1f), new Color(0.5f, 0.5f, 0.5f), new Color(1f, 0f, 1f), new Color(1f, 0.92f, 0.016f) };


    void Start()
    {
        colorChoose = 0;
    }


    public void IncColor(SpriteRenderer piece)
    {
        if(piece != null)
        {
            colorChoose++;
            if (colorChoose >= colors.Length)
            {
                colorChoose = 0;
            }
            piece.color = colors[colorChoose];
        }
    }


    public void DecColor(SpriteRenderer piece)
    {
        if (piece != null)
        {
            colorChoose--;
            if (colorChoose < 0)
            {
                colorChoose = colors.Length - 1;
            }
            piece.color = colors[colorChoose];
        }
    }
}
