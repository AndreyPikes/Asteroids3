using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Star : Asteroid
    {
        public override void SetImages()
        {
            images = new Image[3] { Resources.star1, Resources.star2, Resources.star3 };
        }       

        public Star(Point pos, Point dir, Size size) : base (pos, dir, size)
        {

        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;

            if (pos.X < 0) pos.X = Game.Width;
            if (pos.X > Game.Width) pos.X = 0;

            if (pos.Y < 0) pos.Y = Game.Height;
            if (pos.Y > Game.Height) pos.Y = 0;
        }
    }
}
