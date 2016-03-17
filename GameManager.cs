using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oztroja.Entities;

namespace Oztroja
{
    public class GameManager
    {
        private static GameManager _gameManager;
        public static GameManager Instance { get { return _gameManager; } }

        public static void Setup(Game game)
        {
            _gameManager = new GameManager(game);
            _gameManager.Initialize();
        }

        public static void Teardown()
        {

        }

        private Game _game;
        private Screen _mainScreen;
        private World _world;
        private Player _player;

        private int _tick;

        public int CurrentTick { get { return _tick; } }

        public Screen MainScreen { get { return _mainScreen; } }

        public World World { get { return _world; } }

        public Player Player { get { return _player; } }

        private GameManager(Game game)
        {
            _game = game;
        }

        private void Initialize()
        {
            var batch = new SpriteBatch(_game.GraphicsDevice);

            _player = new Player(1, 1);

            _mainScreen = new Screen(batch);
            _world = new World();
        }

        public void Tick()
        {
            _tick++;
            _world.Tick(_tick);
        }

        public void Render()
        {
            _mainScreen.Batch.Begin();
            _world.Render(_mainScreen);
            _mainScreen.Batch.End();
        }
    }
}
