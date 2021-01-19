﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private MainGameUI _mainGameUI;

    // zbiór pól
    IEnumerable<Field> _fields;
    // tablica wyszukiwania pól 
    Field[,,] _fieldsarray = new Field[6, 6, 6];
    // wartość pozycji słońca
    int _sunposition;

    //players 
    private List<Player> _players = new List<Player>();
    private int _currentPlayerId; //refers to the player who is currently taking his turn

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void startNewGame(int numberOfPlayers, string[] nicks)
    {
        StartCoroutine(LoadMainGameScene()); //Load main game scene and get MainGameUI object.. Don't touch! 

        //Create players
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Player tmp = new Player(i, nicks[i], PlayerType.RealPlayer);
            _players.Add(tmp);
        }

        _currentPlayerId = 0;

        Debug.Log("New game has been started.");

        //_mainGameUI.RefreshPanels();
    }

    public void FazePhotosynthesis(int position)
    {
        switch (position)
        {

            case 1:
                // x-1; y+1; z;
                foreach (Field field in _fields)
                {
                    int x = field._vector.x;
                    int y = field._vector.y;
                    int z = field._vector.z;
                    int pointoflightstoadd = 0; // ustawić na poziom drzewa

                    // weryfikacja czy na polu ustawione jest drzewo
                    if (field._assignment != null || field._assignment._treeLevel != TreeObject.TreeLvl.SEED) // 
                    {
                        // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa
                        pointoflightstoadd = SetTreeValue(field);
                        // sprawdzanie odległości do dystansu 3 pól przed drzewem
                        for (int distance = 0; distance < 3; distance++)
                        {
                            x--;
                            y++;
                            // weryfikacja czy pole istnieje
                            if ((x < 0 || y < 0 || z < 0) || (x > 6 || y > 6 || z > 6))
                            {
                                break;
                            }
                            else
                            {
                                // weryfikacja czy na polu o dystansie distance przed drzewem jest inne drzewo
                                pointoflightstoadd = FieldVerification(x, y, z, pointoflightstoadd, distance, field);

                            }

                        }

                        // dodanie graczowi odpowieniej ilości punktów za dane drzewo
                        field._assignment._player.PointOfLIghts += pointoflightstoadd;

                    }

                }
                break;

            case 2:
                // x-1; y; z+1;
                foreach (Field field in _fields)
                {
                    int x = field._vector.x;
                    int y = field._vector.y;
                    int z = field._vector.z;
                    int pointoflightstoadd = 0; // ustawić na poziom drzewa

                    // weryfikacja czy na polu ustawione jest drzewo
                    if (field._assignment != null || field._assignment._treeLevel != TreeObject.TreeLvl.SEED) // 
                    {
                        // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa
                        pointoflightstoadd = SetTreeValue(field);
                        // sprawdzanie odległości do dystansu 3 pól przed drzewem
                        for (int distance = 0; distance < 3; distance++)
                        {
                            x--;
                            z++;
                            // weryfikacja czy pole istnieje
                            if ((x < 0 || y < 0 || z < 0) || (x > 6 || y > 6 || z > 6))
                            {
                                break;
                            }
                            else
                            {
                                // weryfikacja czy na polu o dystansie distance przed drzewem jest inne drzewo
                                pointoflightstoadd = FieldVerification(x, y, z, pointoflightstoadd, distance, field);

                            }

                        }

                        // dodanie graczowi odpowieniej ilości punktów za dane drzewo
                        field._assignment._player.PointOfLIghts += pointoflightstoadd;

                    }

                }
                break;


            case 3:
                // x; y-1; z+1;
                foreach (Field field in _fields)
                {
                    int x = field._vector.x;
                    int y = field._vector.y;
                    int z = field._vector.z;
                    int pointoflightstoadd = 0; // ustawić na poziom drzewa

                    // weryfikacja czy na polu ustawione jest drzewo
                    if (field._assignment != null || field._assignment._treeLevel != TreeObject.TreeLvl.SEED) // 
                    {
                        // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa
                        pointoflightstoadd = SetTreeValue(field);
                        // sprawdzanie odległości do dystansu 3 pól przed drzewem
                        for (int distance = 0; distance < 3; distance++)
                        {
                            y--;
                            z++;
                            // weryfikacja czy pole istnieje
                            if ((x < 0 || y < 0 || z < 0) || (x > 6 || y > 6 || z > 6))
                            {
                                break;
                            }
                            else
                            {
                                // weryfikacja czy na polu o dystansie distance przed drzewem jest inne drzewo
                                pointoflightstoadd = FieldVerification(x, y, z, pointoflightstoadd, distance, field);

                            }

                        }

                        // dodanie graczowi odpowieniej ilości punktów za dane drzewo
                        field._assignment._player.PointOfLIghts += pointoflightstoadd;

                    }

                }
                break;


            case 4:
                // x+1; y-1; z;
                foreach (Field field in _fields)
                {
                    int x = field._vector.x;
                    int y = field._vector.y;
                    int z = field._vector.z;
                    int pointoflightstoadd = 0; // ustawić na poziom drzewa

                    // weryfikacja czy na polu ustawione jest drzewo
                    if (field._assignment != null || field._assignment._treeLevel != TreeObject.TreeLvl.SEED) // 
                    {
                        // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa
                        pointoflightstoadd = SetTreeValue(field);
                        // sprawdzanie odległości do dystansu 3 pól przed drzewem
                        for (int distance = 0; distance < 3; distance++)
                        {
                            x++;
                            y--;
                            // weryfikacja czy pole istnieje
                            if ((x < 0 || y < 0 || z < 0) || (x > 6 || y > 6 || z > 6))
                            {
                                break;
                            }
                            else
                            {
                                // weryfikacja czy na polu o dystansie distance przed drzewem jest inne drzewo
                                pointoflightstoadd = FieldVerification(x, y, z, pointoflightstoadd, distance, field);

                            }

                        }

                        // dodanie graczowi odpowieniej ilości punktów za dane drzewo
                        field._assignment._player.PointOfLIghts += pointoflightstoadd;
                    }

                }
                break;


            case 5:
                // x+1; y; z-1;
                foreach (Field field in _fields)
                {
                    int x = field._vector.x;
                    int y = field._vector.y;
                    int z = field._vector.z;
                    int pointoflightstoadd = 0; // ustawić na poziom drzewa

                    // weryfikacja czy na polu ustawione jest drzewo
                    if (field._assignment != null || field._assignment._treeLevel != TreeObject.TreeLvl.SEED) // 
                    {
                        // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa
                        pointoflightstoadd = SetTreeValue(field);
                        // sprawdzanie odległości do dystansu 3 pól przed drzewem
                        for (int distance = 0; distance < 3; distance++)
                        {
                            x++;
                            z--;
                            // weryfikacja czy pole istnieje
                            if ((x < 0 || y < 0 || z < 0) || (x > 6 || y > 6 || z > 6))
                            {
                                break;
                            }
                            else
                            {
                                // weryfikacja czy na polu o dystansie distance przed drzewem jest inne drzewo
                                pointoflightstoadd = FieldVerification(x, y, z, pointoflightstoadd, distance, field);

                            }

                        }

                        // dodanie graczowi odpowieniej ilości punktów za dane drzewo
                        field._assignment._player.PointOfLIghts += pointoflightstoadd;

                    }

                }
                break;


            case 6:
                // x; y+1; z-1;
                foreach (Field field in _fields)
                {
                    int x = field._vector.x;
                    int y = field._vector.y;
                    int z = field._vector.z;
                    int pointoflightstoadd = 0; // ustawić na poziom drzewa

                    // weryfikacja czy na polu ustawione jest drzewo
                    if (field._assignment != null || field._assignment._treeLevel != TreeObject.TreeLvl.SEED) // 
                    {
                        // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa
                        pointoflightstoadd = SetTreeValue(field);
                        // sprawdzanie odległości do dystansu 3 pól przed drzewem
                        for (int distance = 0; distance < 3; distance++)
                        {
                            y++;
                            z--;
                            // weryfikacja czy pole istnieje
                            if ((x < 0 || y < 0 || z < 0) || (x > 6 || y > 6 || z > 6))
                            {
                                break;
                            }
                            else
                            {
                                // weryfikacja czy na polu o dystansie distance przed drzewem jest inne drzewo
                                pointoflightstoadd = FieldVerification(x, y, z, pointoflightstoadd, distance, field);

                            }

                        }

                        // dodanie graczowi odpowieniej ilości punktów za dane drzewo
                        field._assignment._player.PointOfLIghts += pointoflightstoadd;

                    }

                }
                break;


            default:
                Console.WriteLine("Error - point of lights not counted.");
                break;


        }
    }

    // weryfikacja możliwych do uzyskania punktów światła dla danego drzewa na względem danego dystansu
    private int FieldVerification(int _x, int _y, int _z, int _pointoflightstoadd, int _distance, Field _field)
    {
        int x = _x;
        int y = _y;
        int z = _z;
        int pointoflightstoadd = _pointoflightstoadd;
        int distance = _distance;
        Field field = _field;

        if (_fieldsarray[x, y, z]._assignment != null && _fieldsarray[x, y, z]._assignment._treeLevel != TreeObject.TreeLvl.SEED)
        {
            switch (field._assignment._treeLevel)
            {
                case TreeObject.TreeLvl.SMALL:
                    {
                        switch (distance)
                        {
                            case 1:
                                {
                                    // niezależnie jakie drzewo jest na pozycji zawsze zacieni małe drzewo 
                                    pointoflightstoadd = Math.Min(pointoflightstoadd, 0);
                                    break;
                                }
                            case 2:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.SMALL)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 0);
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.BIG)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 0);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Error - point of lights - shading - smalltree.");
                                    break;
                                }
                        }
                        break;
                    }

                case TreeObject.TreeLvl.MID:
                    {
                        switch (distance)
                        {
                            case 1:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.SMALL)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 0);
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.SMALL)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 2);
                                    }
                                    else if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.MID)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 0);
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.BIG)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 2);
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Error - point of lights - shading - midtree.");
                                    break;
                                }
                        }
                        break;

                    }

                case TreeObject.TreeLvl.BIG:
                    {
                        switch (distance)
                        {
                            case 1:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.SMALL)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 2);
                                    }
                                    else if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.MID)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 0);
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.SMALL)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 3);
                                    }
                                    else if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.MID)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 2);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 1);
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (_fieldsarray[x, y, z]._assignment._treeLevel == TreeObject.TreeLvl.BIG)
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 2);
                                    }
                                    else
                                    {
                                        pointoflightstoadd = Math.Min(pointoflightstoadd, 3);
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Error - point of lights - shading - bigtree.");
                                    break;
                                }
                        }
                        break;
                    }

                default:
                    Console.WriteLine("Error - point of lights to add not verified.");
                    break;
            }

        }

        return pointoflightstoadd;
    }

    // ustawianie bazowych punktów światła do uzyskania dla sprawdzanego drzewa 
    private int SetTreeValue(Field _field)
    {
        Field field = _field;
        int pointoflightstoadd = 0;

        switch (field._assignment._treeLevel)
        {
            case TreeObject.TreeLvl.SMALL:
                {
                    pointoflightstoadd = 1;
                    break;
                }
            case TreeObject.TreeLvl.MID:
                {
                    pointoflightstoadd = 2;
                    break;
                }
            case TreeObject.TreeLvl.BIG:
                {
                    pointoflightstoadd = 3;
                    break;
                }
            default:
                {
                    Console.WriteLine("Error - point of lights - shading - tree.");
                    break;
                }

        }
        return pointoflightstoadd;
    }

    // przypisywanie listy pól do tablicy wyszukiwania pól
    public void FillFieldArray()
    {
        foreach (Field field in _fields)
        {
            _fieldsarray[field._vector.x, field._vector.y, field._vector.z] = field;
        }

    }

    IEnumerator LoadMainGameScene() //please don't touch this...
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("_MAIN_SCENE");

        while (!async.isDone)
        {
            yield return 0;
        }
        _mainGameUI = MainGameUI.Instance;
    }

}

