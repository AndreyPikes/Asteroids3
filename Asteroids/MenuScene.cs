using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class MenuScene : BaseScene
    {
        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawString("Меню игры", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 160, 100);
            Buffer.Graphics.DrawString("<Enter> - игра", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 200, 200);
            Buffer.Graphics.DrawString("<Esc> - выход", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 200, 300);
            Buffer.Render();
        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _form.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SceneManager
                        .Get()
                        .Init<Game>(_form)
                        .Draw();
            }
        }
    }
}
