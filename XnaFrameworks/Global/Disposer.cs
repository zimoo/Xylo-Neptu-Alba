using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public class Disposer : IDisposable
    {
        /// <summary>
        ///     Adapted from
        ///     http://msdn.microsoft.com/en-us/library/ms244737(v=vs.80).aspx
        /// </summary>

        private IDisposable _caller;

        private List<IDisposable> _managedDisposables;
        public readonly List<IDisposable> ManagedResources;

        //private List<UnmanagedResource> _unmanagedResources;
        //public readonly List<UnmanagedResource> UnmanagedResources;

        public Disposer(IDisposable caller)
        {
            _caller = caller;

            _managedDisposables = new List<IDisposable>();
            ManagedResources = _managedDisposables;

            //_unmanagedResources = new List<UnmanagedResource>();
            //UnmanagedResources = _unmanagedResources;
        }

        public void AddManagedDisposable(IDisposable disposable)
        {
            _managedDisposables.Add(disposable);
        }

        public void RemoveManagedDisposable(IDisposable disposable)
        {
            _managedDisposables.Remove(disposable);
        }

        public void ClearManagedDisposables()
        {
            _managedDisposables.Clear();
        }

        //public void AddUnmanagedResource(UnmanagedResource unmanagedResource)
        //{
        //    _unmanagedResources.Add(unmanagedResource);
        //}

        //public void RemoveUnmanagedResource(UnmanagedResource unmanagedResource)
        //{
        //    _unmanagedResources.Remove(unmanagedResource);
        //}

        //public void ClearUnmanagedResources()
        //{
        //    _unmanagedResources.Clear();
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Disposing()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_caller != null)
                {
                    GC.SuppressFinalize(_caller);
                }

                ManagedResources.ForEach(managedResource =>
                    {
                        if (managedResource != null)
                        {
                            managedResource.Dispose();
                        }
                    }
                );
            }

            //UnmanagedResources.ForEach( unmanagedResource =>
            //    {
            //        if (unmanagedResource != null)
            //        {
            //            unmanagedResource.Dispose();
            //        }
            //    }
            //);
        }
    }

    /// Consider implementing SafeHandles rather than IntPtr finalizers when unmanaged resources are to be used
    /// http://msdn.microsoft.com/en-us/library/fh21e17c.aspx

    //public class UnmanagedResource : IDisposable
    //{
    //    private IntPtr _intPtr;
    //    public IntPtr IntPtr
    //    {
    //        get { return _intPtr; }
    //        protected set { _intPtr = value; }
    //    }

    //    public Action CleanupStatement { get; protected set; }

    //    public UnmanagedResource(IntPtr intPtr, Action cleanupStatement)
    //    {
    //        IntPtr = intPtr;
    //        CleanupStatement = cleanupStatement;
    //    }

    //    ~UnmanagedResource()
    //    {
    //        //Dispose(false); ???
    //        CleanupStatement();
    //    }

    //    public void Dispose() { Dispose(true); }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (IntPtr == IntPtr.Zero) return;
    //        Marshal.FreeHGlobal(IntPtr);
    //        IntPtr = IntPtr.Zero;
    //    }
    //}
}
