using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace animation.Content
{
    class animate
    {
        Texture2D explosion;
        private Vector2 position;
        private float timePast;
        private float maxTime = 0.5f;
        private int numberOfFrames = 24;
        private int numFramesX = 4;
        private int frameSize;

        public animate(Texture2D texture, Viewport viewPort)
        {
            explosion = texture;
            frameSize = explosion.Bounds.Width / numFramesX;

            position = new Vector2((viewPort.Width - frameSize) / 2, (viewPort.Height - frameSize) / 2);
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {
            
            if (timePast >= maxTime)
            {
                timePast = 0;
            }
            timePast += elapsedTime;
            float percentAnimated = timePast / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);
            int frameX = frame % numFramesX;
            int frameY = frame / numFramesX;

            spriteBatch.Begin();
            spriteBatch.Draw(explosion, position, new Rectangle(frameX * frameSize, frameY * frameSize, frameSize, frameSize), Color.White);
            spriteBatch.End();
        }
    }
}
