using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace The_Game_of_Life_2
{
    class Board
    {
        public int width = 780;
        public int height = 360;
        

        

        public int scrollValue = 1;
        public List<List<Particle>> board = new List<List<Particle>>();
        Random rand = new Random();

        public Board()
        {
            resize();
        }

        public void resize()
        {
            board.Clear();

            for (int i = 0; i < width; i++)
            {
                List<Particle> newCol = new List<Particle>();
                board.Add(newCol);
                for (int j = 0; j < height; j++)
                {
                    board[i].Add(new Particle(false));

                }
            }
        }

        public void Tick()
        {
            List<List<Particle>> newBoard = kamiClone(board);
            //List<List<Particle>> newBoard = DeepCopy(board);


            for(int i = width - 1; i >= 0; i--)
            {
                for(int j = height -1 ; j >= 0;j--)
                { 
                    if(board[i][j].val)
                    {
                        if(ableToGoDown(i, j))
                        {
                            board[i][j].val = false;
                            newBoard[i][j].val = false;
                            board[i][j+1].val = true;
                        }
                        else
                        {
                            if(rand.NextDouble() >0.5 )
                            {
                                if(ableToGoBL(i, j))
                                {
                                    board[i][j].val = false;
                                    newBoard[i][j].val = false;
                                    board[i-1][j+1].val = true;
                                }
                                else if(ableToGoBR(i, j))
                                {
                                    board[i][j].val = false;
                                    newBoard[i][j].val = false;
                                    board[i+1][j+1].val = true;
                                
                                }
                            }
                            else
                            {
                                if(ableToGoBR(i, j))
                                {
                                    board[i][j].val = false;
                                    newBoard[i][j].val = false;
                                    board[i+1][j+1].val = true;
                                }
                                else if(ableToGoBL(i, j))
                                {
                                    board[i][j].val = false;
                                    newBoard[i][j].val = false;
                                    board[i-1][j+1].val = true;
                                }
                            }

                            


                        }


                    }
                    
                }

            }
            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if(board[i][j].val)
                    {
                      

                    }                    
                }
            }
            //board = newBoard;
        }

        public bool ableToGoDown(int x, int y)
        {
            return (y + 1 < height && !board[x][y + 1].val);
        }

        public bool ableToGoBL(int x, int y)
        {
            return (y+1 < height && x - 1 >= 0 && !board[x - 1][y + 1].val);
        }
        public bool ableToGoBR(int x, int y)
        {
            return (y+1 < height && x + 1 < width && !board[x + 1][y + 1].val);
        }





        public int getNumAdjacent(int x, int y)
        {
            int numAdj = 0;

            for(int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) 
                        continue;

                    if (y + j < 0 || x + i < 0 || y + j >= height ||x + i >= width)
                    {

                    }
                    else
                    {
                        if( board[x+i][y+j].val )
                        {
                            numAdj++;
                        }
                    }
                }
            }

            if(numAdj != 0)
                Console.WriteLine(numAdj);
            return numAdj;


        }

        public void changeSize(int h, int w)
        {
            width = h;
            height = w;

            resize();
        }

        public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }

        public static List<List<Particle>> kamiClone(List<List<Particle>> old)
        {
            List<List<Particle>> clone = new List<List<Particle>>();

            foreach (List<Particle> i in old)
            {
                List<Particle> clonedList = new List<Particle>();
                foreach(Particle p in i)
                {
                    Particle clonedParticle = new Particle(p.x, p.y, p.val);
                    clonedList.Add(clonedParticle);
                }
                clone.Add(clonedList);
            }



            return clone;
        }
    }

    
}

