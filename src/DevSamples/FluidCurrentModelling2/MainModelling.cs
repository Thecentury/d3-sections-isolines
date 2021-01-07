using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluidCurrentModelling2.DataStructures;
using FluidCurrentModelling2.ModellingMath;
using Microsoft.Research.Science.Data;
using Microsoft.Research.Science.Data.Factory;
//using Microsoft.Research.Science.Data.NetCDF4;

namespace FluidCurrentModelling2
{
    class MainModelling
    {
        static void Main(string[] args)
        {
            NumericalParameters nPar = new NumericalParameters(0.01, 0.02, 0.02, 0.01, 40, 40, 50, 40, 150, 0.78, 1.4);
            FluidCurrentSolver solver = new FluidCurrentSolver(nPar);
            //DataSetFactory.Register(typeof(NetCDFDataSet));
            solver.SolveAll("temp.nc");
            Console.WriteLine("Done!");
        }
    }
}
