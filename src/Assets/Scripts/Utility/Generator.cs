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


    public TileType[][] generatePuzzle(int size,int numberColors,int numberMoves){
 
        System.Random rnd = new System.Random();

        TileType[][] matrix = new TileType[size*2][];
        int begin = size - size / 2;
        int end = size + size / 2;

        //Initialize Matrix
        for (int i = 0; i < size * 2; i++){
            TileType[] line = new TileType[size * 2];
            for (int j = 0; j < size * 2; j++)
                line[j] = TileType.Empty;
            matrix[i] = line;
        }

        //Get random color array
        List<TileType> colors = getColorArray(numberColors);


        int x = UnityEngine.Random.Range(begin, end);
        int y = UnityEngine.Random.Range(begin, end);

        int numberMovesFirstColor = numberMoves/numberColors;
        int initialSize = (int) Math.Pow(((size*size)/numberColors),1.0/numberMovesFirstColor);


        generateXAdjacentSqares(matrix,colors[0],initialSize,begin,end,x,y);


        for (int i = 1; i < colors.Count; i++){
            List<(int,int)> adjacent = getAdjacent(matrix, begin,end);
            int index = UnityEngine.Random.Range(0, adjacent.Count);
            x = adjacent[index].Item1;
            y = adjacent[index].Item2;
            generateXAdjacentSqares(matrix,colors[i],initialSize,begin,end,x,y);

        }
        
        return matrix;
    }

    //Gera x Quadrados adjacentes
    private void generateXAdjacentSqares(TileType[][] matrix,TileType tile, int number,int begin,int end,int i,int j){
        List<(int,int)> adjacent = new List<(int, int)>();
        for (int k = 0; k < number; k++)
        {
            matrix[i][j] = tile;  
            adjacent = getAdjacent(i,j,matrix,begin,end); //Ao usar isto ele vai estar a procurar em filinha, a alternativa e percorrer tudo
            int index = UnityEngine.Random.Range(0, adjacent.Count);
            i = adjacent[index].Item1;
            j = adjacent[index].Item2;  
        }
    }

    //Get adjacent Empty positions to a position
    private List<(int,int)> getAdjacent(int x,int y, TileType[][] matrix, int begin,int end){
        List<(int,int)> adjacents = new List<(int,int)>();
        
        if(x+1 < end){
            if(matrix[x+1][y] == TileType.Empty) adjacents.Add((x+1,y));
        } if(x-1 >= 0){
            if(matrix[x-1][y] == TileType.Empty) adjacents.Add((x-1,y));
        } if(y+1 < end){
            if(matrix[x][y+1] == TileType.Empty) adjacents.Add((x,y+1));
        } if(y-1 >= 0){
            if(matrix[x][y-1] == TileType.Empty) adjacents.Add((x,y-1));
        }
        return adjacents;
    } 

    //Por mais eficiente
    //Retorna todos os quadrados vazios a volta de uma cor
    private List<(int,int)> getAdjacent(TileType color, TileType[][] matrix, int begin,int end){
        List<(int,int)> adjacents = new List<(int,int)>();
        for (int i = begin; i < end; i++){
            for (int j = begin; j < end; j++){
                if(isAdjacentColor(i,j,color,matrix,begin,end)){
                    adjacents.Add((i,j));
                }           
            } 
        }
        return adjacents;
    }

    //Por mais eficiente
    //Retorna todos os quadrados vazios a volta de qualquer cor
    private List<(int,int)> getAdjacent(TileType[][] matrix, int begin,int end){
        List<(int,int)> adjacents = new List<(int,int)>();
        for (int i = begin; i < end; i++){
            for (int j = begin; j < end; j++){
                if(isAdjacent(i,j,matrix,begin,end)){
                    adjacents.Add((i,j));
                }           
            } 
        }
        return adjacents;
    }

    //Returns true if a square is empty and adjacent to a color
    private bool isAdjacent(int x,int y, TileType[][] matrix,int begin,int end){
        if(matrix[x][y] == TileType.Empty){
            if(x+1 < end){
                if(matrix[x+1][y] != TileType.Empty) return true;
            } if(x-1 >= 0){
                if(matrix[x-1][y] != TileType.Empty) return true;
            } if(y+1 < end){
                if(matrix[x][y+1] != TileType.Empty) return true;
            } if(y-1 >= 0){
                if(matrix[x][y-1] != TileType.Empty) return true;
            }
        }
        return false;
    }

    private bool isAdjacentColor(int x,int y,TileType tile, TileType[][] matrix,int begin,int end){
        if(matrix[x][y] == TileType.Empty){
            if(x+1 < end){
                if(matrix[x+1][y] == tile) return true;
            } if(x-1 >= 0){
                if(matrix[x-1][y] == tile) return true;
            } if(y+1 < end){
                if(matrix[x][y+1] == tile) return true;
            } if(y-1 >= 0){
                if(matrix[x][y-1] == tile) return true;
            }
        }
        return false;
    }


    /*public void unfold(TileType[][] matrix){
        List<TileType> colors = puzzleColors(matrix);
        foreach (TileType color in colors){
            int symetricAxis = canUnfoldUp(matrix,color);
            if(symetricAxis  != -1) undoMoveUp(color,matrix);
        }      
    }*/

    

      public TileType[][] generateRandomPuzzle(int size,int numberColors){

        System.Random rnd = new System.Random();
        TileType[][] matrix = new TileType[size][];
        List<TileType> colors = getColorArray(numberColors);

        for (int i = 0; i < size; i++){
            TileType[] line = new TileType[size];
            for (int j = 0; j < size; j++){
                TileType random = getRandomTileType(colors,rnd);
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



    private int  canUnfoldUp(TileType[][] matrix,TileType tile){
        int symetricAxis = calculateVerticalSymetrixAxis(tile,matrix);
        for (int i = 0; i < symetricAxis; i++){
            for (int j = 0; j < matrix[i].Length; j++){
                if(tile == matrix[i][j]){
                    if(tile != matrix[symetricAxis][j]){
                        Debug.Log("Cant unfold up");
                        return -1;
                    }
                        
                }
            }
            
        }
        return symetricAxis;
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
}