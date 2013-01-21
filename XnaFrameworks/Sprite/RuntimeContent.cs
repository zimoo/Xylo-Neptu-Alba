using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Global;

namespace XnaFramework.Sprite
{
    public abstract class RuntimeContent<TContent> : IDisposable
    {
        public static ContentManager ContentManager { get; protected set; }
        public static readonly string Root;

        private readonly Disposer _disposer;
        private readonly string _assetName;

        protected RuntimeContent(ContentManager gameContentManager, string assetName, string root = "")
        {
            _disposer = new Disposer(this);

            _assetName = assetName;

            ContentManager = 
                new ContentManager(
                    gameContentManager.ServiceProvider,
                    root == "" 
                        ? gameContentManager.RootDirectory 
                        : root
                    );

            _disposer.AddManagedDisposable(ContentManager);
        }

        public virtual TContent Load()
        {
            return ContentManager.Load<TContent>(_assetName);
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            _disposer.FinalizerDispose();
        }
    }
}
