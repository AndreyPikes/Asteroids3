using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var form = new Form()
            {
                MinimumSize = new System.Drawing.Size(800, 600),
                MaximumSize = new System.Drawing.Size(800, 600),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };
            form.Show();

            SceneManager
                .Get()
                .Init<MenuScene>(form)
                .Draw();

            DebugForm debugForm = new DebugForm();
            debugForm.Show();
            debugForm.AddText("Лог записывается");

            SceneManager.Scene.SceneInitAction += debugForm.AddText;
            SceneManager.Scene.CurrentGameScene += debugForm.Subscription;

            if (!debugForm.IsDisposed) Application.Run(debugForm);

            Application.Run(form);

            
        }

        
    }
}
