using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text;


namespace Breakout
{
    public class Brick
    {
        public Texture2D texture;
        public Color color;
        public int hitPoints;
        public bool isActive;
        public Rectangle rectangle;

        public Brick(Texture2D texture, Color color, Rectangle rectangle, int hp)
        {
            this.texture = texture;
            this.color = color;
            this.rectangle = rectangle;
            this.hitPoints = hp;
            this.isActive = true;
        }
    }
}
