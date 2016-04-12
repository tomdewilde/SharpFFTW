﻿
namespace FFTWSharp
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Abstract base class for native FFTW arrays.
    /// </summary>
    public abstract class AbstractArray<T> : IDisposable
        where T : struct, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// Gets the handle to the native memory.
        /// </summary>
        public IntPtr Handle { get; protected set; }

        /// <summary>
        /// Gets the logical size of this array.
        /// </summary>
        public int Length { get; private set; }

        // Temporary data used for copying between native and managed.
        private T[] data;

        /// <summary>
        /// Creates a new array of complex numbers.
        /// </summary>
        /// <param name="length">Logical length of the array.</param>
        public AbstractArray(int length)
        {
            this.Length = length;
        }
        
        #region IDisposable implementation

        protected bool hasDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract void Dispose(bool disposing);

        ~AbstractArray()
        {
            Dispose(true);
        }

        #endregion

        protected T[] GetTemporaryData(int size)
        {
            if (data == null)
            {
                data = new T[size];
            }

            return data;
        }
    }
}
