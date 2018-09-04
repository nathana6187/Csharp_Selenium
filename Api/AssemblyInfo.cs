/*
 * https://www.meziantou.net/2018/03/01/mstest-v2-execute-tests-in-parallel
 * Allow tests to be executed in parallel.
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 3, Scope = ExecutionScope.MethodLevel)]