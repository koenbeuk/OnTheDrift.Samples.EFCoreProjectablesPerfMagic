using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using OnTheDrift.Samples.EFCoreProjectablesPerfMagic;

BenchmarkSwitcher.FromAssembly(typeof(FullNameBenchmark).Assembly).Run(args, DefaultConfig.Instance.WithOption(ConfigOptions.Default, true));
