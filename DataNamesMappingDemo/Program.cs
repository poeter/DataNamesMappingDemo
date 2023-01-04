using BenchmarkDotNet.Running;
using DataNamesMappingDemo.Contracts;
using DataNamesMappingDemo.DataSets;
using DataNamesMappingDemo.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataNamesMappingDemo
{
    class Program
    {
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
