﻿using System;
using System.Collections.Generic;
using NBench.Util;
using NBench;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjManAPI.Tests
{
    public class NBench
    {
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 10000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void Benchmark()
        {
            _counter.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }
    }
}
