﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsManager : MonoBehaviour
{
    public static GameObject eventPlate;
    //public static GameObject eventPanel;
    public static GameObject eventPanelText;

    void Start()
    {
        //eventPanel = GameObject.FindGameObjectWithTag("eventPanel");
        eventPlate = GameObject.FindGameObjectWithTag("event");
        eventPanelText = GameObject.FindGameObjectWithTag("eventText");
    }

    public static void EventPlateSpawn(int posX, int posY, int eventNum)
    {
        Debug.Log("eventPlate");

        float x = posX;
        float y = posY;

        x *= 0.125f;
        y *= 0.125f;

        x += -0.438f;
        y += -0.438f;

        GameObject ev = Instantiate(eventPlate, new Vector3(x,y,0), Quaternion.identity);

        EventsPlate eventScript = ev.GetComponent<EventsPlate>();

        eventScript.eventNum = eventNum;
        eventScript.SetCoords(posX,posY);
    }

    public static void Teleportation()
    {
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        //Récupérer 1 pièces random de chaque joueur
        GameObject piece1 = null;
        GameObject piece2 = null;
        bool pieceFound = false;
        int rand = Random.Range(0, cont.GetComponent<Controller>().player1.Length);
        while(!pieceFound)
        {
            if(cont.GetComponent<Controller>().player1[rand])
            {
                piece1 = cont.GetComponent<Controller>().player1[rand];
                pieceFound = true;
            }else{
                rand = Random.Range(0, cont.GetComponent<Controller>().player1.Length);
            }
        }
        rand = Random.Range(0, cont.GetComponent<Controller>().player2.Length);
        pieceFound = false;
        while(!pieceFound)
        {
            if(cont.GetComponent<Controller>().player2[rand])
            {
                piece2 = cont.GetComponent<Controller>().player2[rand];
                pieceFound = true;
            }else{
                rand = Random.Range(0, cont.GetComponent<Controller>().player2.Length);
            }
        }
        //Les interchanger
        int xDummy = piece1.GetComponent<Chessman>().xBoard;
        int yDummy = piece1.GetComponent<Chessman>().yBoard;
        piece1.GetComponent<Chessman>().xBoard = piece2.GetComponent<Chessman>().xBoard;
        piece1.GetComponent<Chessman>().yBoard = piece2.GetComponent<Chessman>().yBoard;
        piece2.GetComponent<Chessman>().xBoard = xDummy;
        piece2.GetComponent<Chessman>().yBoard = yDummy;
        cont.GetComponent<Controller>().SetPosition(piece1);
        piece1.GetComponent<Chessman>().setCoords(true);
        cont.GetComponent<Controller>().SetPosition(piece2);
        piece2.GetComponent<Chessman>().setCoords(false);
    }

    public static void SetTeleportation()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");

        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        //Trouver une case libre
        List<Vector2> freePos = new List<Vector2>();
        for(int i = 0;i<8;i++)
        {
            for(int j = 0;j<8;j++)
            {
                if(cont.GetComponent<Controller>().GetPosition(i,j) == null)//Si position vide
                {
                    freePos.Add(new Vector2(i,j));
                }
            }
        }
        //Tirage d'une case aléatoire
        int rand = Random.Range(0, freePos.Count);

        EventPlateSpawn((int)freePos[rand].x,(int)freePos[rand].y,0);

        //Animation de l'event
        eventPanelText.GetComponent<Text>().text = "TELEPORTATION";
        controller.GetComponent<Controller>().lighting.GetComponent<Animator>().SetBool("gameOver",true);
        EventPanel.tp = true;
    }

    public static void SetRotation()
    {
        Debug.Log("Rotation");
    }

    public static void SetTidalWaves()
    {
        Debug.Log("Tidal Waves");
    }

    public static void SetEruption()
    {
        Debug.Log("Eruption");
    }

    public static void SetPromotion()
    {
        Debug.Log("Promotion");
    }

    public static void Demotion()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        //On récupère une pièce de chaque joueur
        GameObject p1 = null;
        GameObject p2 = null;
        for(int i=0; i<controller.GetComponent<Controller>().player1.Length;i++)
        {
            if(controller.GetComponent<Controller>().player1[i])
            {
                if(controller.GetComponent<Controller>().player1[i].name != "pawn_p1" && controller.GetComponent<Controller>().player1[i].name != "king_p1")
                     p1 = controller.GetComponent<Controller>().player1[i];
            }
            if(controller.GetComponent<Controller>().player2[i])
            {
                if(controller.GetComponent<Controller>().player2[i].name != "pawn_p2" && controller.GetComponent<Controller>().player2[i].name != "king_p2")
                     p2 = controller.GetComponent<Controller>().player2[i];
            }
        }

        //On effectue la démotion
        int x1 = 0;
        int x2 = 0;
        int y1 = 0;
        int y2 = 0;
        if(p1)
        {
            x1 = p1.GetComponent<Chessman>().xBoard;
            y1 = p1.GetComponent<Chessman>().yBoard;
        }
        if(p2)
        {
            x2 = p2.GetComponent<Chessman>().xBoard;
            y2 = p2.GetComponent<Chessman>().yBoard;
        }   

        Destroy(p1);
        Destroy(p2);

        GameObject pawn1 = controller.GetComponent<Controller>().Create("pawn_p1",x1,y1);
        GameObject pawn2 = controller.GetComponent<Controller>().Create("pawn_p2",x2,y2);
        controller.GetComponent<Controller>().SetPosition(pawn1);
        controller.GetComponent<Controller>().SetPosition(pawn2);
    }

    public static void SetDemotion()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");

        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        //Trouver une case libre
        List<Vector2> freePos = new List<Vector2>();
        for(int i = 0;i<8;i++)
        {
            for(int j = 0;j<8;j++)
            {
                if(cont.GetComponent<Controller>().GetPosition(i,j) == null)//Si position vide
                {
                    freePos.Add(new Vector2(i,j));
                }
            }
        }
        //Tirage d'une case aléatoire
        int rand = Random.Range(0, freePos.Count);

        EventPlateSpawn((int)freePos[rand].x,(int)freePos[rand].y,5);

        //Animation de l'event
        eventPanelText.GetComponent<Text>().text = "DEMOTION";
        controller.GetComponent<Controller>().lighting.GetComponent<Animator>().SetBool("gameOver",true);
        EventPanel.demo = true;
    }

    public static void SetProtection()
    {
        Debug.Log("Protection");
    }

    public static void SetFlamesStrike()
    {
        Debug.Log("Flames Strike");
    }

    private static bool shouldEventPlay(float proba)//Renvoie true si un event doit apparaître ce tour ci
    {
        float rand = Random.Range(0, 100);
        if(rand <= proba)
            return true;
        else
            return false;
    }

    public static void chooseEvent()//Choisit un event en fonction des proba d'apparition
    {
        if(shouldEventPlay(GameSettings.eventProbability))
        {
            float maxVal;

            //Créations d'intervalles de valeurs correspondant à chaque events
            float tp = 0 + GameSettings.tpProbabilty;
            float rota = tp + GameSettings.rotaProbabilty;
            float twaves = rota + GameSettings.twavesProbabilty;
            float erupt = twaves + GameSettings.eruptProbabilty;
            float promo = erupt + GameSettings.promoProbabilty;
            float demo = promo + GameSettings.demoProbabilty;
            float protect = demo + GameSettings.protecProbabilty;
            float fstrike = protect + GameSettings.fstrikeProbabilty;

            maxVal = fstrike;
            float rand = Random.Range(0, maxVal);

            //Choix de l'event
            if(rand >=0 && rand <=tp)
                SetTeleportation();
            if(rand >tp && rand <=rota)
                SetRotation();
            if(rand >rota && rand <=twaves)
                SetTidalWaves();
            if(rand >twaves && rand <=erupt)
                SetEruption();
            if(rand >erupt && rand <=promo)
                SetPromotion();
            if(rand >promo && rand <=demo)
                SetDemotion();
            if(rand >demo && rand <=protect)
                SetProtection();
            if(rand >protect && rand <=fstrike)
                SetFlamesStrike();
        }
    }
}
