using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Model
{
    [Serializable]
    public class Crossword
    {
        const string Letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz";
        readonly int[,] _hWords;
        readonly int[,] _vWords;
        readonly int[] _dirX = { 0, 1 };
        readonly int[] _dirY = { 1, 0 };
        private char[,] _board;
        int _hCount, _vCount;
        private static IList<string> _wordsToInsert;
        private static char[,] _tempBoard;
        private static int _bestSolution;
        DateTime initialTime;
        Random _rand = new Random();
        private List<string> temp = new List<string>();

        public char this[int i, int j]
        {
            get{ return _board[i, j]; }
            set{ _board[i, j] = value; }
        }

        public int N { get; set; }

        public int M { get; set; }

        public char[,] GetBoard
        {
            get { return _board; }
            set { _board = value; }
        }

        public List<string> Temp
        {
            get { return temp; }
            set { temp = value; }
        }

        public Dictionary<string, string> defHorDict = new Dictionary<string, string>();

        public Dictionary<string, string> defVerDict = new Dictionary<string, string>();

        public Crossword() {}

        public Crossword(int xDimen, int yDimen)
        {
            _board = new char[xDimen, yDimen];
            _hWords = new int[xDimen, yDimen];
            _vWords = new int[xDimen, yDimen];
            N = xDimen;
            M = yDimen;
            _rand = new Random();

            for (var i = 0; i < N; i++)
                for (var j = 0; j < M; j++)
                    _board[i, j] = ' ';
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result += Letters.Contains(_board[i, j].ToString()) ? _board[i, j] : ' ';
                }
                if (i < N - 1)
                    result += '\n';
            }
            return result;
        }

        bool IsValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < N && y < M;
        }

        int CanBePlaced(string word, int x, int y, int dir)
        {
            var result = 0;
            if (dir == 0)
            {
                for (var j = 0; j < word.Length; j++)
                {
                    int x1 = x, y1 = y + j;
                    if (!(IsValidPosition(x1, y1) && (_board[x1, y1] == ' ' || _board[x1, y1] == word[j]))) //выход за границы или позиция занята, тогда -1
                        return -1;
                    if (IsValidPosition(x1 - 1, y1))
                        if (_hWords[x1 - 1, y1] > 0) //рядом позиция с буквой => вставлять нельзя => -1
                            return -1;
                    if (IsValidPosition(x1 + 1, y1))
                        if (_hWords[x1 + 1, y1] > 0) //рядом позиция с буквой => вставлять нельзя => -1
                            return -1;
                    if (_board[x1, y1] == word[j]) //считаем кол-во пересечений
                        result++;
                }
            }

            else
            {
                for (var j = 0; j < word.Length; j++)
                {
                    int x1 = x + j, y1 = y;
                    if (!(IsValidPosition(x1, y1) && (_board[x1, y1] == ' ' || _board[x1, y1] == word[j]))) //выход за границы или позиция занята, тогда -1
                        return -1;
                    if (IsValidPosition(x1, y1 - 1))
                        if (_vWords[x1, y1 - 1] > 0) //рядом позиция с буквой => вставлять нельзя => -1
                            return -1;
                    if (IsValidPosition(x1, y1 + 1))
                        if (_vWords[x1, y1 + 1] > 0) //рядом позиция с буквой => вставлять нельзя => -1
                            return -1;
                    if (_board[x1, y1] == word[j]) //считаем кол-во пересечений
                        result++;
                }
            }

            int xStar = x - _dirX[dir], yStar = y - _dirY[dir];
            if (IsValidPosition(xStar, yStar))
                if (!(_board[xStar, yStar] == ' ' || _board[xStar, yStar] == '*'))
                    return -1;

            xStar = x + _dirX[dir] * word.Length;
            yStar = y + _dirY[dir] * word.Length;
            if (IsValidPosition(xStar, yStar))
                if (!(_board[xStar, yStar] == ' ' || _board[xStar, yStar] == '*')) //позиция занята
                    return -1;

            return result == word.Length ? -1 : result;

        }

        void PutWord(string word, int x, int y, int dir, int value)
        {
            var mat = dir == 0 ? _hWords : _vWords;

            for (var i = 0; i < word.Length; i++)
            {
                int x1 = x + _dirX[dir] * i, y1 = y + _dirY[dir] * i;
                _board[x1, y1] = word[i];
                mat[x1, y1] = value;
            }

            int xStar = x - _dirX[dir], yStar = y - _dirY[dir];
            if (IsValidPosition(xStar, yStar)) _board[xStar, yStar] = '*';
            xStar = x + _dirX[dir] * word.Length;
            yStar = y + _dirY[dir] * word.Length;
            if (IsValidPosition(xStar, yStar)) _board[xStar, yStar] = '*';
        }

        public int AddWord(string word, string def)
        {
            var wordToInsert = word;
            var info = BestPosition(wordToInsert);
            if (info != null)
            {
                if (info.Item3 == 0)
                    _hCount++;
                else
                    _vCount++;
                var value = info.Item3 == 0 ? _hCount : _vCount;
                PutWord(wordToInsert, info.Item1, info.Item2, info.Item3, value);

                if (info.Item3 == 0)
                {
                    defHorDict.Add(word, def);
                }
                else if (info.Item3 == 1)
                {
                    defVerDict.Add(word, def);
                }

                return info.Item3;
            }
            return -1;
        }

        public int AddWord(string word, string def, int x, int y, int dir)
        {
            if (dir == 0)
                _hCount++;
            else
                _vCount++;
            var value = dir == 0 ? _hCount : _vCount;
            PutWord(word, x, y, dir, value);

            if (dir == 0)
            {
                defHorDict.Add(word, def);
            }
            else if (dir == 1)
            {
                defVerDict.Add(word, def);
            }

            return dir;
        }

        List<Tuple<int, int, int>> FindPositions(string word)
        {
            var max = 0;
            var positions = new List<Tuple<int, int, int>>();
            for (var x = 0; x < N; x++)
            {
                for (var y = 0; y < M; y++)
                {
                    for (var i = 0; i < _dirX.Length; i++)
                    {
                        var dir = i;
                        var wordToInsert = word;
                        var count = CanBePlaced(wordToInsert, x, y, dir);

                        if (count < max)
                            continue;  //если кол-во позиций <, чем уже было, то идем на сл итерацию    
                        if (count > max)            //очищаем весь список позиций, если нашли позиции для вставки, где их больше всего
                            positions.Clear();
                        max = count;
                        positions.Add(new Tuple<int, int, int>(x, y, dir));
                    }
                }
            }
            if (max == 0 && !Temp[0].Equals(word))
                positions.Clear();
            return positions;
        }

        Tuple<int, int, int> BestPosition(string word)
        {
            var positions = FindPositions(word);
            if (positions.Count > 0)
            {
                var index = _rand.Next(positions.Count);
                return positions[index];
            }
            return null;
        }

        public bool IsLetter(char a)
        {
            return Letters.Contains(a.ToString());
        }

        public void Reset()
        {
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    _board[i, j] = ' ';
                    _vWords[i, j] = 0;
                    _hWords[i, j] = 0;
                    _hCount = _vCount = 0;
                }
            }
            defHorDict.Clear();
            defVerDict.Clear();
        }

        public void AddWords(IList<string> words)
        {
            _wordsToInsert = words;
            _bestSolution = N * M;
            initialTime = DateTime.Now;
            Gen(0);

            _board = _tempBoard;
        }

        int FreeSpaces()
        {
            var count = 0;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (_board[i, j] == ' ' || _board[i, j] == '*')
                        count++;
                }
            }
            return count;
        }

        void Gen(int pos)
        {
            if (pos >= _wordsToInsert.Count || (DateTime.Now - initialTime).Minutes > 1)
                return;

            for (int i = pos; i < _wordsToInsert.Count; i++)
            {
                var posi = BestPosition(_wordsToInsert[i]);
                if (posi != null)
                {
                    var word = _wordsToInsert[i];

                    var value = posi.Item3 == 0 ? _hCount : _vCount;
                    PutWord(word, posi.Item1, posi.Item2, posi.Item3, value);
                    Gen(pos + 1);
                    RemoveWord(word, posi.Item1, posi.Item2, posi.Item3);
                }
                else
                {
                    Gen(pos + 1);
                }
            }
            var c = FreeSpaces();
            if (c >= _bestSolution) return;
            _bestSolution = c;
            _tempBoard = _board.Clone() as char[,];
        }

        private void RemoveWord(string word, int x, int y, int dir)
        {
            var mat = dir == 0 ? _hWords : _vWords;
            var mat1 = dir == 0 ? _vWords : _hWords;
            for (var i = 0; i < word.Length; i++)
            {
                int x1 = x + _dirX[dir] * i, y1 = y + _dirY[dir] * i;
                if (mat1[x1, y1] == 0)
                    _board[x1, y1] = ' ';
                mat[x1, y1] = 0;
            }

            int xStar = x - _dirX[dir], yStar = y - _dirY[dir];
            if (IsValidPosition(xStar, yStar) && HasFactibleValueAround(xStar, yStar))
                _board[xStar, yStar] = ' ';

            xStar = x + _dirX[dir] * word.Length;
            yStar = y + _dirY[dir] * word.Length;
            if (IsValidPosition(xStar, yStar) && HasFactibleValueAround(xStar, yStar))
                _board[xStar, yStar] = ' ';
        }

        bool HasFactibleValueAround(int x, int y)
        {
            for (var i = 0; i < _dirX.Length; i++)
            {
                int x1 = x + _dirX[i], y1 = y + _dirY[i];
                if (IsValidPosition(x1, y1) && (_board[x1, y1] != ' ' || _board[x1, y1] == '*'))
                    return true;
                x1 = x - _dirX[i];
                y1 = y - _dirY[i];
                if (IsValidPosition(x1, y1) && (_board[x1, y1] != ' ' || _board[x1, y1] == '*'))
                    return true;
            }
            return false;
        }
    }
}
