``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 7 SP1 (6.1.7601.0)
Intel Core i5-3380M CPU 2.90GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
Frequency=2825732 Hz, Resolution=353.8906 ns, Timer=TSC
.NET Core SDK=2.1.403
  [Host] : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
  Core   : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|                             Method |       Categories |          N |               Mean |             Error |             StdDev |             Median | Scaled | ScaledSD | Rank |
|----------------------------------- |----------------- |----------- |-------------------:|------------------:|-------------------:|-------------------:|-------:|---------:|-----:|
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** |         **16** |           **5.354 ns** |         **0.0347 ns** |          **0.0308 ns** |           **5.353 ns** |   **1.19** |     **0.05** |    **2** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged |         16 |           6.979 ns |         0.0523 ns |          0.0489 ns |           6.967 ns |   1.55 |     0.06 |    3 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged |         16 |           4.499 ns |         0.1311 ns |          0.2154 ns |           4.454 ns |   1.00 |     0.00 |    1 |
|        ManagedToManaged_Array_Copy | ManagedToManaged |         16 |          21.286 ns |         0.1969 ns |          0.1745 ns |          21.278 ns |   4.74 |     0.18 |    4 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged |         16 |          13.335 ns |         0.0576 ns |          0.0481 ns |          13.346 ns |   4.31 |     0.05 |    3 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged |         16 |           4.555 ns |         0.0265 ns |          0.0248 ns |           4.557 ns |   1.47 |     0.02 |    2 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged |         16 |           3.095 ns |         0.0369 ns |          0.0346 ns |           3.088 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative |         16 |           2.852 ns |         0.0296 ns |          0.0263 ns |           2.852 ns |   1.45 |     0.02 |    2 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative |         16 |           1.971 ns |         0.0233 ns |          0.0195 ns |           1.970 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative |         16 |          15.297 ns |         0.1138 ns |          0.1009 ns |          15.287 ns |   4.88 |     0.08 |    3 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative |         16 |           4.261 ns |         0.0503 ns |          0.0446 ns |           4.258 ns |   1.36 |     0.03 |    2 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative |         16 |           3.133 ns |         0.0543 ns |          0.0508 ns |           3.115 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** |         **32** |           **5.365 ns** |         **0.1398 ns** |          **0.1373 ns** |           **5.366 ns** |   **1.14** |     **0.03** |    **2** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged |         32 |           7.514 ns |         0.1748 ns |          0.1635 ns |           7.493 ns |   1.59 |     0.04 |    3 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged |         32 |           4.716 ns |         0.0576 ns |          0.0511 ns |           4.719 ns |   1.00 |     0.00 |    1 |
|        ManagedToManaged_Array_Copy | ManagedToManaged |         32 |          20.552 ns |         0.1006 ns |          0.0840 ns |          20.558 ns |   4.36 |     0.05 |    4 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged |         32 |          13.510 ns |         0.1332 ns |          0.1246 ns |          13.516 ns |   3.98 |     0.05 |    3 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged |         32 |           4.307 ns |         0.0516 ns |          0.0403 ns |           4.317 ns |   1.27 |     0.02 |    2 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged |         32 |           3.391 ns |         0.0296 ns |          0.0277 ns |           3.389 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative |         32 |           2.552 ns |         0.1220 ns |          0.1788 ns |           2.505 ns |   1.15 |     0.08 |    2 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative |         32 |           2.228 ns |         0.0146 ns |          0.0136 ns |           2.234 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative |         32 |          14.585 ns |         0.0434 ns |          0.0385 ns |          14.598 ns |   4.37 |     0.01 |    3 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative |         32 |           3.967 ns |         0.0277 ns |          0.0259 ns |           3.961 ns |   1.19 |     0.01 |    2 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative |         32 |           3.335 ns |         0.0027 ns |          0.0023 ns |           3.335 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** |         **64** |           **6.606 ns** |         **0.0547 ns** |          **0.0511 ns** |           **6.598 ns** |   **1.31** |     **0.01** |    **2** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged |         64 |           7.509 ns |         0.0430 ns |          0.0403 ns |           7.504 ns |   1.49 |     0.01 |    3 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged |         64 |           5.052 ns |         0.0222 ns |          0.0207 ns |           5.049 ns |   1.00 |     0.00 |    1 |
|        ManagedToManaged_Array_Copy | ManagedToManaged |         64 |          24.749 ns |         0.5841 ns |          0.9264 ns |          24.191 ns |   4.90 |     0.18 |    4 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged |         64 |          16.285 ns |         0.1071 ns |          0.0950 ns |          16.289 ns |   4.64 |     0.04 |    3 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged |         64 |           4.922 ns |         0.0319 ns |          0.0283 ns |           4.910 ns |   1.40 |     0.01 |    2 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged |         64 |           3.506 ns |         0.0247 ns |          0.0231 ns |           3.493 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative |         64 |           3.108 ns |         0.0232 ns |          0.0217 ns |           3.107 ns |   1.07 |     0.01 |    2 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative |         64 |           2.917 ns |         0.0143 ns |          0.0133 ns |           2.911 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative |         64 |          18.480 ns |         0.0734 ns |          0.0613 ns |          18.498 ns |   4.74 |     0.06 |    3 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative |         64 |           5.025 ns |         0.0359 ns |          0.0335 ns |           5.012 ns |   1.29 |     0.02 |    2 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative |         64 |           3.900 ns |         0.0566 ns |          0.0529 ns |           3.889 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** |       **2048** |          **63.409 ns** |         **0.2898 ns** |          **0.2711 ns** |          **63.371 ns** |   **0.87** |     **0.00** |    **1** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged |       2048 |          71.704 ns |         0.2955 ns |          0.2764 ns |          71.717 ns |   0.99 |     0.00 |    2 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged |       2048 |          72.534 ns |         0.0569 ns |          0.0444 ns |          72.521 ns |   1.00 |     0.00 |    3 |
|        ManagedToManaged_Array_Copy | ManagedToManaged |       2048 |          85.030 ns |         0.3801 ns |          0.3556 ns |          84.827 ns |   1.17 |     0.00 |    4 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged |       2048 |          79.264 ns |         0.3426 ns |          0.3204 ns |          79.231 ns |   1.35 |     0.01 |    3 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged |       2048 |          54.394 ns |         0.3481 ns |          0.3256 ns |          54.236 ns |   0.92 |     0.01 |    1 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged |       2048 |          58.849 ns |         0.2718 ns |          0.2542 ns |          58.727 ns |   1.00 |     0.00 |    2 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative |       2048 |          48.117 ns |         0.2581 ns |          0.2414 ns |          48.160 ns |   0.97 |     0.01 |    1 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative |       2048 |          49.404 ns |         0.4443 ns |          0.4156 ns |          49.209 ns |   1.00 |     0.00 |    2 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative |       2048 |          69.634 ns |         0.4676 ns |          0.4374 ns |          69.387 ns |   1.24 |     0.01 |    3 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative |       2048 |          51.006 ns |         0.2926 ns |          0.2737 ns |          51.033 ns |   0.91 |     0.01 |    1 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative |       2048 |          56.144 ns |         0.2802 ns |          0.2484 ns |          55.997 ns |   1.00 |     0.00 |    2 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** |       **4096** |         **154.554 ns** |         **0.8328 ns** |          **0.7790 ns** |         **154.511 ns** |   **1.05** |     **0.01** |    **3** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged |       4096 |         151.426 ns |         0.5010 ns |          0.4686 ns |         151.254 ns |   1.03 |     0.00 |    2 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged |       4096 |         147.173 ns |         0.2111 ns |          0.1763 ns |         147.181 ns |   1.00 |     0.00 |    1 |
|        ManagedToManaged_Array_Copy | ManagedToManaged |       4096 |         163.294 ns |         1.0198 ns |          0.9539 ns |         163.327 ns |   1.11 |     0.01 |    4 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged |       4096 |         130.888 ns |         0.5514 ns |          0.4888 ns |         130.909 ns |   1.16 |     0.01 |    3 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged |       4096 |         122.242 ns |         0.5209 ns |          0.4873 ns |         122.243 ns |   1.09 |     0.01 |    2 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged |       4096 |         112.471 ns |         0.4672 ns |          0.4141 ns |         112.265 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative |       4096 |         100.370 ns |         0.4559 ns |          0.4042 ns |         100.369 ns |   1.06 |     0.00 |    2 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative |       4096 |          95.092 ns |         0.0524 ns |          0.0437 ns |          95.080 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative |       4096 |         105.856 ns |         0.5388 ns |          0.5040 ns |         105.696 ns |   1.12 |     0.01 |    3 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative |       4096 |         102.353 ns |         0.4206 ns |          0.3934 ns |         102.317 ns |   1.09 |     0.01 |    2 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative |       4096 |          94.205 ns |         0.4910 ns |          0.4100 ns |          94.049 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** |    **1048576** |      **55,497.886 ns** |       **265.8953 ns** |        **248.7186 ns** |      **55,426.023 ns** |   **1.03** |     **0.01** |    **3** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged |    1048576 |      55,614.998 ns |       428.6456 ns |        400.9553 ns |      55,473.560 ns |   1.03 |     0.01 |    3 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged |    1048576 |      54,114.210 ns |       185.6558 ns |        173.6626 ns |      54,125.640 ns |   1.00 |     0.00 |    1 |
|        ManagedToManaged_Array_Copy | ManagedToManaged |    1048576 |      54,270.351 ns |        87.2985 ns |         68.1570 ns |      54,255.692 ns |   1.00 |     0.00 |    2 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged |    1048576 |      53,042.736 ns |       413.5969 ns |        345.3722 ns |      52,862.099 ns |   0.98 |     0.01 |    2 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged |    1048576 |      51,525.356 ns |       178.2870 ns |        166.7698 ns |      51,517.361 ns |   0.95 |     0.00 |    1 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged |    1048576 |      54,001.934 ns |       243.9814 ns |        190.4846 ns |      54,012.487 ns |   1.00 |     0.00 |    3 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative |    1048576 |      53,615.916 ns |       186.3349 ns |        165.1810 ns |      53,638.941 ns |   1.02 |     0.01 |    2 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative |    1048576 |      52,616.891 ns |       384.0694 ns |        359.2588 ns |      52,458.194 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative |    1048576 |      55,295.252 ns |       761.3316 ns |        674.9005 ns |      55,129.003 ns |   1.08 |     0.01 |    3 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative |    1048576 |      54,897.380 ns |        61.0168 ns |         50.9518 ns |      54,887.350 ns |   1.07 |     0.01 |    2 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative |    1048576 |      51,232.847 ns |       320.6318 ns |        267.7421 ns |      51,156.918 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
| **ManagedToManaged_Buffer_MemoryCopy** | **ManagedToManaged** | **1073741824** | **132,797,633.229 ns** | **2,649,502.4417 ns** |  **7,472,968.6454 ns** | **128,145,025.785 ns** |   **0.89** |     **0.10** |    **1** |
|  ManagedToManaged_Buffer_BlockCopy | ManagedToManaged | 1073741824 | 135,612,995.146 ns | 3,009,797.6822 ns |  8,874,456.3741 ns | 135,321,219.420 ns |   0.90 |     0.10 |    2 |
|  ManagedToManaged_Unsafe_CopyBlock | ManagedToManaged | 1073741824 | 151,219,004.492 ns | 4,667,259.5321 ns | 13,761,520.0345 ns | 150,443,495.705 ns |   1.00 |     0.00 |    4 |
|        ManagedToManaged_Array_Copy | ManagedToManaged | 1073741824 | 140,133,862.659 ns | 3,497,986.0424 ns | 10,313,890.7686 ns | 144,103,014.720 ns |   0.93 |     0.11 |    3 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|            NativeToManaged_Marshal |  NativeToManaged | 1073741824 | 140,871,085.202 ns | 2,385,891.7595 ns |  2,231,764.4150 ns | 139,850,842.190 ns |   1.00 |     0.02 |    1 |
|  NativeToManaged_Buffer_MemoryCopy |  NativeToManaged | 1073741824 | 140,903,831.881 ns | 2,424,121.8024 ns |  2,267,524.8173 ns | 140,126,522.970 ns |   1.00 |     0.02 |    1 |
|   NativeToManaged_Unsafe_CopyBlock |  NativeToManaged | 1073741824 | 141,330,458.799 ns | 2,351,833.9214 ns |  2,199,906.6952 ns | 141,977,370.820 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|   NativeToNative_Buffer_MemoryCopy |   NativeToNative | 1073741824 | 134,791,314.251 ns | 3,262,286.7803 ns |  9,618,926.1763 ns | 130,335,431.665 ns |   1.01 |     0.10 |    1 |
|    NativeToNative_Unsafe_CopyBlock |   NativeToNative | 1073741824 | 133,476,242.616 ns | 2,881,082.8088 ns |  8,494,937.6657 ns | 128,490,246.065 ns |   1.00 |     0.00 |    1 |
|                                    |                  |            |                    |                   |                    |                    |        |          |      |
|       ManagedToNative_Marshal_Copy |  ManagedToNative | 1073741824 | 146,325,624.652 ns | 2,742,410.1251 ns |  2,693,413.1778 ns | 147,257,772.495 ns |   1.01 |     0.03 |    1 |
|  ManagedToNative_Buffer_MemoryCopy |  ManagedToNative | 1073741824 | 146,519,556.703 ns | 2,738,562.7138 ns |  2,561,653.0124 ns | 147,100,998.960 ns |   1.01 |     0.03 |    1 |
|   ManagedToNative_Unsafe_CopyBlock |  ManagedToNative | 1073741824 | 145,228,168.260 ns | 2,851,271.7292 ns |  2,928,045.8668 ns | 144,861,579.230 ns |   1.00 |     0.00 |    1 |
