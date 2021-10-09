using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Rocket : BaseObject
    {
        //public delegate void Die(int damage);
        public event EventHandler<int> DieEvent;

        protected int energy = 100;
        private int lastDamage = 0;

        public int Energy
        {
            get { return energy; }
        }

        public Rocket(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.currentImage = images[0];
        }
        public override void SetImages()
        {
            images = new Image[1] { Resources.rocket };
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(currentImage, pos.X, pos.Y, size.Width, size.Height);
        }

        public void MoveY(int direction)
        {
            if (direction > 0)
            {
                if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
            }
            if (direction < 0)
            {
                if (pos.Y < Game.Height - size.Height) pos.Y = pos.Y + dir.Y;
            }
        }

        public void EnergyLow(int damage)
        {
            lastDamage = damage;
            energy -= damage;
        }

        public void Die()
        {
            if (DieEvent != null)
            {
                DieEvent.Invoke(this, lastDamage);
            }
        }
        


        public override void Update()
        {
            
        }
    }
}
