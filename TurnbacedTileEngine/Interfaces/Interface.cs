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
    class Interface
    {
        protected Texture2D m_Background;
        protected int X;
        protected int Y;
        protected string m_Title = "";
        protected string[] m_InterfaceOptions;
        protected static KeyboardState state = Keyboard.GetState();
        public Interface(int pX, int pY, Texture2D pTextureBackground, string pInterfaceTitle, string[] pInterfaceOptions)
        {
            X = pX;
            Y = pY;
            m_Background = pTextureBackground;
            m_Title = pInterfaceTitle;
            m_InterfaceOptions = pInterfaceOptions;
        }
        public Interface( int pX, int pY, Texture2D pTextureBackground)
        {
            X = pX;
            Y = pY;
            m_Title = "";
            m_InterfaceOptions = new string[] { };
            m_Background = pTextureBackground;
        }
        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(m_Background, new Rectangle(X, Y, m_Background.Width, m_Background.Height), Color.White);
            pSpriteBatch.DrawString(FontDictionary.GetFont("Times New Roman"), m_Title, new Vector2(X + 20, Y + 20), Color.White);
            int yOffset = Y + 145;
            for(int Counter = 0; Counter < m_InterfaceOptions.Length; Counter++)
            {
                pSpriteBatch.DrawString(FontDictionary.GetFont("Times New Roman"), m_InterfaceOptions[Counter], new Vector2(20 + X, yOffset), Color.White);
                yOffset += 50;
            }
        }
    }
}
