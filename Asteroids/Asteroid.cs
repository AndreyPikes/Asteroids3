using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        private static Random randomImage = new Random();

        public Asteroid(Point pos, Point dir, Size size) : base (pos, dir, size)
        {            
            this.currentImage = images[randomImage.Next(0, images.Length)];
        }

        public void SetOnOppositePosition(int width)
        {
            pos.X = width;
        }

        public override void SetImages()
        {
            images = new Image[4] { Resources.meteorBrown_big1, Resources.meteorBrown_big2,
            Resources.meteorBrown_big3, Resources.meteorBrown_big4 };
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(currentImage, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;

            if (pos.X < 0 || pos.X > Game.Width) dir.X = -dir.X;   
            if (pos.Y < 0 || pos.Y > Game.Height) dir.Y = -dir.Y;
        }
    }
}
