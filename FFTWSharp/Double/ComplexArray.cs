﻿
namespace FFTWSharp.Double
{
    using System;
    using System.Numerics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Complex array pointing to the native FFTW memory.
    /// </summary>
    public class ComplexArray
    {
        private const int SIZE = 16; // sizeof(Complex)

        /// <summary>
        /// Gets the handle to the native memory.
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Gets the logical size of this array.
        /// </summary>
        public int Length { get; private set; }

        // Temporary storage used for copying between native and managed.
        private double[] storage;

        /// <summary>
        /// Creates a new array of complex numbers.
        /// </summary>
        /// <param name="length">Logical length of the array.</param>
        public ComplexArray(int length)
        {
            this.Length = length;
            this.Handle = NativeMethods.malloc(this.Length * SIZE);
        }

        /// <summary>
        /// Creates an FFTW-compatible array from array of doubles.
        /// </summary>
        /// <param name="data">Array of doubles, alternating real and imaginary.</param>
        public ComplexArray(double[] data)
            : this(data.Length / 2)
        {
            this.Set(data);
        }

        /// <summary>
        /// Creates an FFTW-compatible array from array of complex numbers.
        /// </summary>
        /// <param name="data">Array of complex numbers.</param>
        public ComplexArray(Complex[] data)
            : this(data.Length)
        {
            this.Set(data);
        }

        ~ComplexArray()
        {
            NativeMethods.free(Handle);
        }

        /// <summary>
        /// Set the data to an array of complex numbers.
        /// </summary>
        /// <param name="source">Array of doubles, alternating real and imaginary.</param>
        public void Set(double[] source)
        {
            int size = 2 * Length;

            if (source.Length != size)
            {
                throw new ArgumentException("Array length mismatch.");
            }

            Marshal.Copy(source, 0, Handle, size);
        }

        /// <summary>
        /// Set the data to an array of complex numbers.
        /// </summary>
        /// <param name="source">Array of complex numbers.</param>
        public void Set(Complex[] source)
        {
            if (source.Length != this.Length)
            {
                throw new ArgumentException("Array length mismatch.");
            }

            var temp = GetTemporaryStorage();

            for (int i = 0; i < source.Length; i++)
            {
                temp[2 * i] = source[i].Real;
                temp[2 * i + 1] = source[i].Imaginary;
            }

            Marshal.Copy(temp, 0, Handle, this.Length * 2);
        }

        /// <summary>
        /// Set the data to zeros.
        /// </summary>
        public void Clear()
        {
            var temp = GetTemporaryStorage();

            Array.Clear(temp, 0, temp.Length);

            Marshal.Copy(temp, 0, Handle, this.Length * 2);
        }

        /// <summary>
        /// Copy data to array of complex number.
        /// </summary>
        /// <param name="target">Array of complex numbers.</param>
        public void CopyTo(Complex[] target)
        {
            if (target.Length != this.Length)
            {
                throw new Exception();
            }

            var temp = GetTemporaryStorage();

            CopyTo(temp);

            for (int i = 0; i < Length; i++)
            {
                target[i] = new Complex(temp[2 * i], temp[2 * i + 1]);
            }
        }

        /// <summary>
        /// Copy data to array of doubles.
        /// </summary>
        /// <param name="target">Array of doubles, alternating real and imaginary.</param>
        public void CopyTo(double[] target)
        {
            int size = 2 * Length;

            if (target.Length < size)
            {
                throw new Exception();
            }

            Marshal.Copy(Handle, target, 0, size);
        }

        /// <summary>
        /// Copy data to array of doubles.
        /// </summary>
        /// <param name="data">Array of doubles, alternating real and imaginary.</param>
        /// <param name="real">If true, only real part is considered.</param>
        public void CopyTo(double[] target, bool real)
        {
            if (!real)
            {
                CopyTo(target);
                return;
            }

            var temp = GetTemporaryStorage();

            CopyTo(temp);

            for (int i = 0; i < Length; i++)
            {
                target[i] = temp[2 * i];
            }
        }

        /// <summary>
        /// Get data as doubles.
        /// </summary>
        /// <returns>Array of doubles, alternating real and imaginary.</returns>
        public double[] ToArray()
        {
            int size = 2 * Length;

            double[] data = new double[size];

            Marshal.Copy(Handle, data, 0, size);

            return data;
        }

        private double[] GetTemporaryStorage()
        {
            if (storage == null)
            {
                storage = new double[2 * Length];
            }

            return storage;
        }
    }
}
