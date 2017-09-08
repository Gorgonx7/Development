using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TurnbacedTileEngine
{
    
    public class Timer
    {
        float m_Timer = 0;
        float m_Goal;
        bool Repeats = false;
        Tile UpgradeHolder;
        bool holder = false;
        int X = 0;
        int Y = 0;
        public Timer(float LengthOfTime)
        {
            m_Goal = (LengthOfTime * 60);
        }
        public Timer(float LengthOfTime, Tile pTrigTile, int x, int y)
        {
            m_Goal = (LengthOfTime * 60);
            UpgradeHolder = pTrigTile;
            X = x;
            Y = y;
        }
        public Timer(float LengthOfTime, bool pResetable)
        {
            m_Goal = (LengthOfTime * 60);
            Repeats = true;
        }
        public Texture2D GetTileTexture()
        {
            return UpgradeHolder.GetTexture();
        }
        public bool Update()
        {
            if(m_Timer >= m_Goal)
            {
                
                if (Repeats)
                {
                                      
                    m_Timer = 0;
                }
                if (holder == false)
                {
                    holder = true;
                    TriggerMethod(UpgradeHolder);
                }
                return true;
            }
            else
            {
                m_Timer++;
                return false;
            }
        }
        private void TriggerMethod(Tile pTile)
        {
            Game1.Map.ReplaceTile(pTile,Y,X);
        }
        public float CompleationPersentage()
        {
            float Holder = m_Timer / m_Goal;
            return m_Timer / m_Goal;
        }
    }
}
