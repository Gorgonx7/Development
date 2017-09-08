using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TurnbacedTileEngine
{
    public class Log
    {
        string m_Output;
        string m_Ref;
        public Log(string pOutput, string pRef)
        {
            m_Output = pOutput;
            m_Ref = pRef;
        }
        public void changeOutput(string pOutput)
        {
            m_Output = pOutput;
        }
        public string GetRef()
        {
            return m_Ref;
        }
        public string GetOuput()
        {
            return m_Output;
        }
    }
    static class Console
    {
        private static List<Log> m_Logs = new List<Log>();
        public static void AddLog(Log pLog)
        {
            if(GetOutput(pLog.GetRef()) == null)
            {
                m_Logs.Add(pLog);
            }
        }
        public static string GetOutput(string pRef)
        {
            foreach(Log i in m_Logs)
            {
                if(i.GetRef() == pRef)
                {
                    return i.GetOuput();
                }
            }            
                return null;
        }
        public static void updateLog(string pRef, string pOutput)
        {
            foreach(Log i in m_Logs)
            {
                if(i.GetRef() == pRef)
                {
                    i.changeOutput(pOutput);
                    return;
                }
            }
            m_Logs.Add(new Log(pOutput, pRef));
            return;
        }
        public static void Draw(SpriteBatch pSpriteBatch)
        {
            int y = 0;
            foreach(Log i in m_Logs)
            {
                pSpriteBatch.DrawString(FontDictionary.GetFont("Times New Roman"), i.GetOuput(), new Vector2(0, 0 + y), Color.YellowGreen);
                y += 10;
            }
        }
    }
}
