using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurnbacedTileEngine
{
    public class Map
    {
        Vector2 m_LevelBounds;
        Tile[,] m_Map;
        int xOffset = 0;
        int yOffset = 0;
        public Map(int pWidth, int pHeight)
        {
            m_LevelBounds = new Vector2(pWidth, pHeight);
            m_Map = GenerateMap();
        }
        public Map(int pWidth, int pHeight, int pxOffset, int pyOffset)
        {
            xOffset = pxOffset;
            yOffset = pyOffset;
            m_LevelBounds = new Vector2(pWidth, pHeight);
            m_Map = GenerateMap();
        }
        public Tile[,] GenerateMap()
        {
            Tile[,] m_TileMap = new Tile[(int)m_LevelBounds.X,(int)m_LevelBounds.Y];
            Random RNG = new Random();
            /*
             set the tile map up after the int map, the int map should be designed in a stat of hexigons with an offset of half the width
             ***********
              *********
             ***********
             */
            int y = 0;
            goto LongLine;
            //goto ShortLine;
        LongLine:
            for(int x = 0; x < m_TileMap.GetLength(1); x++)
            {
                Marker:
                switch (RNG.Next(3))
                {


                    case 1:
                        m_TileMap[y, x] = new Rough(xOffset + x * 64,yOffset + y * 64);
                        break;
                    case 2:
                        if(x == 0 || x == m_TileMap.GetLength(1) || y == 0 || y == m_TileMap.GetLength(0))
                        {
                            goto Marker;
                        }
                        break;
                    
                    default:
                        m_TileMap[y, x] = new Land(xOffset + x * 64,yOffset + y * 64);
                        break;

                }                
                if(y != m_TileMap.GetLength(0) - 1 && x == m_TileMap.GetLength(1) - 1)
                {
                    y++;
                    goto ShortLine;
                }
                
            }
            goto Escape;
        ShortLine:
            for(int x = 1; x < m_TileMap.GetLength(1); x++)
            {
                Marker:
                switch (RNG.Next(10))
                {


                    
                    case 1:
                        if (x > m_TileMap.GetLength(1) / 2)
                        {
                            m_TileMap[y, x] = new Rough(xOffset + x * 64,yOffset + y * 64,shift.Right);
                        }
                        else
                        {
                            m_TileMap[y, x] = new Rough(xOffset + x * 64, yOffset + y * 64, shift.Left);

                        }
                        break;
                    case 2:
                        if (x == 1 || x == m_TileMap.GetLength(1) - 1 || y == 0 || y == m_TileMap.GetLength(0))
                        {
                            goto Marker;
                        }
                        break;
                    
                        
                    default:
                        if (x > m_TileMap.GetLength(1) / 2)
                        {
                            m_TileMap[y, x] = new Land(xOffset + x * 64,yOffset + y * 64, shift.Right);
                        }
                        else
                        {
                            m_TileMap[y, x] = new Land(xOffset + x * 64,yOffset + y * 64, shift.Left);

                        }
                        break;
                        

                }

                if (y != m_TileMap.GetLength(0) - 1 && x == m_TileMap.GetLength(1) - 1)
                {
                    y++;
                    goto LongLine;
                }
                
            }
            goto Escape;
        Escape:
            return m_TileMap;
        }
        public void Draw(SpriteBatch pSpriteBatch)
        { 
            for (int y = 0; y < m_Map.GetLength(0); y++)
            {
                for(int x = 0; x< m_Map.GetLength(1); x++)
                {
                    if(m_Map[y,x] != null)
                    m_Map[y, x].Draw(pSpriteBatch);
                }
            }
        }

        public void ReplaceTile(Tile pTile, int y, int x)
        {
            m_Map[y,x] = pTile;
        }
        public void Update()
        {
            for(int y = 0; y < m_Map.GetLength(0); y++)
            {
                for(int x = 0; x < m_Map.GetLength(1); x++)
                {
                    if(m_Map[y,x] != null)
                    m_Map[y, x].Update();
                }
            }
        }
        public Tile GetTile(Vector2 pPosition)
        {
            return m_Map[(int)pPosition.Y,(int) pPosition.X];
        }
        public int GetMapWidth()
        {
            return m_Map.GetLength(1);
        }
        public int GetMapHeight()
        {
            return m_Map.GetLength(0);
        }
        public Tile GetTile(int pX, int pY)
        {
            return m_Map[pY,pX ];
        }
    }
}
