using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;


public class Example
{
    public static TileType[][] puzzleRl1 = new TileType[][]
    {
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Empty, TileType.Green, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Yellow, TileType.Empty, TileType.Magenta},
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null}
    };

    public static TileType[][] puzzleRl2 = new TileType[][]
    {
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Blue,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Red,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Yellow,TileType.Empty,TileType.Empty,TileType.Green}
    };

    public static TileType[][] puzzleRl3 = new TileType[][]
    {
        new TileType[] {TileType.Blue,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Yellow,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Yellow,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Green,TileType.Green,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty,TileType.Red}
    };

    public static TileType[][] puzzleRlTestEasy = new TileType[][]
    {
        new TileType[] {TileType.Yellow,TileType.Empty,TileType.Null,TileType.Null},
        new TileType[] {TileType.Yellow,TileType.Empty,TileType.Null,TileType.Empty},
        new TileType[] {TileType.Blue,TileType.Empty,TileType.Null,TileType.Empty},
        new TileType[] {TileType.Blue,TileType.Blue,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Green,TileType.Magenta},
        new TileType[] {TileType.Empty,TileType.Green,TileType.Red,TileType.Empty}
    };

    //8*8
   
    public static TileType[][] puzzleRL8x8_1 = new TileType[][]
    {
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green, TileType.Green,TileType.Null},
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green, TileType.Green,TileType.Null},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green, TileType.Empty, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green, TileType.Empty, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Red, TileType.Yellow, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Magenta, TileType.Empty, TileType.Null, TileType.Null,TileType.Null},
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty, TileType.Null, TileType.Null,TileType.Null}

    };

    public static TileType[][] puzzleRL8x8_2 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Green, TileType.Green, TileType.Empty, TileType.Empty, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Null, TileType.Empty, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Gray, TileType.Empty, TileType.Red, TileType.Null, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Red, TileType.Null,TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Empty, TileType.Null, TileType.Null,TileType.Null}
    };

    public static TileType[][] puzzleRL8x8_3 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Magenta, TileType.Magenta, TileType.Empty, TileType.Yellow, TileType.Yellow, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Yellow, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Red, TileType.Empty, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Green,TileType.Empty},
        new TileType[] {TileType.Red, TileType.Empty, TileType.Blue, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green,TileType.Empty},
        new TileType[] {TileType.Red, TileType.Empty, TileType.Empty, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Green,TileType.Empty},
        new TileType[] {TileType.Red, TileType.Red, TileType.Red, TileType.Red, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty}
    };


    

    //HARDCODED PUZZLES//
    public static TileType[][] puzzleEasy1 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Red, TileType.Blue, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Null, TileType.Empty, TileType.Empty}
    };
    public static TileType[][] puzzleEasy2 = new TileType[][]
    {
        new TileType[] {TileType.Red, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Red, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Null, TileType.Empty, TileType.Blue}
    };
    public static TileType[][] puzzleEasy3 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Red, TileType.Blue, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Yellow, TileType.Blue, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Null, TileType.Empty, TileType.Empty}
    };
    public static TileType[][] puzzleEasy4 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Yellow, TileType.Red, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Blue, TileType.Red, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Null, TileType.Magenta, TileType.Empty}
    };

    public static TileType[][] puzzle2 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Blue, TileType.Red, TileType.Empty}
    };

    public static TileType[][] puzzleMedium = new TileType[][]
    {
        new TileType[] {TileType.Null, TileType.Green, TileType.Null, TileType.Null, TileType.Null, TileType.Null},
        new TileType[] {TileType.Green, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Blue, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Magenta, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Gray, TileType.Empty, TileType.Magenta, TileType.Magenta},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Magenta, TileType.Magenta, TileType.Magenta},
        new TileType[] {TileType.Empty, TileType.Red, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null}

    };
    public static TileType[][] puzzle4 = new TileType[][]
    {
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green, TileType.Green},
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green, TileType.Green},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Red, TileType.Yellow, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Magenta, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty, TileType.Null, TileType.Null}

    };

    public static TileType[][] puzzleIntermidiate = new TileType[][]
    {
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green},
        new TileType[] {TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Green, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Red, TileType.Yellow},
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty, TileType.Null}

    };

    public static TileType[][] puzzleDifficult = new TileType[][]
    {
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null,TileType.Null, TileType.Green, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null,TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Magenta,TileType.Magenta, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue, TileType.Empty, TileType.Red},
        new TileType[] {TileType.Magenta,TileType.Null, TileType.Empty, TileType.Empty, TileType.Null, TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Null},
        new TileType[] {TileType.Magenta,TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty,TileType.Null, TileType.Empty, TileType.Gray, TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null, TileType.Null}

    };
    public static TileType[][] puzzleHard = new TileType[][]
    {
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Null,TileType.Null, TileType.Null, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Gray, TileType.Null},
        new TileType[] {TileType.Null,TileType.Red, TileType.Red, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Red,TileType.Red, TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty,TileType.Empty, TileType.Null, TileType.Green, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Null,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Null,TileType.Null, TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Yellow},
        new TileType[] {TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty}

    };
    public static TileType[][] puzzleExpert = new TileType[][]
    {
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Magenta,TileType.Magenta,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Red, TileType.Empty, TileType.Green, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Red, TileType.Empty, TileType.Green, TileType.Blue, TileType.Empty,TileType.Gray,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Yellow, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty,TileType.Empty},

    };

    public static TileType[][] puzzle2251 = new TileType[][]
    {
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Null, TileType.Null , TileType.Null , TileType.Null , TileType.Null , TileType.Empty , TileType.Empty , TileType.Null },
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Null, TileType.Null , TileType.Null , TileType.Null , TileType.Null , TileType.Empty , TileType.Empty , TileType.Null },
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Null, TileType.Null , TileType.Null , TileType.Null , TileType.Null , TileType.Empty , TileType.Null , TileType.Null },
        new TileType[] {TileType.Null,TileType.Null,TileType.Empty, TileType.Empty, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Empty, TileType.Red , TileType.Null , TileType.Null , TileType.Null , TileType.Yellow , TileType.Magenta , TileType.Magenta },
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty, TileType.Red , TileType.Red , TileType.Red , TileType.Null , TileType.Yellow , TileType.Yellow , TileType.Magenta },
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null, TileType.Empty,TileType.Empty, TileType.Red , TileType.Red , TileType.Empty , TileType.Green , TileType.Yellow , TileType.Yellow , TileType.Empty },
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null, TileType.Empty,TileType.Empty, TileType.Empty , TileType.Empty , TileType.Empty , TileType.Empty , TileType.Null , TileType.Empty , TileType.Empty },
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty, TileType.Empty , TileType.Empty , TileType.Empty , TileType.Blue , TileType.Blue , TileType.Blue , TileType.Blue },
        new TileType[] {TileType.Null,TileType.Null,TileType.Empty, TileType.Empty, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Empty, TileType.Empty , TileType.Empty , TileType.Empty , TileType.Empty , TileType.Gray , TileType.Blue , TileType.Null },
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Null, TileType.Null , TileType.Empty , TileType.Empty , TileType.Empty , TileType.Empty , TileType.Empty , TileType.Null },
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null,TileType.Null, TileType.Null , TileType.Null , TileType.Null , TileType.Empty , TileType.Empty , TileType.Empty , TileType.Empty },


    };
    public static TileType[][] puzzle761 = new TileType[][]
    {
        new TileType[] {TileType.Null,TileType.Null,TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Null, TileType.Red, TileType.Empty, TileType.Null, TileType.Empty, TileType.Blue,TileType.Blue},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue,TileType.Null},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Green, TileType.Yellow, TileType.Yellow, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Null, TileType.Empty, TileType.Empty, TileType.Null, TileType.Yellow, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Null,TileType.Empty,TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Yellow, TileType.Yellow, TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Null,TileType.Null,TileType.Gray, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Empty,TileType.Null},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Null}

    };

    public static TileType[][] puzzle2275 = new TileType[][]
    {
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty, TileType.Null, TileType.Null, TileType.Magenta, TileType.Empty, TileType.Null, TileType.Null, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Red, TileType.Empty, TileType.Empty, TileType.Magenta, TileType.Magenta, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Green, TileType.Yellow, TileType.Empty, TileType.Gray, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Green, TileType.Yellow, TileType.Null, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null, TileType.Blue, TileType.Null, TileType.Null, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Null, TileType.Null, TileType.Null, TileType.Null, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue, TileType.Blue, TileType.Empty, TileType.Empty, TileType.Null}
    };

    public static TileType[][] emptyPuzzle = new TileType[][]
    {
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty},
        new TileType[] {TileType.Empty,TileType.Empty,TileType.Empty}
    };

    
}