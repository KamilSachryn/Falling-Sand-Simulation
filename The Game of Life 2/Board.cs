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
        public int width = 780/4;
        public int height = 360/2;
        

        

        public int scrollValue = 1;
        public List<List<Particle>> board = new List<List<Particle>>();
        Random rand = new Random();
        public List<Particle> particles = new List<Particle>();


        ParticleSameCoords comparer = new ParticleSameCoords();

        public Board()
        {
            resize();

            List<List<Particle>> newBoard = new List<List<Particle>>();

            for (int i = width - 1; i >= 0; i--)
            {
                List<Particle> temp = new List<Particle>();
                for (int j = height - 1; j >= 0; j--)
                {
                    temp.Add(null);

                }
                newBoard.Add(temp);
            }

            board = newBoard;
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
                    board[i].Add(new Particle(i, j, false));

                }
            }
        }

        public void Tick()
        {




            //List<List<Particle>> newBoard = kamiClone(board);
            //List<List<Particle>> prototypeBoard = new List<List<Particle>>();
            //List<List<Particle>> newBoard = DeepCopy(board);

            foreach (Particle p in particles)
            {
                int i = p.x;
                int j = p.y;
                if (ableToGoDown(p))
                {
                    p.y += 1;
                }
                else
                {
                    if (rand.NextDouble() > 0.5)
                    {
                        if (ableToGoBL(p))
                        {
                            p.x -= 1;
                            p.y += 1;
                        }
                        else if (ableToGoBR(p))
                        {

                            p.x += 1;
                            p.y += 1;

                        }
                    }
                    else
                    {
                        if (ableToGoBR(p))
                        {
                            p.x += 1;
                            p.y += 1;
                        }
                        else if (ableToGoBL(p))
                        {
                            p.x -= 1;
                            p.y += 1;
                        }
                    }




                }
              
            }

        }

        public bool ableToGoDown(int x, int y)
        {
            return (y + 1 < height && (board[x][y+1] == null ||!board[x][y + 1].val));
        }

        public bool ableToGoDown(Particle p)
        {

            return (p.y + 1 < height && !particles.Contains(new Particle(p.x, p.y + 1, true), comparer));

        }

        public bool ableToGoBL(int x, int y)
        {
            return (y+1 < height && x - 1 >= 0 && (board[x-1][y + 1] == null ||  !board[x - 1][y + 1].val));
            
        }
        public bool ableToGoBL(Particle p)
        {
            return (p.y + 1 < height && p.x - 1 >= 0 && !particles.Contains(new Particle(p.x - 1, p.y + 1, true), comparer));

        }
        
        public bool ableToGoBR(int x, int y)
        {
            return (y+1 < height && x + 1 < width && (board[x+1][y + 1] == null || !board[x + 1][y + 1].val));
        }
        public bool ableToGoBR(Particle p)
        {
            return (p.y + 1 < height && p.x + 1 >= 0 && !particles.Contains(new Particle(p.x + 1, p.y + 1, true), comparer));
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

