using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class SceneManager
    {
        private static SceneManager _sceneManager;
        private BaseScene _scene;

        public static SceneManager Scene { get { return _sceneManager; } }

        public Action<string> SceneInitAction;
        public Action<Game> CurrentGameScene;

        public static SceneManager Get()
        {
            if (_sceneManager == null)
                _sceneManager = new SceneManager();
            return _sceneManager;
        }

        public IScene Init<T>(Form form) where T : BaseScene, new()
        {
            if (_scene != null)
                _scene.Dispose();

            _scene = new T();
            _scene.Init(form);

            SceneInitAction?.Invoke($"Запущена сцена {_scene.SceneType}");

            if (_scene is Game) CurrentGameScene?.Invoke(_scene as Game);

            return _scene;
        }
        

    }
}
