using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TurnbacedTileEngine
{
    class Power : Tile
    {
        public Power(int pX, int pY) : base(pX, pY, TextureDictionary.FindTexture("Power"), "Power")
        {
        }
    }
}
