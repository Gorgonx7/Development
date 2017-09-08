using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TurnbacedTileEngine
{
    public struct Hex
    {
        Rectangle m_DrawingRectangle;
        Vector2 m_Position;
        int m_Width, m_Height;
        const int Sides = 6;
        int m_Radius;
        public Vector2 GetPosition { get { return m_Position; } }
        public Rectangle DrawingRectangle { get { return m_DrawingRectangle; } }
        public int Top { get { return (int)m_Position.X; } }
        public int Bottom { get { return ((int)m_Position.X + m_Height); } }
        public int Left { get { return ((int)m_Position.Y); } }
        public int Right { get { return ((int)m_Position.Y + m_Width); } }

        public Hex(int pX, int pY, int pWidth, int pHeight, int pRadius) 
        {
            m_Position = new Vector2(pX, pY);
            m_Width = pWidth;
            m_Height = pHeight;
            m_Radius = pRadius;
            m_DrawingRectangle = new Rectangle(pX, pY, pWidth, pHeight);
        }

    }
}
