﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.AdaBoost.Learning;
using SharpLearning.AdaBoost.Test.Properties;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Classification;
using System.IO;

namespace SharpLearning.AdaBoost.Test.Learning
{
    [TestClass]
    public class ClassificationAdaBoostLearnerTest
    {
        [TestMethod]
        public void ClassificationAdaBoostLearner_Learn_AptitudeData()
        {
            var parser = new CsvParser(() => new StringReader(Resources.AptitudeData));
            var observations = parser.EnumerateRows(v => v != "Pass").ToF64Matrix();
            var targets = parser.EnumerateRows("Pass").ToF64Vector();

            var sut = new ClassificationAdaBoostLearner(10);
            
            var model = sut.Learn(observations, targets);
            var predictions = model.Predict(observations);

            var evaluator = new TotalErrorClassificationMetric<double>();
            var actual = evaluator.Error(targets, predictions);

            Assert.AreEqual(0.038461538461538464, actual);
        }

        [TestMethod]
        public void ClassificationAdaBoostLearner_Learn_Glass()
        {
            var parser = new CsvParser(() => new StringReader(Resources.Glass));
            var observations = parser.EnumerateRows(v => v != "Target").ToF64Matrix();
            var targets = parser.EnumerateRows("Target").ToF64Vector();

            var sut = new ClassificationAdaBoostLearner(10, 1, 5);

            var model = sut.Learn(observations, targets);
            var predictions = model.Predict(observations);

            var evaluator = new TotalErrorClassificationMetric<double>();
            var actual = evaluator.Error(targets, predictions);

            Assert.AreEqual(0.0, actual);
        }
    }
}