using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class Game : BaseScene
    {
        private BaseObject[] asteroids;
        private BaseObject[] stars;
        private Rocket rocket;
        private Bullet bullet;
        private Random random = new Random();
        private Timer timer;

        public event Action<string> LogAction;

        
        public override void Init(Form form)
        {
            base.Init(form);
            
            Load();

            timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += Timer_Tick;
            rocket.DieEvent += Finish;

        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) rocket.MoveY(1);
            if (e.KeyCode == Keys.Down) rocket.MoveY(-1);
            if (e.KeyCode == Keys.ControlKey && bullet == null)
            {
                bullet = new Bullet(new Point(rocket.Rect.X + 50, rocket.Rect.Y + 30), new Point(15, 0), new Size(30, 30));
                LogAction?.Invoke("Произведен выстрел");
            }
            if (e.KeyCode == Keys.Back)
            {
                SceneManager
                    .Get()
                    .Init<MenuScene>(_form)
                    .Draw();
            }
        }

        private  void Timer_Tick(object sender, EventArgs e)
        {            
            Draw();
            Update();
        }

        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            // Фон
            //Buffer.Graphics.FillRectangle(Brushes.Blue, new Rectangle(0, 0, Width, Height));
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, Width, Height));

            foreach (var star in stars)
            {
                star.Draw();
            }

            // Планета
            //Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(100, 100, 200, 200));

            foreach (var asteroid in asteroids)
            {
                asteroid?.Draw();
            }

            if (rocket != null)
            {
                rocket.Draw();
                Buffer.Graphics.DrawString($"Energy: {rocket.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }

            bullet?.Draw();

            Buffer.Render();
        }

        public  void Update()
        {
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null) continue;

                asteroids[i].Update();

                if (bullet != null && asteroids[i].Collision(bullet))
                {
                    LogAction?.Invoke("Попадание по астероиду");

                    bullet = null;
                    asteroids[i] = null;
                    continue;
                }

                if (rocket != null && asteroids[i].Collision(rocket))
                {
                    asteroids[i] = null;

                    LogAction?.Invoke("Попадание астероидом в игрока");

                    rocket.EnergyLow(random.Next(10, 15));
                    if (rocket.Energy <= 0)
                    {
                        LogAction?.Invoke("Смерть игрока");
                        rocket.Die();
                        break;
                    }

                }
            }

            if (bullet != null)
            {
                bullet.Update();
                if (bullet.Rect.X > Width) bullet = null;
            }
            
        }


        public void Load()
        {
            Random random = new Random();
            asteroids = new BaseObject[10];
            rocket = new Rocket(new Point(0, Height / 2 - 50), new Point(5, 5), new Size(100, 100));

            rocket.DieEvent += Finish;

            for (int i = 0; i < asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                asteroids[i] = new Asteroid(new Point(600 - size * 10, i * 20 + size), new Point(-i - 3, -i - 3), new Size(size, size));
            }

            stars = new BaseObject[10];
            for (int i = 0; i < stars.Length; i++)
            {
                var size = random.Next(20, 30);
                stars[i] = new Star(new Point(600 - size * 20, i * 40 + 15), new Point(i + 1, i + 1), new Size(20, 20));
            }
            
        }

        private  void Finish(object sender, int e)
        {
            timer.Tick -= Timer_Tick;
            timer.Stop();
            Buffer.Graphics.DrawString($"Game Over! \n {e}", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        public override void Dispose()
        {
            base.Dispose();
            timer.Stop();
        }

    }
}
