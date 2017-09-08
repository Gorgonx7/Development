using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TurnbacedTileEngine
{
    class Rough : Tile
    {
        public Rough(int pX, int pY) : base(pX, pY, TextureDictionary.FindTexture("Rough"), "Rough")
        {

        }
        public Rough(int pX, int pY, shift pShift) : base(pX, pY, TextureDictionary.FindTexture("Rough"), pShift, "Rough")
        {

        }
    }
}
