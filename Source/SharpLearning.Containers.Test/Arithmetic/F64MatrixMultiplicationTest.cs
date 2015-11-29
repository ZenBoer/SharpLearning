﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.Containers.Arithmetic;
using SharpLearning.Containers.Matrices;

namespace SharpLearning.Containers.Test.Arithmetic
{
    [TestClass]
    public class F64MatrixMultiplicationTest
    {
        [TestMethod]
        public void F64MatrixMultiplication_MultiplyVectorF64Multiply()
        {
            var a = new F64Matrix(new double[4] { 1, 2, 3, 4 }, 2, 2);
            var v = new double[2] { 1, 2 };

            var c = a.Multiply(v);

            var expected = new double[] { 5.0, 11.0 };
            CollectionAssert.AreEqual(expected, c);
        }

        [TestMethod]
        public void F64MatrixMultiplication_MultiplyVectorF64Multiply_Predefined()
        {
            var a = new F64Matrix(new double[4] { 1, 2, 3, 4 }, 2, 2);
            var v = new double[2] { 1, 2 };
            var actual = new double[2];

            MatrixMultiplication.MultiplyVectorF64(a, v, actual);

            var expected = new double[] { 5.0, 11.0 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void F64MatrixMultiplication_MultiplyTransposeVectorF64Multiply_Predefined()
        {
            var a = new F64Matrix(new double[] { 1, 3, 5, 2, 4, 6 }, 2, 3);
            var v = new double[] { 1, 2 };
            var actual = new double[3];

            MatrixMultiplication.MultiplyTransposeVectorF64(a, v, actual);

            var expected = new double[] { 5.0, 11.0, 17.0 };
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void F64MatrixMultiplication_F64MatrixMultiply()
        {
            var a = new F64Matrix(new double[6] { 1, 2, 3, 4, 5, 6 }, 2, 3);
            var b = new F64Matrix(new double[6] { 7, 8, 9, 10, 11, 12 }, 3, 2);

            var c = a.Multiply(b);

            var expected = new F64Matrix(new double[4] { 58, 64, 139, 154 }, 2, 2);
            Assert.AreEqual(expected, c);
        }

        [TestMethod]
        public void F64MatrixMultiplication_F64MatrixMultiplyTransposeSecond()
        {
            var a = new F64Matrix(new double[6] { 0, 3, 5, 5, 5, 2 }, 2, 3);
            var bT = new F64Matrix(new double[6] { 3, 3, 4, 4, -2, -2 }, 2, 3);
            var c = new F64Matrix(2, 2);

            MatrixMultiplication.MultiplyTransposeSecondF64(a, bT, c);
            
            var expected = new F64Matrix(new double[4] { 29, -16, 38, 6 }, 2, 2);
            Assert.AreEqual(expected, c);

        }

        [TestMethod]
        public void F64MatrixMultiplication_F64MatrixMultiplyTransposeFirst()
        {
            var aT = new F64Matrix(new double[6] { 0, 3, 5, 5, 5, 2 }, 2, 3);
            var b = new F64Matrix(new double[6] { 3, 3, 4, 4, -2, -2 }, 2, 3);
            var c = new F64Matrix(3, 3);

            MatrixMultiplication.MultiplyTransposeFirstF64(aT, b, c);

            var expected = new F64Matrix(new double[] { 20, -10, -10, 29, -1, 2, 23, 11, 16 }, 3, 3);
            Assert.AreEqual(expected, c);

        }

        [TestMethod]
        public void F64MatrixMultiplication_F64MatrixMultiply_Predefined()
        {
            var a = new F64Matrix(new double[6] { 1, 2, 3, 4, 5, 6 }, 2, 3);
            var b = new F64Matrix(new double[6] { 7, 8, 9, 10, 11, 12 }, 3, 2);

            var actual = new F64Matrix(a.GetNumberOfRows(), b.GetNumberOfColumns());

            MatrixMultiplication.MultiplyF64(a, b, actual);

            var expected = new F64Matrix(new double[4] { 58, 64, 139, 154 }, 2, 2);
            Assert.AreEqual(expected, actual);
        }
    }
}
