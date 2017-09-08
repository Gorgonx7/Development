using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TurnbacedTileEngine
{
    /*
     Blank, land, rough, mountain
         */
         public enum shift { Left, Right}
    public enum BuildOptions { blank, power, post}
   public class Tile
    {
        
        private Hex m_Hex;
        private Texture2D m_Texture;
        protected bool Transversable = true;
        private bool ActiveTile = false;
        private string m_Name;
        protected Timer m_UpgradeTimer;
        private Texture2D UpgradeTexture;
        private float UpgradePersentage;
        public int GetX { get { return (int)m_Hex.GetPosition.X; } }
        public int GetY { get { return (int)m_Hex.GetPosition.Y; } }
        public Tile(int pX, int pY, Texture2D pTexture, string pName)
        {
            m_Hex = new Hex(pX, pY, pTexture.Width, pTexture.Height, (pTexture.Height / 2));
            m_Texture = pTexture;
            m_Name = pName;
        }
        public Tile(int pX, int pY, Texture2D pTexture, shift pAlignment, string pName)
        {
            m_Name = pName;
            int x = pX;
            const int offset = 32;
            switch (pAlignment)
            {
                case shift.Left:
                    x -= offset;
                    break;
                case shift.Right:
                    x -= offset;
                    break;
            }
            m_Texture = pTexture;
            m_Hex = new Hex(x, pY, pTexture.Width, pTexture.Height, pTexture.Height / 2);
        }
        public void UpgradeTile(Tile pUpgrade)
        {
            m_UpgradeTimer = new Timer(5, pUpgrade, (int)Player.Position.X, (int)Player.Position.Y);
        }
        public virtual void Update()
        {
            if(m_UpgradeTimer != null)
            {
                m_UpgradeTimer.Update();
                UpgradeTexture = m_UpgradeTimer.GetTileTexture();
                UpgradePersentage = m_UpgradeTimer.CompleationPersentage();
                Console.updateLog("UpgradeTimer", "" + m_UpgradeTimer.CompleationPersentage());
            }
        }
        public Texture2D GetTexture()
        {
            return m_Texture;
        }
        public virtual void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(m_Texture, m_Hex.DrawingRectangle, Color.White);  
            if(UpgradeTexture != null)
            {
                
                pSpritebatch.Draw(UpgradeTexture, new Rectangle((int)m_Hex.GetPosition.X, (int)m_Hex.GetPosition.Y, UpgradeTexture.Width, (int)(UpgradeTexture.Height * UpgradePersentage)), new Rectangle(0, 0, UpgradeTexture.Width, (int)(UpgradeTexture.Height * UpgradePersentage)), Color.White);
            }
        }
        public override string ToString()
        {
            return m_Name;
        }
    }
}
