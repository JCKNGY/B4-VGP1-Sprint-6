using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;


namespace Space_Invaders_Part_2
{
    class Alien
    {
        public Rectangle alienRect = new Rectangle(50 , 50 , 30, 40);
        public Texture2D alienTex; 

        public Alien(Rectangle AlienRect, Texture2D AlienTex)
        {
            alienRect = AlienRect;
            alienTex = AlienTex; 
        }
    }
}
