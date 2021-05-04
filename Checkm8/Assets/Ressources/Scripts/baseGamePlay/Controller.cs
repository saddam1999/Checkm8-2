﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject chesspiece;
    public static int size = 8;//Taille du plateau de jeu, changeant en fonction du nombre de joueur

    private GameObject[,] positions = new GameObject[size,size];//Ensemble des positions sur le board
    //Ensemble des joueurs(que 2 pour l'instant)
    private GameObject[] player1 = new GameObject[16];//(car 16 pièces)
    private GameObject[] player2 = new GameObject[16];

    private string currentPlayer = "1";

    private bool gameOver = false;

    void Start()
    {
        //Création des joueurs (2 pour l'instant)
        player1 = new GameObject[]
        {
            Create("rook_p1",0,0), Create("rook_p1",7,0), Create("knight_p1",1,0), Create("bishop_p1",2,0),
            Create("queen_p1",3,0), Create("king_p1",4,0), Create("bishop_p1",5,0), Create("knight_p1",6,0),
            Create("pawn_p1",0,1), Create("pawn_p1",1,1), Create("pawn_p1",2,1), Create("pawn_p1",3,1),
            Create("pawn_p1",4,1), Create("pawn_p1",5,1), Create("pawn_p1",6,1), Create("pawn_p1",7,1)
        };

        player2 = new GameObject[]
        {
            Create("rook_p2",0,7), Create("rook_p2",7,7), Create("knight_p2",1,7), Create("bishop_p2",2,7),
            Create("queen_p2",3,7), Create("king_p2",4,7), Create("bishop_p2",5,7), Create("knight_p2",6,7),
            Create("pawn_p2",0,6), Create("pawn_p2",1,6), Create("pawn_p2",2,6), Create("pawn_p2",3,6),
            Create("pawn_p2",4,6), Create("pawn_p2",5,6), Create("pawn_p2",6,6), Create("pawn_p2",7,6)
        };

        //Mettons chaque pièce à leur positions
        for(int i=0; i<player1.Length;i++)
        {
            SetPosition(player1[i]);
            SetPosition(player2[i]);
        }
    
    }

    
    public GameObject Create(string pieceName, int posX, int posY)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0,0,0), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = pieceName;
        cm.xBoard = posX;
        cm.yBoard = posY;
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.xBoard,cm.yBoard] = obj;
    }

    public void SetPositionEmpty(int posX, int posY)
    {
        
    }
}
