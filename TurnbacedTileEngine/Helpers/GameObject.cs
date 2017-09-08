using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Summer_Project
{
    public abstract class GameObject2D
    {
        Vector2 m_Position;
        Vector2 m_Velocity;
        protected bool[] m_CanMove = new bool[4];
        int Health;
        Texture2D m_Texture;
        Rectangle m_Rect;
        bool m_Collidable = false;
        public bool Collidable { get { return Collidable; } set { m_Collidable = value; } }
        public GameObject2D(Vector2 pPosition)
        {
            m_Position = pPosition;
            m_Velocity = new Vector2();
            Health = 100;

        }
        public Vector2 GetPosition()
        {
            return m_Position;
        }
        public Vector2 GetVelocity()
        {
            return m_Velocity;
        }
        public Texture2D GetTexture()
        {
            return m_Texture;
        }
        public virtual void Collide(GameObject2D pObject)
        {
            if(pObject.Collidable == true)
            {
                if (pObject.m_Rect.Top < this.m_Rect.Bottom && pObject.m_Rect.Intersects(this.m_Rect))
                {
                    m_CanMove[0] = false;
                    // can't move down
                } if (pObject.m_Rect.Left < this.m_Rect.Right && pObject.m_Rect.Intersects(this.m_Rect))
                {
                    m_CanMove[1] = false;
                   //can't move right
                } if(pObject.m_Rect.Right > this.m_Rect.Left && pObject.m_Rect.Intersects(this.m_Rect))
                {
                    m_CanMove[2] = false;
                    // can't move left
                } if(pObject.m_Rect.Bottom > this.m_Rect.Top && pObject.m_Rect.Intersects(this.m_Rect))
                {
                    m_CanMove[3] = false;
                    // can't move up
                }
            }
        }
        public abstract void Draw(SpriteBatch pSpritebatch);        
        public abstract void Update();
    }
}
