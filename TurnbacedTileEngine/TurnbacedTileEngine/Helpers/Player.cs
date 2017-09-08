using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TurnbacedTileEngine
{
    public static class Player
    {
        static Texture2D m_Curser = TextureDictionary.FindTexture("Outline");
        static Vector2 m_Position = new Vector2(0, 0);
        static decimal Xoffset;
        static decimal Yoffset;
        static Map m_CurrentMap;
        public static Map CurrentMap { set { m_CurrentMap = value; } }
        public static decimal xoffset { get { return Xoffset; } set { Xoffset = value; } }
        public static decimal yoffset { get { return Yoffset; } set { Yoffset = value; } }
        public static Vector2 Position { get { return m_Position; }  }
        static bool needToRelease = false;
        static KeyboardState state = Keyboard.GetState();
        static int leveloffset = 0;
        public static void Draw(SpriteBatch pSpriteBatch)
        {

            pSpriteBatch.Draw(m_Curser, new Rectangle(((int)m_Position.X * 64) + (int)Xoffset + leveloffset, ((int)m_Position.Y * 64) + (int)Yoffset, m_Curser.Width, m_Curser.Height), Color.White);
        }

        public static void Update()
        {
            int lastx = (int)m_Position.X;
            int lasty = (int)m_Position.Y;


            if (Keyboard.GetState().IsKeyDown(Keys.D) && !needToRelease)
            {
                m_Position.X += 1;
                needToRelease = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && !needToRelease)
            {
                m_Position.X -= 1;
                needToRelease = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && !needToRelease)
            {
                m_Position.Y += 1;
                needToRelease = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && !needToRelease)
            {
                m_Position.Y -= 1;
                needToRelease = true;
            }
            else if (needToRelease == true && Keyboard.GetState() == state)
            {
                needToRelease = false;

            }
            if(m_Position.X < 0)
            {
                m_Position.X = 0;
            }
            if(m_Position.X > m_CurrentMap.GetMapWidth() - 1)
            {
                m_Position.X = m_CurrentMap.GetMapWidth() - 1;
            }
            if(m_Position.Y < 0)
            {
                m_Position.Y = 0;

            } 
            if(m_Position.Y > m_CurrentMap.GetMapHeight() - 1)
            {
                m_Position.Y = m_CurrentMap.GetMapHeight() - 1;
            }
            if(m_CurrentMap.GetTile(m_Position) == null)
            {
                if ( ((int)m_Position.Y - (int)Xoffset) % 2 == 0)
                {
                    if (m_CurrentMap.GetTile((int)m_Position.X - 1, (int)m_Position.Y) != null)
                    {
                        m_Position.X -= 1;
                    }
                }
                else if (m_CurrentMap.GetTile((int)m_Position.X + 1, (int)m_Position.Y) != null)
                {
                    m_Position.X += 1;
                }
                else if (m_CurrentMap.GetTile((int)m_Position.X - 1, (int)m_Position.Y) != null)
                {
                    m_Position.X -= 1;
                }
                else
                {
                    m_Position.X = lastx;
                    m_Position.Y = lasty;
                }
            }
            if(m_CurrentMap.GetTile(m_Position) == null)
            {
                m_Position.X = lastx;
                m_Position.Y = lasty;
            }
            if(((int)m_Position.Y - (int)Xoffset) % 2 == 0)
            {
                leveloffset = 0;
            }
            else
            {
                leveloffset = -32;
            }
            Console.updateLog("PlayerX+Y", " " + m_Position.X + " " + m_Position.Y);
        }

    }
}


