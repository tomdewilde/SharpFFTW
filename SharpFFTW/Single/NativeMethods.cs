// The code in this file is provided courtesy of Tamas Szalay. Some functionality has been added.

using System;
using System.Runtime.InteropServices;

namespace SharpFFTW.Single
{
    /// <summary>
    /// Contains the basic interface FFTW functions for double-precision (double) operations.
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Allocates FFTW-optimized unmanaged memory.
        /// </summary>
        /// <param name="length">Amount to allocate, in bytes.</param>
        /// <returns>Pointer to allocated memory</returns>
        public static IntPtr fftwf_malloc(int length)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_malloc(length);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_malloc(length);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Allocates FFTW-optimized unmanaged memory.
        /// </summary>
        /// <param name="length">Amount to allocate.</param>
        /// <returns>Pointer to allocated memory</returns>
        public static IntPtr fftwf_alloc_real(int length)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_alloc_real(length);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_alloc_real(length);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Allocates FFTW-optimized unmanaged memory.
        /// </summary>
        /// <param name="length">Amount to allocate.</param>
        /// <returns>Pointer to allocated memory</returns>
        public static IntPtr fftwf_alloc_complex(int length)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_alloc_complex(length);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_alloc_complex(length);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Deallocates memory allocated by FFTW malloc.
        /// </summary>
        /// <param name="mem">Pointer to memory to release.</param>
        public static void fftwf_free(IntPtr mem)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_free(mem);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_free(mem);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Deallocates an FFTW plan and all associated resources.
        /// </summary>
        /// <param name="plan">Pointer to the plan to release.</param>
        public static void fftwf_destroy_plan(IntPtr plan)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_destroy_plan(plan);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_destroy_plan(plan);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Clears all memory used by FFTW, resets it to initial state. Does not replace destroy_plan and free
        /// </summary>
        /// <remarks>After calling fftwf_cleanup, all existing plans become undefined, and you should not 
        /// attempt to execute them nor to destroy them. You can however create and execute/destroy new plans, 
        /// in which case FFTW starts accumulating wisdom information again. 
        /// fftwf_cleanup does not deallocate your plans; you should still call fftwf_destroy_plan for this purpose.</remarks>
        public static void fftwf_cleanup()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_cleanup();
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_cleanup();
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Sets the maximum time that can be used by the planner.
        /// </summary>
        /// <param name="seconds">Maximum time, in seconds.</param>
        /// <remarks>This function instructs FFTW to spend at most seconds (approximately) in the planner. 
        /// If seconds == -1.0 (the default value), then planning time is unbounded. 
        /// Otherwise, FFTW plans with a progressively wider range of algorithms until the given time limit is 
        /// reached or the given range of algorithms is explored, returning the best available plan. For example, 
        /// specifying fftwf_flags.Patient first plans in Estimate mode, then in Measure mode, then finally (time 
        /// permitting) in Patient. If fftwf_flags.Exhaustive is specified instead, the planner will further progress to 
        /// Exhaustive mode. 
        /// </remarks>
        public static void fftwf_set_timelimit(double seconds)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_set_timelimit(seconds);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_set_timelimit(seconds);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Executes an FFTW plan, provided that the input and output arrays still exist
        /// </summary>
        /// <param name="plan">Pointer to the plan to execute.</param>
        /// <remarks>execute (and equivalents) is the only function in FFTW guaranteed to be thread-safe.</remarks>
        public static void fftwf_execute(IntPtr plan)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_execute(plan);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_execute(plan);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 1-dimensional complex-to-complex DFT.
        /// </summary>
        /// <param name="n">The logical size of the transform.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="direction">Specifies the direction of the transform.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_1d(int n, IntPtr input, IntPtr output, Direction direction, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_1d(n, input, output, direction, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_1d(n, input, output, direction, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 2-dimensional complex-to-complex DFT.
        /// </summary>
        /// <param name="nx">The logical size of the transform along the first dimension.</param>
        /// <param name="ny">The logical size of the transform along the second dimension.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="direction">Specifies the direction of the transform.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_2d(int nx, int ny, IntPtr input, IntPtr output, Direction direction, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_2d(nx, ny, input, output, direction, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_2d(nx, ny, input, output, direction, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 3-dimensional complex-to-complex DFT.
        /// </summary>
        /// <param name="nx">The logical size of the transform along the first dimension.</param>
        /// <param name="ny">The logical size of the transform along the second dimension.</param>
        /// <param name="nz">The logical size of the transform along the third dimension.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="direction">Specifies the direction of the transform.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_3d(int nx, int ny, int nz, IntPtr input, IntPtr output, Direction direction, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_3d(nx, ny, nz, input, output, direction, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_3d(nx, ny, nz, input, output, direction, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for an n-dimensional complex-to-complex DFT.
        /// </summary>
        /// <param name="rank">Number of dimensions.</param>
        /// <param name="n">Array containing the logical size along each dimension.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="direction">Specifies the direction of the transform.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft(int rank, int[] n, IntPtr input, IntPtr output, Direction direction, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft(rank, n, input, output, direction, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft(rank, n, input, output, direction, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 1-dimensional real-to-complex DFT
        /// </summary>
        /// <param name="n">Number of REAL (input) elements in the transform.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_r2c_1d(int n, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_r2c_1d(n, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_r2c_1d(n, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 2-dimensional real-to-complex DFT
        /// </summary>
        /// <param name="nx">Number of REAL (input) elements in the transform along the first dimension.</param>
        /// <param name="ny">Number of REAL (input) elements in the transform along the second dimension.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_r2c_2d(int nx, int ny, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_r2c_2d(nx, ny, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_r2c_2d(nx, ny, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 3-dimensional real-to-complex DFT
        /// </summary>
        /// <param name="nx">Number of REAL (input) elements in the transform along the first dimension.</param>
        /// <param name="ny">Number of REAL (input) elements in the transform along the second dimension.</param>
        /// <param name="nz">Number of REAL (input) elements in the transform along the third dimension.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_r2c_3d(int nx, int ny, int nz, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_r2c_3d(nx, ny, nz, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_r2c_3d(nx, ny, nz, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for an n-dimensional real-to-complex DFT
        /// </summary>
        /// <param name="rank">Number of dimensions.</param>
        /// <param name="n">Array containing the number of REAL (input) elements along each dimension.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_r2c(int rank, int[] n, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_r2c(rank, n, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_r2c(rank, n, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 1-dimensional complex-to-real DFT
        /// </summary>
        /// <param name="n">Number of REAL (output) elements in the transform.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_c2r_1d(int n, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_c2r_1d(n, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_c2r_1d(n, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 2-dimensional complex-to-real DFT
        /// </summary>
        /// <param name="nx">Number of REAL (output) elements in the transform along the first dimension.</param>
        /// <param name="ny">Number of REAL (output) elements in the transform along the second dimension.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_c2r_2d(int nx, int ny, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_c2r_2d(nx, ny, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_c2r_2d(nx, ny, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 3-dimensional complex-to-real DFT
        /// </summary>
        /// <param name="nx">Number of REAL (output) elements in the transform along the first dimension.</param>
        /// <param name="ny">Number of REAL (output) elements in the transform along the second dimension.</param>
        /// <param name="nz">Number of REAL (output) elements in the transform along the third dimension.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_c2r_3d(int nx, int ny, int nz, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_c2r_3d(nx, ny, nz, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_c2r_3d(nx, ny, nz, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for an n-dimensional complex-to-real DFT
        /// </summary>
        /// <param name="rank">Number of dimensions.</param>
        /// <param name="n">Array containing the number of REAL (output) elements along each dimension.</param>
        /// <param name="input">Pointer to an array of 16-byte complex numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_dft_c2r(int rank, int[] n, IntPtr input, IntPtr output, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_dft_c2r(rank, n, input, output, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_dft_c2r(rank, n, input, output, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 1-dimensional real-to-real DFT
        /// </summary>
        /// <param name="n">Number of elements in the transform.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="kind">The kind of real-to-real transform to compute.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_r2r_1d(int n, IntPtr input, IntPtr output, Transform kind, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_r2r_1d(n, input, output, kind, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_r2r_1d(n, input, output, kind, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 2-dimensional real-to-real DFT
        /// </summary>
        /// <param name="nx">Number of elements in the transform along the first dimension.</param>
        /// <param name="ny">Number of elements in the transform along the second dimension.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="kindx">The kind of real-to-real transform to compute along the first dimension.</param>
        /// <param name="kindy">The kind of real-to-real transform to compute along the second dimension.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_r2r_2d(int nx, int ny, IntPtr input, IntPtr output, Transform kindx, Transform kindy, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_r2r_2d(nx, ny, input, output, kindx, kindy, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_r2r_2d(nx, ny, input, output, kindx, kindy, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for a 3-dimensional real-to-real DFT
        /// </summary>
        /// <param name="nx">Number of elements in the transform along the first dimension.</param>
        /// <param name="ny">Number of elements in the transform along the second dimension.</param>
        /// <param name="nz">Number of elements in the transform along the third dimension.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="kindx">The kind of real-to-real transform to compute along the first dimension.</param>
        /// <param name="kindy">The kind of real-to-real transform to compute along the second dimension.</param>
        /// <param name="kindz">The kind of real-to-real transform to compute along the third dimension.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_r2r_3d(int nx, int ny, int nz, IntPtr input, IntPtr output, Transform kindx, Transform kindy, Transform kindz, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_r2r_3d(nx, ny, nz, input, output, kindx, kindy, kindz, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_r2r_3d(nx, ny, nz, input, output, kindx, kindy, kindz, flags);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Creates a plan for an n-dimensional real-to-real DFT
        /// </summary>
        /// <param name="rank">Number of dimensions.</param>
        /// <param name="n">Array containing the number of elements in the transform along each dimension.</param>
        /// <param name="input">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="output">Pointer to an array of 8-byte real numbers.</param>
        /// <param name="kind">An array containing the kind of real-to-real transform to compute along each dimension.</param>
        /// <param name="flags">Flags that specify the behavior of the planner.</param>
        public static IntPtr fftwf_plan_r2r(int rank, int[] n, IntPtr input, IntPtr output, Transform[] kind, Options flags)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_plan_r2r(rank, n, input, output, kind, flags);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_plan_r2r(rank, n, input, output, kind, flags);
            else
                throw new PlatformNotSupportedException();

        }

#if USE_THREADS
        /// <summary>
        /// Perform any one-time initialization required to use threads.
        /// </summary>
        /// <returns>Returns zero if there was some error and a non-zero value otherwise.</returns>
        public static int fftwf_init_threads()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_init_threads();
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_init_threads();
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Sets number of threads for FFTW to use.
        /// </summary>
        /// <param name="nthreads">The number of threads.</param>
        public static void fftwf_plan_with_nthreads(int nthreads)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_plan_with_nthreads(nthreads);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_plan_with_nthreads(nthreads);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Determines the current number of threads that the planner can use.
        /// </summary>
        /// <returns>Number of threads that the planner can use.</returns>
        public static int fftwf_planner_nthreads()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_planner_nthreads();
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_planner_nthreads();
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Cleanup all memory and other resources allocated internally by FFTW.
        /// </summary>
        /// <remarks>
        /// Much like the fftwf_cleanup() function except that it also gets rid of threads-related data.
        /// You must not execute any previously created plans after calling this function.
        /// </remarks>
        public static void fftwf_cleanup_threads()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_cleanup_threads();
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_cleanup_threads();
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// See http://www.fftwf.org/fftwf3_doc/Thread-safety.html
        /// </summary>
        public static void fftwf_make_planner_thread_safe()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_make_planner_thread_safe();
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_make_planner_thread_safe();
            else
                throw new PlatformNotSupportedException();

        }

#endif

        /// <summary>
        /// Returns (approximately) the number of flops used by a certain plan.
        /// </summary>
        /// <param name="plan">The plan to measure.</param>
        /// <param name="add">Reference to double to hold number of adds.</param>
        /// <param name="mul">Reference to double to hold number of muls.</param>
        /// <param name="fma">Reference to double to hold number of fmas (fused multiply-add).</param>
        /// <remarks>Total flops ~= add+mul+2*fma or add+mul+fma if fma is supported</remarks>
        public static void fftwf_flops(IntPtr plan, out double add, out double mul, out double fma)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_flops(plan, out add, out mul, out fma);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_flops(plan, out add, out mul, out fma);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Estimate cost of given plan.
        /// </summary>
        /// <param name="plan">Pointer to the plan.</param>
        /// <returns></returns>
        public static double estimate_cost(IntPtr plan)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.estimate_cost(plan);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.estimate_cost(plan);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Get cost of given plan.
        /// </summary>
        /// <param name="plan">Pointer to the plan.</param>
        /// <returns></returns>
        public static double cost(IntPtr plan)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.cost(plan);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.cost(plan);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Outputs a "nerd-readable" version of the specified plan to stdout.
        /// </summary>
        /// <param name="plan">The plan to output.</param>
        public static void fftwf_print_plan(IntPtr plan)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                NativeMethods_x64.fftwf_print_plan(plan);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                NativeMethods_x86.fftwf_print_plan(plan);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Outputs a "nerd-readable" version of the specified plan.
        /// </summary>
        /// <param name="plan">The plan to output.</param>
        public static IntPtr fftwf_sprint_plan(IntPtr plan)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_sprint_plan(plan);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_sprint_plan(plan);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Exports the accumulated Wisdom to the provided filename.
        /// </summary>
        /// <param name="filename">The target filename.</param>
        public static int fftwf_export_wisdom_to_filename(string filename)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_export_wisdom_to_filename(filename);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_export_wisdom_to_filename(filename);
            else
                throw new PlatformNotSupportedException();

        }

        /// <summary>
        /// Imports Wisdom from provided filename.
        /// </summary>
        /// <param name="filename">The filename to read from.</param>
        public static int fftwf_import_wisdom_from_filename(string filename)
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                return NativeMethods_x64.fftwf_import_wisdom_from_filename(filename);
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                return NativeMethods_x86.fftwf_import_wisdom_from_filename(filename);
            else
                throw new PlatformNotSupportedException();

        }
    }
}
