using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Collections;


public class Generator
{
    private int count = 0;
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

    //Falta nao so por tudo a null como cortar a matriz
    //Por em ordem random
    public TileType[][] generatePuzzle(int size,int numberColors,int numberMoves){
 
        System.Random rnd = new System.Random();
        TileType[][] matrix = new TileType[size*2][];
        //Get random color array
        List<TileType> colors = getColorArray(numberColors);
        List<List<(int,int)>> puzzle = new List<List<(int, int)>>();
        int begin = size - size / 2;
        int end = size + size / 2;

        //Initialize Matrix
        for (int i = 0; i < size * 2; i++){
            TileType[] line = new TileType[size * 2];
            for (int j = 0; j < size * 2; j++)
                line[j] = TileType.Empty;
            matrix[i] = line;
        }

        int x = UnityEngine.Random.Range(begin, end);
        int y = UnityEngine.Random.Range(begin, end);
        int numberMovesFirstColor = numberMoves/numberColors;
        int initialSize = (int) Math.Pow(((size*size)/numberColors),1.0/numberMovesFirstColor);
        
        //Generates first color and adds it to puzzle
        puzzle.Add(generateXAdjacentSqares(matrix,colors[0],initialSize,begin,end,x,y));

    
        //Moves color some moves
        moveColor(colors[0],numberMovesFirstColor,matrix);
        displayConsole(matrix);


        for (int i = 1; i < colors.Count; i++){
            List<(int,int)> adjacent = getAdjacent(matrix, begin,end);
            int index = UnityEngine.Random.Range(0, adjacent.Count);
            x = adjacent[index].Item1;
            y = adjacent[index].Item2;
            puzzle.Add(generateXAdjacentSqares(matrix,colors[i],initialSize,begin,end,x,y));
            moveColor(colors[i],numberMovesFirstColor,matrix);
        }

        int minX = size*2,minY = size*2,maxX = 0,maxY=0;
    
        //Set other elements to null Matrix
        for (int i = 0; i < size * 2 ; i++){
            for (int j = 0; j < size * 2; j++){
                if(matrix[i][j] == TileType.Empty)
                    matrix[i][j] = TileType.Null;
                else{
                    if(i <= minX) minX = i;
                    if(i >= maxX) maxX = i;
                    if(j <= minY) minY = j;
                    if(j >= maxY) maxY = j;
                }
            } 
        }

        Debug.Log(minX + " " + maxX + " " + minY + " " + maxY);

        //TileType[][] sliced =  sliceMatrix(matrix,minX,minY,maxX,maxY);

        createInitialMatrix(puzzle,colors,minX,minY,maxX,maxY,matrix);
        
        return matrix;
    }
    private TileType[][] sliceMatrix(TileType[][] matrix,int minX,int minY,int maxX,int maxY){
        int size;
        if (maxX-minX >= maxY-minY) size = maxX-minX+1;
        else size = maxY -minY+1;

        if(minX < minY) 

        Debug.Log(size);
        TileType[][] result = new TileType[size][];

            //Initialize Matrix
        for (int i = minX; i < minX + size; i++){
            TileType[] line = new TileType[size];
            for (int j = minY; j < minY + size; j++){
                Debug.Log("i:" + i + " j:" + j+ " "+ matrix[i].Length + " " + matrix.Length);
                TileType current = matrix[i][j];
                line[j-minY] = current ;
            }
            result[i-minX] = line;
        }
        displayConsole(result);
        return result;
    }

    private void createInitialMatrix(List<List<(int,int)>> puzzle,List<TileType> colors,int minX,int minY,int maxX,int maxY,TileType[][] matrix){

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if(matrix[i][j] != TileType.Null){
                    matrix[i][j] = TileType.Empty;
                }
            }
            
        }
        for (int i = 0; i < puzzle.Count; i++){
            for (int j = 0; j < puzzle[i].Count; j++){
                int x = puzzle[i][j].Item1;
                int y = puzzle[i][j].Item2;
                matrix[x][y] = colors[i];
            }            
        }

    }

    //Falta ir trocando a ordem dos moves
    private void moveColor(TileType color,int numberMoves,TileType[][] matrix){
        count = 0;
        bool foundMove = true;
        while(count < numberMoves && foundMove){
            int zas = count;
            foundMove = true;

            //var list = new List<Action> { moveUp, moveDown, moveLeft,moveRight };
            //list.Shuffle();
            //list.ForEach(method => method());
            if(zas == count) foundMove = false;
            if(moveUp(color,matrix)) count++;
            else if(moveDown(color,matrix)) count++;
            else if(moveLeft(color,matrix)) count++;
            else if(moveRight(color,matrix)) count++;
            else{foundMove = false;}
        }
    }

    //Gera x Quadrados adjacentes
    //Retorna as posiçoes dos quadrados gerados
    private List<(int,int)> generateXAdjacentSqares(TileType[][] matrix,TileType tile, int number,int begin,int end,int i,int j){

        System.Random rnd = new System.Random();
        List<(int,int)> result = new List<(int, int)>();
        List<(int,int)> adjacent = new List<(int, int)>();
        for (int k = 0; k < number; k++)
        {
            matrix[i][j] = tile;  
            result.Add((i,j));
            //adjacent = getAdjacent(i,j,matrix,begin,end); //Ao usar isto ele vai estar a procurar em filinha, a alternativa e percorrer tudo
            adjacent = getAdjacent(tile,matrix,begin,end); //Percorre a matriz toda
            if(adjacent.Count > 0){
                int index = rnd.Next(adjacent.Count);
                i = adjacent[index].Item1;
                j = adjacent[index].Item2;  
            }
            
        }


        return result;
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


    public bool moveUp(TileType tile,TileType[][] puzzleMatrix)
    {
        int rotationAxis = puzzleMatrix.Length;
        bool foundAxis = false;

        //Discover the rotation axis
        for (int i = 0; (i < puzzleMatrix.Length) && (!foundAxis); i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    rotationAxis = i;
                    foundAxis = true;
                    break;
                }
            }
        }

        List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = rotationAxis; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (tile == puzzleMatrix[i][j])
                {
                    int symetricX = i - 2 * (i - rotationAxis) - 1;
                    if (canMove(symetricX, j,puzzleMatrix)){
                        positions.Add(Tuple.Create(symetricX, j));
                    }
                    else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++){
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }
        count++;

        return true;
    }

    public bool moveDown(TileType tile,TileType[][] puzzleMatrix)
    {
        int rotationAxis = -1;
        bool foundAxis = false;

        //Discover the rotation axis
        for (int i = puzzleMatrix.Length - 1; (i >= 0) && (!foundAxis); i--)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    rotationAxis = i;
                    foundAxis = true;
                    break;
                }
            }
        }

        List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = 0; i <= rotationAxis; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                if (tile == puzzleMatrix[i][j])
                {
                    int symetricX = i + 2 * (rotationAxis - i) + 1;
                    if (canMove(symetricX, j,puzzleMatrix))
                    {
                        positions.Add(Tuple.Create(symetricX, j));
                    }
                    else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++)
        {
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }
        count++;


        return true;
    }

    public bool moveLeft(TileType tile,TileType[][] puzzleMatrix)
    {

        int rotationAxis = puzzleMatrix.Length;

        bool foundAxis = false;

        //Discover the rotation axis
        for (int j = 0; (j < puzzleMatrix[0].Length) && (!foundAxis); j++)
        {
            for (int i = 0; i < puzzleMatrix.Length; i++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    rotationAxis = j;
                    foundAxis = true;
                    break;
                }
            }
        }

        List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = rotationAxis; j < puzzleMatrix[i].Length; j++)
            {
                if (tile == puzzleMatrix[i][j])
                {
                    int symetricY = j - 2 * (j - rotationAxis) - 1;
                    if (canMove(i, symetricY,puzzleMatrix))
                    {
                        positions.Add(Tuple.Create(i, symetricY));
                    }
                    else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++)
        {
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        count++;


        return true;
    }

    public bool moveRight(TileType tile,TileType[][] puzzleMatrix)
    {
        int rotationAxis = -1;
        bool foundAxis = false;

        //Discover the rotation axis
        for (int j = puzzleMatrix[0].Length - 1; (j >= 0) && (!foundAxis); j--)
        {
            for (int i = 0; i < puzzleMatrix.Length; i++)
            {
                if (puzzleMatrix[i][j] == tile)
                {
                    rotationAxis = j;
                    foundAxis = true;
                    break;
                }
            }
        }

        List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j <= rotationAxis; j++)
            {
                if (tile == puzzleMatrix[i][j])
                {
                    int symetricY = j + 2 * (rotationAxis - j) + 1;
                    if (canMove(i, symetricY,puzzleMatrix))
                    {
                        positions.Add(Tuple.Create(i, symetricY));
                    }
                    else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++)
        {
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        count++;


        return true;
    }
  

    public bool canMove(int i, int j,TileType[][] puzzleMatrix)
    {
        if (i < puzzleMatrix.Length && i >= 0)
        {
            if (j >= 0 && j < puzzleMatrix[i].Length)
            {
                if (puzzleMatrix[i][j] == TileType.Empty) return true;
            }
        }
        return false;
    }

    public void writeMatrix(TileType[][] matrix){
        using (TextWriter tw = new StreamWriter("GeneratedMatrix.txt"))
            {
                tw.Write(matrix.Length + " " +  matrix[0].Length);
                tw.WriteLine();

                for (int j = 0; j < matrix.Length; j++)
                {
                    for (int i = 0; i < matrix[j].Length; i++)
                    {
                        tw.Write(matrix[j][i] + " ");
                    }
                    tw.WriteLine();
                }
            }
    }

    public TileType[][] readMatrix(){

        //TileType[][] matrix;
        String input = File.ReadAllText( "GeneratedMatrix.txt" );

        int i = 0, j = 0;

        List<List<TileType>> tileTypesList = new List<List<TileType>>();


        foreach (var row in input.Split('\n'))
        {
            List<TileType> tileTypes = new List<TileType>();
            j = 0;
            foreach (var col in row.Trim().Split(' '))
            {
                tileTypes.Add(parseTiletype(col.Trim()));
                j++;
            }
            tileTypesList.Add(tileTypes);
            i++;
        }
        tileTypesList.RemoveAt(tileTypesList.Count-1);

        TileType[][] matrix = new TileType[tileTypesList.Count][];

        //Debug.Log(tileTypesList.Count + " " + tileTypesList[tileTypesList.Count-1][tileTypesList[tileTypesList.Count-1].Count-1]);
        Debug.Log(tileTypesList[11][11] + "ZAS");

        for (int k = 0; k < tileTypesList.Count; k++)
        {
            for (int l = 0; l < tileTypesList[0].Count; l++)
            {
                matrix[k][l] = tileTypesList[k][l];
                //Debug.Log(k +" "+ l);
                //TileType ti = tileTypesList[k][l];

                
            }
        }

        return matrix;
    }


    /*public void unfold(TileType[][] matrix){
        List<TileType> colors = puzzleColors(matrix);
        foreach (TileType color in colors){
            int symetricAxis = canUnfoldUp(matrix,color);
            if(symetricAxis  != -1) undoMoveUp(color,matrix);
        }      
    }*/


    private TileType parseTiletype(string zas){
        switch(zas){
            case "Null":
                return TileType.Null;
            case "Blue":
                return TileType.Blue;
            case "Empty":
                return TileType.Empty;
            case "Gray":
                return TileType.Gray;
            case "Green":
                return TileType.Green;
            case "Magenta":
                return TileType.Magenta;
            case "Red":
                return TileType.Red;
            case "Yellow":
                return TileType.Yellow; 
        }
        return TileType.Null;
    }
}