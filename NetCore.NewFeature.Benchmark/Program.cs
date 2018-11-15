using BenchmarkDotNet.Running;
using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace NetCore.NewFeature.Benchmark
{
    public class Program
    {
        public static unsafe void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Copy>();
            //simpleTest();
            //Console.ReadKey();
        }

        private static void display(Span<byte> data, int maxLen = 16)
        {
            var lenDisplay = Math.Min(data.Length, maxLen);
            var sb = new StringBuilder();
            for (var index = 0; index < lenDisplay; ++index)
            {
                sb.Append($"{data[index]} ");
            }
            Console.WriteLine(sb.ToString());
        }

        private static unsafe void simpleTest()
        {
            const int Length = 102400000;
            var ptr = Marshal.AllocHGlobal(Length);
            var spanSource = new Span<byte>(ptr.ToPointer(), Length);
            new Random(42).NextBytes(spanSource);

            var dstArray = new byte[Length];
            var dstArray2 = new byte[Length];

            fixed (byte* p1 = spanSource, p2 = dstArray, p3 = dstArray2)
            {
                Buffer.MemoryCopy(p1, p2, Length, Length);
                Unsafe.CopyBlock(p3, p1, Length);
            }

            var memOwner = MemoryPool<byte>.Shared.Rent(Length);
            var memOwner2 = MemoryPool<byte>.Shared.Rent(Length);
            var mem = memOwner.Memory;
            var mem2 = memOwner2.Memory;
            fixed (byte* p1 = spanSource)
            {
                using (var handle = mem.Pin())
                {
                    Buffer.MemoryCopy(p1, handle.Pointer, mem.Length, Length);
                }
                using (var handle = mem2.Pin())
                {
                    Unsafe.CopyBlock(handle.Pointer, p1, Length);
                }
            }

            ////Unsafe.CopyBlock ref version
            //var refArraySrc = new byte[Length];
            //var refArrayDest = new byte[Length];
            //new Random(42).NextBytes(refArraySrc);
            //Unsafe.CopyBlock(ref refArrayDest[0], ref refArraySrc[0], Length);

            display(spanSource);
            display(dstArray);
            display(dstArray2);
            display(mem.Span.Slice(0, Length));
            display(mem2.Span.Slice(0, Length));

            if (spanSource.SequenceEqual(dstArray) &&
                spanSource.SequenceEqual(dstArray2) &&
                spanSource.SequenceEqual(mem.Span.Slice(0, Length)) &&
               spanSource.SequenceEqual(mem2.Span.Slice(0, Length)) /*&&
                    new Span<byte>(refArraySrc).SequenceEqual(refArrayDest)*/)
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }

            Marshal.FreeHGlobal(ptr);
            memOwner.Dispose();
            memOwner2.Dispose();

            Console.ReadKey();
        }
    }
}
