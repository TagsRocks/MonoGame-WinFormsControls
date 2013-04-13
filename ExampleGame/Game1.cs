﻿using Microsoft.Xna.Framework;
using MonoGameWinForms;
using System;

namespace ExampleGame
{
    public class Game1 : GameControl
    {
        private Engine _engine;

        protected override void Initialize ()
        {
            base.Initialize();

            _engine = new Engine(GraphicsDeviceService);
            _engine.Initialize();
        }

        protected override void Update (GameTime gameTime)
        {
            _engine.Update(gameTime);

            if (BottomHitCount != _engine.BottomHitCount) {
                BottomHitCount = _engine.BottomHitCount;
                OnBottomHitCountChanged(EventArgs.Empty);
            }
        }

        protected override void Draw (GameTime gameTime)
        {
            _engine.Draw(gameTime);
        }

        public int BottomHitCount { get; private set; }

        public event EventHandler BottomHitCountChanged;

        protected virtual void OnBottomHitCountChanged (EventArgs e)
        {
            var ev = BottomHitCountChanged;
            if (ev != null)
                ev(this, e);
        }
    }
}
