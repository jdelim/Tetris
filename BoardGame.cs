using System.Collections.Generic;
namespace BoardGames
{
    #region Enumerators
    public enum TetrominoType
    {
        Line, T, L, ReverseL, S, Z, Square, Empty
    }
    public enum Space
    {
        Red, Yellow, Empty
    }
    public enum Position
    {
        X, O, Empty
    }
    public enum Turn
    {
        Player1, Player2
    }
    public enum GameState
    {
        Player1Win, Player2Win, Playing, Tie
    }
    #endregion
    #region Helpers
    public class Block
    {
        #region Fields
        private bool active;
        public TetrominoType color;
        #endregion
        #region Properties
        public bool isActive { get { return active; } }
        public bool makeActive { set { active = value; } }
        #endregion
        #region Constructors
        public Block()
        {
            active = false;
            color = TetrominoType.Empty;
        }
        public Block(TetrominoType current)
        {
            active = true;
            color = current;
        }
        #endregion
    }
    public class Coordinate
    {
        #region Fields
        private int _x;
        private int _y;
        #endregion
        #region Properties
        public int x 
        { 
            get { return _x; } 
        }
        public int y
        {
            get { return _y; }
        }
        #endregion
        #region Static Fields
        public static int x_limit = 7;
        public static int y_limit = 6;
        #endregion
        #region Constructors
        public Coordinate(int start_x, int start_y)
        {
            _x = start_x;
            _y = start_y;
        }
        #endregion
        #region Methods
        public bool inBounds()
        {
            if (x > x_limit - 1) return false;
            if (y > y_limit - 1) return false;
            if (x < 0) return false;
            if (y < 0) return false;
            return true;
        }
        public Coordinate[] Horizontal4()
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(this);
            output.Add(new Coordinate(x + 1, y));
            output.Add(new Coordinate(x + 2, y));
            output.Add(new Coordinate(x + 3, y));
            return output.ToArray();
        }
        public Coordinate[] Vertical4()
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(this);
            output.Add(new Coordinate(x, y + 1));
            output.Add(new Coordinate(x, y + 2));
            output.Add(new Coordinate(x, y + 3));
            return output.ToArray();
        }
        public Coordinate[] Diagonal4()
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(this);
            output.Add(new Coordinate(x + 1, y + 1));
            output.Add(new Coordinate(x + 2, y + 2));
            output.Add(new Coordinate(x + 3, y + 3));
            return output.ToArray();
        }
        public Coordinate[] ReverseDiagonal4()
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(this);
            output.Add(new Coordinate(x - 1, y + 1));
            output.Add(new Coordinate(x - 2, y + 2));
            output.Add(new Coordinate(x - 3, y + 3));
            return output.ToArray();
        }

        #endregion
        #region Static Methods
        public static bool inBounds(Coordinate place)
        {
            return place.inBounds();
        }
        public static bool inBounds(Coordinate[] set)
        {
            if (inBounds(set[0]) == false) return false;
            if (inBounds(set[1]) == false) return false;
            if (inBounds(set[2]) == false) return false;
            if (inBounds(set[3]) == false) return false;
            return true;
        }
        public static Coordinate[] Horizontal4(Coordinate start)
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(start);
            output.Add(new Coordinate(start.x + 1, start.y));
            output.Add(new Coordinate(start.x + 2, start.y));
            output.Add(new Coordinate(start.x + 3, start.y));
            return output.ToArray();
        }
        public static Coordinate[] Vertical4(Coordinate start)
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(start);
            output.Add(new Coordinate(start.x, start.y + 1));
            output.Add(new Coordinate(start.x, start.y + 2));
            output.Add(new Coordinate(start.x, start.y + 3));
            return output.ToArray();
        }
        public static Coordinate[] Diagonal4(Coordinate start)
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(start);
            output.Add(new Coordinate(start.x + 1, start.y + 1));
            output.Add(new Coordinate(start.x + 2, start.y + 2));
            output.Add(new Coordinate(start.x + 3, start.y + 3));
            return output.ToArray();
        }
        public static Coordinate[] ReverseDiagonal4(Coordinate start)
        {
            List<Coordinate> output = new List<Coordinate>();
            output.Add(start);
            output.Add(new Coordinate(start.x - 1, start.y + 1));
            output.Add(new Coordinate(start.x - 2, start.y + 2));
            output.Add(new Coordinate(start.x - 3, start.y + 3));
            return output.ToArray();
        }

        #endregion
    }
    #endregion
    #region Games
    public class Connect4
    {
        #region Fields
        public Space[,] Board;
        private Turn _Player;
        private GameState _CurrentState;
        #endregion
        #region Properties
        public Turn CurrentTurn
        {
            get { return _Player; }
        }
        public GameState CurrentState
        {
            get { return _CurrentState; }
        }
        #endregion
        #region Constructor
        public Connect4()
        {
            Board = new Space[7, 6];
            for(int col = 0; col < 7; col++) 
            { 
                for(int row = 0; row < 6; row++)
                {
                    Board[col, row] = Space.Empty;
                }
            }
            _Player = Turn.Player1; 
            _CurrentState = GameState.Playing;
            Coordinate.x_limit = 7;
            Coordinate.y_limit = 6;
        }
        #endregion
        public Coordinate Place(int x_pos)
        {
            if (Board[x_pos, 5] == Space.Empty) return new Coordinate(x_pos, 5);
            if (Board[x_pos, 4] == Space.Empty) return new Coordinate(x_pos, 4);
            if (Board[x_pos, 3] == Space.Empty) return new Coordinate(x_pos, 3);
            if (Board[x_pos, 2] == Space.Empty) return new Coordinate(x_pos, 2);
            if (Board[x_pos, 1] == Space.Empty) return new Coordinate(x_pos, 1);
            if (Board[x_pos, 0] == Space.Empty) return new Coordinate(x_pos, 0);
            return new Coordinate(-1, -1);
        }
        public void Move(int x_pos)
        {
            Coordinate Position = Place(x_pos);
            bool Legal = Position.inBounds();
            if (!Legal) return;
            Board[Position.x, Position.y] = (Space) _Player;
            if (CheckForConnectFour() == true) _CurrentState = (GameState)_Player;
            else if (_Player == Turn.Player1) _Player = Turn.Player2;
            else _Player = Turn.Player1;
        }
        public bool CheckForConnectFour()
        {
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 6; row++)
                {
                    if (CheckForConnectFour(new Coordinate(col, row))) return true;
                }
            }
            isTie();
            return false;
        }
        public bool isTie()
        {
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 6; row++)
                {
                    if (Board[col, row] == Space.Empty) return false;
                }
            }
            _CurrentState = GameState.Tie;
            return true;
        }
        public bool CheckForConnectFour(Coordinate Place)
        {
            Coordinate[] HorizontalS = Coordinate.Horizontal4(Place);
            Coordinate[] VerticalS = Coordinate.Vertical4(Place);
            Coordinate[] DiagonalS = Coordinate.Diagonal4(Place);
            Coordinate[] ReverseDiagonalS = Coordinate.ReverseDiagonal4(Place);
            Coordinate[] Horizontal = Place.Horizontal4();
            Coordinate[] Vertical = Place.Vertical4();
            Coordinate[] Diagonal = Place.Diagonal4();
            Coordinate[] ReverseDiagonal = Place.ReverseDiagonal4();
            if (CheckLine(HorizontalS)) return true;
            if (CheckLine(VerticalS)) return true;
            if (CheckLine(DiagonalS)) return true;
            if (CheckLine(ReverseDiagonalS)) return true;
            if (CheckLine(Horizontal)) return true;
            if (CheckLine(Vertical)) return true;
            if (CheckLine(Diagonal)) return true;
            if (CheckLine(ReverseDiagonal)) return true;
            return false;
        }
        public bool CheckLine(Coordinate[] line)
        {
            if(Coordinate.inBounds(line) == false) return false;
            Space Winner = Board[line[0].x, line[0].y];
            if (Winner == Space.Empty) return false;
            if (Board[line[1].x, line[1].y] != Winner) return false;
            if (Board[line[2].x, line[2].y] != Winner) return false;
            if (Board[line[3].x, line[3].y] != Winner) return false;
            return true;
        }
    }
    public class TicTacToe
    {
        #region Fields
        public Position[,] Board;
        private Turn _Player;
        private GameState _CurrentState;
        #endregion
        #region Properties
        public Turn Player
        {
            get { return _Player; }
        }
        public GameState CurrentState
        {
            get { return _CurrentState; }
        }
        #endregion
        #region Constructors
        public TicTacToe() 
        {
            Board = new Position[3, 3];
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    Board[col, row] = Position.Empty;
                }
            }
            _Player = Turn.Player1;
            _CurrentState = GameState.Playing;
        }
        #endregion
        public void Move(int x, int y)
        {
            if (Board[x, y] != Position.Empty) return;
            if (_CurrentState != GameState.Playing) return;
            Board[x, y] = (Position) Player;
            if(!Winner())
            {
                if (_Player == Turn.Player1) _Player = Turn.Player2;
                else _Player = Turn.Player1;
            }
        }
        public bool Winner()
        {
            if (CheckRow(0)) return true;
            if (CheckRow(1)) return true;
            if (CheckRow(2)) return true;
            if (CheckCol(0)) return true;
            if (CheckCol(1)) return true;
            if (CheckCol(2)) return true;
            if (Diag()) return true;
            if (ReverseDiag()) return true;
            if (isTie()) return false;
            return false;
        }
        public bool isTie()
        {
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (Board[col, row] == Position.Empty) return false;
                }
            }
            _CurrentState = GameState.Tie;
            return true;
        }
        public bool CheckRow(int row)
        {
            Position Winner = Board[0, row];
            if (Winner == Position.Empty) return false;
            if (Board[1, row] != Winner) return false;
            if (Board[2, row] != Winner) return false;
            _CurrentState = (GameState) Player;
            return true;
        }
        public bool CheckCol(int col)
        {
            Position Winner = Board[col, 0];
            if (Winner == Position.Empty) return false;
            if (Board[col, 1] != Winner) return false;
            if (Board[col, 2] != Winner) return false;
            _CurrentState = (GameState) Player;
            return true;
        }
        public bool Diag()
        {
            Position Winner = Board[0, 0];
            if (Winner == Position.Empty) return false;
            if (Board[1, 1] != Winner) return false;
            if (Board[2, 2] != Winner) return false;
            _CurrentState = (GameState) Player;
            return true;
        }
        public bool ReverseDiag()
        {
            Position Winner = Board[0, 2];
            if (Winner == Position.Empty) return false;
            if (Board[1, 1] != Winner) return false;
            if (Board[2, 0] != Winner) return false;
            _CurrentState = (GameState) Player;
            return true;
        }
    }
    public class Tetris
    {
        #region Fields
        public Block[,] Board;
        public int[] DestroyedRows;
        public int RowsDestroyed;
        #endregion
        #region Constructor
        public Tetris()
        {
            Board = new Block[10, 20];
            for (int row = 0; row < 20; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Board[col, row] = new Block();
                }
            }
            DestroyedRows = new int[0];
            Coordinate.x_limit = 10;
            Coordinate.y_limit = 20;
        }
        #endregion
        #region Methods
        #region Make Move
        //Method to place blocks
        public void Move(int x, int y, TetrominoType aColor)
        {
            Board[x, y] = new Block(aColor);
        }
        //Method Updates the Entire Game After Move Complete
        public void MoveComplete()
        {
            CheckBoard();
            AllClear();
            UpdateBoard();
            DestroyedRows = new int[0];
        }
        #endregion
        #region Line Detection
        //Method to detect one line of blocks
        bool DetectfullLineForOneLine(int row)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!Board[i, row].isActive)
                {
                    return false;
                }
            }
            return true;
        }
        //Method to Check Board for full lines
        public void CheckBoard()
        {
            List<int> ToBeDestroyed = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                if (DetectfullLineForOneLine(i))
                {
                    ToBeDestroyed.Add(i);
                }
            }
            foreach (int given in ToBeDestroyed) PrepareForDestruction(given);
            DestroyedRows = ToBeDestroyed.ToArray();
            RowsDestroyed = ToBeDestroyed.Count;
        }
        void PrepareForDestruction(int row)
        {
            for (int i = 0; i < 10; i++)
            {
                Board[i, row].color = (TetrominoType)0;
            }
        }
        #endregion
        #region Line Clear
        //Method Clears one line
        public void RowClear(int row)
        {
            for (int i = 0; i < 10; i++)
            {
                Board[i, row] = new Block();
            }
        }
        //Clears all rows on destroy list
        public void AllClear()
        {
            for (int i = 0; i < DestroyedRows.Length; i++)
            {
                RowClear(DestroyedRows[i]);
            }
        }
        #endregion
        #region Update After Clear
        //Moves one row down Correct Number of Blocks After Blocks Are Destroyed
        public void MoveDown(int row)
        {
            int fallcount = 0;
            foreach (int given in DestroyedRows) if (row > given) fallcount++;
            if (fallcount == 0) return;
            for (int i = 0; i < 10; i++)
            {
                Board[i, row - fallcount] = Board[i, row];      //Move the current row's contents down fallcount rows
                Board[i, row] = new Block();                    //Destroy the current row
            }
        }
        //Method which updates the board
        public void UpdateBoard()
        {
            for (int row = 0; row < 20; row++)
            {
                MoveDown(row);
            }
        }
        #endregion
        #endregion
    }
    #endregion
}