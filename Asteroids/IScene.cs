using System.Windows.Forms;

namespace Asteroids
{
    public interface IScene
    {
        void Init(Form form);
        void Draw();
    }
}