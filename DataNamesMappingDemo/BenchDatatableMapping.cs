using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DataNamesMappingDemo.Contracts;
using DataNamesMappingDemo.DataSets;
using DataNamesMappingDemo.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace DataNamesMappingDemo
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [RPlotExporter]
    public class BenchDatatableMapping
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;

        [Params(10,1000,10000,100000)]
        public int N;
        private DataSet priestsDataSet;
        private DataSet ranchersDataSet;

        [GlobalSetup]
        public void Setup()
        {
            priestsDataSet = DataSetGenerator.Priests(N);
            ranchersDataSet = DataSetGenerator.Ranchers(N);
        }

        [Benchmark]
        public void Mapping()
        {
            
            var dt = priestsDataSet.Tables[0];
            DataNamesMapper<Person> mapper = new DataNamesMapper<Person>();
            List<Person> persons = mapper.Map(dt).ToList();

            
            persons.AddRange(mapper.Map(ranchersDataSet.Tables[0]));

            //foreach (var person in persons)
            //{
            //    Console.WriteLine("First Name: " + person.FirstName + ", Last Name: " + person.LastName
            //                      + ", Date of Birth: " + person.DateOfBirth.ToShortDateString()
            //                      + ", Job Title: " + person.JobTitle + ", Nickname: " + person.TakenName
            //                      + ", Is American: " + person.IsAmerican);
            //}

            //Console.ReadLine();
        }
    }
}
