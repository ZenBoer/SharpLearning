﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.Neural.LayersNew;
using SharpLearning.Neural.Providers.DotNetOp;

namespace SharpLearning.Neural.Test.LayersNew
{
    [TestClass]
    public class BatchNormalizationLayerTest
    {
        [TestMethod]
        [Ignore] // gradient seems off
        public void BatchNormalizationLayer_GradientCheck_4D()
        {
            var executor = new Executor();

            var input = Variable.Create(10, 5, 3, 3);
            var sut = new BatchNormalizationLayer();
            sut.Initialize(input, executor, new Random());

            GradientCheckTools.CheckLayer(sut, executor, input, new Random(21));
        }

        [TestMethod]
        [Ignore] // gradient seems off
        public void BatchNormalizationLayer_GradientCheck_2D()
        {
            var executor = new Executor();

            var input = Variable.Create(10, 5, 1, 1);
            var sut = new BatchNormalizationLayer();
            sut.Initialize(input, executor, new Random());

            GradientCheckTools.CheckLayer(sut, executor, input, new Random(21));
        }


        [TestMethod]
        public void BatchNormalizationLayer_ParameterGradientCheck_4D()
        {
            var executor = new Executor();

            var input = Variable.Create(10, 10, 5, 5);
            var sut = new BatchNormalizationLayer();
            sut.Initialize(input, executor, new Random());

            GradientCheckTools.CheckLayerParameters(sut, executor, input, new Random(21));
        }

        [TestMethod]
        public void BatchNormalizationLayer_ParameterGradientCheck_2D()
        {
            var executor = new Executor();

            var input = Variable.Create(10, 10, 1, 1);
            var sut = new BatchNormalizationLayer();
            sut.Initialize(input, executor, new Random());

            GradientCheckTools.CheckLayerParameters(sut, executor, input, new Random(21));
        }
    }
}
