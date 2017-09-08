using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TurnbacedTileEngine
{
    public enum LandType { Plain, Power, TransversalStation }
    class Land : Tile
    {
        public Land(int pX, int pY) : base(pX, pY, TextureDictionary.FindTexture("Land"), "Land")
        {
            
        }
        public Land(int pX, int pY, shift pShift) : base(pX, pY, TextureDictionary.FindTexture("Land"), pShift, "Land")
        {

        }
    }
}
