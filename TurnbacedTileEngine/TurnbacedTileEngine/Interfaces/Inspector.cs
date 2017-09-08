using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace TurnbacedTileEngine
{
    class Inspector : Interface
    {
        public static Map currentMap;
        int Incremantor = 50;
        int selectedOption = 0;
        bool needToRelease = false;

        public Inspector(int pX, int pY) : base(pX, pY, TextureDictionary.FindTexture("Interface"))
        {
            m_Title = "Inspector";
            m_InterfaceOptions = new string[] { "Upgrade To Blank", "Upgrade To Power", "Upgrade To Post"};
        }
        public void Update()
        {
            Tile CurrentTile = currentMap.GetTile(Player.Position);
            m_Title = CurrentTile.ToString();
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && !needToRelease)
            {
                if(selectedOption != 0)
                {
                    selectedOption -= 1;
                }
                needToRelease = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !needToRelease)
            {
                if(selectedOption != m_InterfaceOptions.Length -1)
                {
                    selectedOption += 1;
                }
                needToRelease = true;
            } else if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !needToRelease)
            {
                switch (selectedOption)
                {
                    case 0:
                        CurrentTile.UpgradeTile(new Blank(CurrentTile.GetX, CurrentTile.GetY));
                        break;
                    case 1:
                        CurrentTile.UpgradeTile(new Power(CurrentTile.GetX, CurrentTile.GetY));
                        break;
                    case 2:
                        CurrentTile.UpgradeTile(new Post(CurrentTile.GetX, CurrentTile.GetY));
                        break;
                }
                
            }
            else if (needToRelease == true && Keyboard.GetState() == state)
            {
                needToRelease = false;

            }


        }
        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            pSpriteBatch.Draw(TextureDictionary.FindTexture("Bar"), new Rectangle(X, Y + 150 + (Incremantor * selectedOption), m_Background.Width, TextureDictionary.FindTexture("Bar").Height + 22), Color.White);

            
        }
    }
}
