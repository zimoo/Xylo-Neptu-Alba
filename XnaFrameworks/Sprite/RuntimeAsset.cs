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
    public abstract class RuntimeAsset<TData> : IDisposable
        //where TData : class 
    {
        public Game Game { get; protected set; }
        public ContentManager RuntimeContentManager { get; protected set; }
        public readonly string Directory;
        public TData LoadedAsset { get; protected set; }
        //public bool IsLoaded { get { return LoadedAsset == default(TData); } }
        //public bool IsLoaded { get { return EqualityComparer<TData>.Default.Equals(LoadedAsset, new TData()); } }

        private readonly Disposer _disposer;
        private readonly string _name;

        protected RuntimeAsset(Game game, string name, string directory = "")
        {
            _disposer = new Disposer(this);
            _name = name;

            Game = game;
            Directory = directory;

            RuntimeContentManager = GetNewRuntimeContentManager();

            _disposer.AddManagedDisposable(Game);
        }

        protected ContentManager GetNewRuntimeContentManager()
        {
            return
                new ContentManager(
                    Game.Content.ServiceProvider,
                    Directory == ""
                        ? Game.Content.RootDirectory
                        : Directory
                    );
        }

        public virtual TData Load()
        {
            return 
                LoadedAsset = 
                RuntimeContentManager.Load<TData>(_name);
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            _disposer.Disposing();
        }
    }
}
