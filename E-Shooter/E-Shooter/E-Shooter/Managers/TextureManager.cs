using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace E_Shooter
{


    public sealed class TextureManager
    {

        Dictionary<string, Texture2D> textureDictionary;

        private static readonly TextureManager instance = new TextureManager();

        private TextureManager()
        {
            textureDictionary = new Dictionary<string, Texture2D>();
        }

        public static TextureManager sharedTextureManager
        {
            get
            {
                return instance;
            }
        }

        public Texture2D getTexture(string textureName)
        {
            Texture2D tempTex;

            if (textureDictionary.TryGetValue(textureName, out tempTex))
                return tempTex;
            else
                return null;

        }


        public void addTexture(string textureName, Texture2D textureToAdd)
        {
            textureDictionary.Add(textureName, textureToAdd);
        }


    }


}
