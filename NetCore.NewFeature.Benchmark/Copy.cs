using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NetCore.NewFeature.Benchmark
{
    [CoreJob]
    [RankColumn, CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class Copy
    {
        private byte[] _managedDataSource;
        private byte[] _managedDataDestination;
        private IntPtr _nativeDataSource;

        [Params(16, 32, 64, 2048, 1024 * 1024 * 1024)]
        public int N;
        private IntPtr _nativeDataDestination;

        [GlobalSetup]
        public unsafe void GlobalSetup()
        {
            _managedDataSource = new byte[N];
            new Random(42).NextBytes(_managedDataSource);

            _managedDataDestination = new byte[N];

            _nativeDataSource = Marshal.AllocHGlobal(N);
            new Random(42).NextBytes(new Span<byte>(_nativeDataSource.ToPointer(), N));

            _nativeDataDestination = Marshal.AllocHGlobal(N);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            Marshal.FreeHGlobal(_nativeDataSource);
            Marshal.FreeHGlobal(_nativeDataDestination);
        }

        [BenchmarkCategory("ManagedToManaged", "Buffer_MemoryCopy"), Benchmark]
        public unsafe void ManagedToManaged_Buffer_MemoryCopy()
        {
            fixed (byte* pSrc = _managedDataSource, pDest = _managedDataDestination)
            {
                Buffer.MemoryCopy(pSrc, pDest, N, N);
            }
        }

        [BenchmarkCategory("ManagedToManaged", "Unsafe_CopyBlock"), Benchmark(Baseline = true)]
        public unsafe void ManagedToManaged_Unsafe_CopyBlock()
        {
            fixed (byte* pSrc = _managedDataSource, pDest = _managedDataDestination)
            {
                Unsafe.CopyBlock(pDest, pSrc, checked((uint)N));
            }
        }

        [BenchmarkCategory("ManagedToManaged", "Array_Copy"), Benchmark]
        public void ManagedToManaged_Array_Copy()
        {
            Array.Copy(_managedDataSource, _managedDataDestination, N);
        }

        [BenchmarkCategory("NativeToManaged", "Marshal_Copy"), Benchmark]
        public void NativeToManaged_Marshal()
        {
            Marshal.Copy(_nativeDataSource, _managedDataDestination, 0, N);
        }

        [BenchmarkCategory("NativeToManaged", "Buffer_MemoryCopy"), Benchmark]
        public unsafe void NativeToManaged_Buffer_MemoryCopy()
        {
            fixed (byte* pDest = _managedDataDestination)
            {
                Buffer.MemoryCopy(_nativeDataSource.ToPointer(), pDest, N, N);
            }
        }

        [BenchmarkCategory("NativeToManaged", "Unsafe_CopyBlock"), Benchmark(Baseline = true)]
        public unsafe void NativeToManaged_Unsafe_CopyBlock()
        {
            fixed (byte* pDest = _managedDataDestination)
            {
                Unsafe.CopyBlock(pDest, _nativeDataSource.ToPointer(), checked((uint)N));
            }
        }

        [BenchmarkCategory("NativeToNative", "Buffer_MemoryCopy"), Benchmark]
        public unsafe void NativeToNative_Buffer_MemoryCopy()
        {
            Buffer.MemoryCopy(_nativeDataSource.ToPointer(), _nativeDataDestination.ToPointer(), N, N);
        }

        [BenchmarkCategory("NativeToNative", "Unsafe_CopyBlock"), Benchmark(Baseline = true)]
        public unsafe void NativeToNative_Unsafe_CopyBlock()
        {
            Unsafe.CopyBlock(_nativeDataDestination.ToPointer(), _nativeDataSource.ToPointer(), checked((uint)N));
        }

        [BenchmarkCategory("ManagedToNative", "Marshal_Copy"), Benchmark]
        public void ManagedToNative_Marshal_Copy()
        {
            Marshal.Copy(_managedDataSource, 0, _nativeDataDestination, N);
        }

        [BenchmarkCategory("ManagedToNative", "Buffer_MemoryCopy"), Benchmark]
        public unsafe void ManagedToNative_Buffer_MemoryCopy()
        {
            fixed (byte* pSrc = _managedDataSource)
            {
                Buffer.MemoryCopy(pSrc, _nativeDataDestination.ToPointer(), N, N);
            }
        }

        [BenchmarkCategory("ManagedToNative", "Unsafe_CopyBlock"), Benchmark(Baseline = true)]
        public unsafe void ManagedToNative_Unsafe_CopyBlock()
        {
            fixed (byte* pSrc = _managedDataSource)
            {
                Unsafe.CopyBlock(_nativeDataDestination.ToPointer(), pSrc, checked((uint)N));
            }
        }
    }
}
