using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


public class Generator
{
    //HARDCODED PUZZLES//
    public TileType[][] puzzleEasy1 = new TileType[][]
    {
        new TileType[] {TileType.Red, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Null, TileType.Blue, TileType.Empty}
    };

    public TileType getRandomTileType(int range){
        range += 2;
        return (TileType)Enum.ToObject(typeof(TileType) , UnityEngine.Random.Range(2, range));
    }

    public TileType getRandomTileType(List<TileType> colors,System.Random random){
        int index = random.Next(colors.Count);
        return colors[index];
    }


    public List<TileType> getColorArray(int range){

        List<TileType> colors = Enum.GetValues(typeof(TileType)).Cast<TileType>().ToList();
        List<TileType> subColors = colors.GetRange(2,colors.Count-2);
        IListExtensions.Shuffle(subColors);
        subColors = subColors.GetRange(0,range);
        
        return subColors;
    }

    public TileType getNextTile(int range,int i,int j, TileType[][] matrix){
        TileType random = getRandomTileType(range);
        return random;
    }

    //[B,B,0]
    //[B,B,0]
    //[0,0,0]
    public TileType[][] generateSymetricPuzzle(int size,int numberColors){

        System.Random rnd = new System.Random();

        //Primeiro tem que se decidir em que eixo e que ela e simetrica tanto em x como y
        //Para cada cor tem que se definir um eixo X e Y
        //Iterar pelas cores

        TileType[][] matrix = new TileType[size][];

        //Initialize Matrix
        for (int i = 0; i < size; i++){
            TileType[] line = new TileType[size];
            for (int j = 0; j < size; j++)
                line[j] = TileType.Empty;
            matrix[i] = line;
        }

        //Get random color array
        List<TileType> colors = getColorArray(numberColors);
        int rotationAxisX = size /2-1;
        int rotationAxisY = size /2-1;

        for (int i = 0; i < size / 2; i++){
            TileType[] line = new TileType[size];
            int symetricX = i + 2 * (rotationAxisX - i) + 1;
            for (int j = 0; j < size/2; j++){
                int symetricY = j + 2 * (rotationAxisY - j) + 1;

                TileType random = getRandomTileType(colors,rnd);
                if(symetricY < size ){
                    line[symetricY] = random;
                    if(symetricX < size ){
                        matrix[symetricX][j] = random;
                        matrix[symetricX][symetricY] = random;
                    }
                }
                
                line[j] = random;
            }
            matrix[i] = line;
        }
        
        return matrix;
    }

    public void unfold(TileType[][] matrix){
        List<TileType> colors = puzzleColors(matrix);
        foreach (TileType color in colors){
            
        }      
        
    }

    private void  canUnfoldUp(){

    }

      public TileType[][] generateRandomPuzzle(int size,int numberColors){

        System.Random rnd = new System.Random();

        //Primeiro tem que se decidir em que eixo e que ela e simetrica tanto em x como y
        //Para cada cor tem que se definir um eixo X e Y
        //Iterar pelas cores

        TileType[][] matrix = new TileType[size][];
        List<TileType> colors = getColorArray(numberColors);

        for (int i = 0; i < size; i++){
            TileType[] line = new TileType[size];
            for (int j = 0; j < size; j++){
                TileType random = getRandomTileType(colors,rnd);
                int middleX = (size + j)/2;
                int middleY = (size + i)/2;

                //Debug.Log(middleX + " X " + j);
                //Debug.Log(middleY + " Y " + i);


                line[j] = random;
            }
            matrix[i] = line;
        }
        return matrix;
    }

    


    public void displayConsole(TileType[][] puzzleMatrix)
    {

        string puzzleString = "";
        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                puzzleString += puzzleMatrix[i][j] + " ";
            }
            puzzleString += "\n";

        }
        Debug.Log(puzzleString);
    }

    private void undoMoveRight(TileType tile,TileType[][] puzzleMatrix)
    {

        int symetryAxis = calculateHorizontalSymetrixAxis(tile,puzzleMatrix);

        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = puzzleMatrix[i].Length - 1; j > symetryAxis; j--)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    puzzleMatrix[i][j] = TileType.Empty;
                }
            }
        }
    }

    private void undoMoveLeft(TileType tile,TileType[][] puzzleMatrix)
    {
        int symetryAxis = calculateHorizontalSymetrixAxis(tile,puzzleMatrix);

        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j <= symetryAxis; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    puzzleMatrix[i][j] = TileType.Empty;
                }
            }
        }
    }

    private void undoMoveUp(TileType tile,TileType[][] puzzleMatrix)
    {
        int symetryAxis = calculateVerticalSymetrixAxis(tile,puzzleMatrix);

        for (int i = 0; i <= symetryAxis; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    puzzleMatrix[i][j] = TileType.Empty;
                }
            }
        }
    }


    private void undoMoveDown(TileType tile,TileType[][] puzzleMatrix)
    {
        int symetryAxis = calculateVerticalSymetrixAxis(tile,puzzleMatrix);

        for (int i = puzzleMatrix.Length - 1; i > symetryAxis; i--)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    puzzleMatrix[i][j] = TileType.Empty;
                }
            }
        }
    }

     private List<TileType> puzzleColors(TileType[][] puzzleMatrix)
    {
        Dictionary<TileType, int> colorCount = new Dictionary<TileType, int>();

        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] != TileType.Empty && puzzleMatrix[i][j] != TileType.Null)
                {
                    if (colorCount.ContainsKey(puzzleMatrix[i][j]))
                        colorCount[puzzleMatrix[i][j]] += 1;
                    else
                        colorCount[puzzleMatrix[i][j]] = 1;
                }
            }
        }

        List<TileType> puzzleColors = new List<TileType>(colorCount.Keys);
        puzzleColors = puzzleColors.OrderBy(color => colorCount[color]).ToList();

        return puzzleColors;
    }

    private int calculateVerticalSymetrixAxis(TileType tile,TileType[][] puzzleMatrix){
        int lowerBound = 0;
        int upperBound = puzzleMatrix[0].Length - 1;

        //Discover the bounds
        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    if (i < upperBound)
                        upperBound = i;
                    if (i > lowerBound)
                        lowerBound = i;
                }
            }
        }

        return (upperBound + lowerBound) / 2;
    }

    private int calculateHorizontalSymetrixAxis(TileType tile, TileType[][] puzzleMatrix){
        int leftBound = puzzleMatrix.Length;
        int rightBound = 0;

        //Discover the bounds
        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    if (j < leftBound)
                        leftBound = j;
                    if (j > rightBound)
                        rightBound = j;
                }
            }
        }

        return (rightBound + leftBound) / 2;
    }
}