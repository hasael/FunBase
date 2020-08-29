using FunBase.ClassInstances;
using Xunit;

namespace FunBase.Tests
{
    public class SumTypeTests
    {
        class FoldBase : SumType<FoldBase, Fold2, Fold3>
        {
            protected override FoldBase Instance => this;
        }
        class FoldBase2 : SumType<FoldBase2, Fold4, Fold5, Fold6>
        {
            protected override FoldBase2 Instance => this;
        }
        class FoldBase3 : SumType<FoldBase3, Fold7, Fold8, Fold9, Fold10>
        {
            protected override FoldBase3 Instance => this;
        }
        class FoldBase4 : SumType<FoldBase4, Fold11, Fold12, Fold13, Fold14, Fold15>
        {
            protected override FoldBase4 Instance => this;
        }

        class FoldBase5 : SumType<FoldBase5, Fold16, Fold17, Fold18, Fold19, Fold20, Fold21>
        {
            protected override FoldBase5 Instance => this;
        }
        class FoldBase6 : SumType<FoldBase6, Fold22, Fold23, Fold24, Fold25, Fold26, Fold27, Fold28>
        {
            protected override FoldBase6 Instance => this;
        }
        class FoldBase7 : SumType<FoldBase7, Fold29, Fold30, Fold31, Fold32, Fold33, Fold34, Fold35, Fold36>
        {
            protected override FoldBase7 Instance => this;
        }
        class FoldBase8 : SumType<FoldBase8, Fold37, Fold38, Fold39, Fold40, Fold41, Fold42, Fold43, Fold44, Fold45>
        {
            protected override FoldBase8 Instance => this;
        }
        class Fold2 : FoldBase { }
        class Fold3 : FoldBase { }
        class Fold4 : FoldBase2 { }
        class Fold5 : FoldBase2 { }
        class Fold6 : FoldBase2 { }
        class Fold7 : FoldBase3 { }
        class Fold8 : FoldBase3 { }
        class Fold9 : FoldBase3 { }
        class Fold10 : FoldBase3 { }
        class Fold11 : FoldBase4 { }
        class Fold12 : FoldBase4 { }
        class Fold13 : FoldBase4 { }
        class Fold14 : FoldBase4 { }
        class Fold15 : FoldBase4 { }
        class Fold16 : FoldBase5 { }
        class Fold17 : FoldBase5 { }
        class Fold18 : FoldBase5 { }
        class Fold19 : FoldBase5 { }
        class Fold20 : FoldBase5 { }
        class Fold21 : FoldBase5 { }
        class Fold22 : FoldBase6 { }
        class Fold23 : FoldBase6 { }
        class Fold24 : FoldBase6 { }
        class Fold25 : FoldBase6 { }
        class Fold26 : FoldBase6 { }
        class Fold27 : FoldBase6 { }
        class Fold28 : FoldBase6 { }
        class Fold29 : FoldBase7 { }
        class Fold30 : FoldBase7 { }
        class Fold31 : FoldBase7 { }
        class Fold32 : FoldBase7 { }
        class Fold33 : FoldBase7 { }
        class Fold34 : FoldBase7 { }
        class Fold35 : FoldBase7 { }
        class Fold36 : FoldBase7 { }
        class Fold37 : FoldBase8 { }
        class Fold38 : FoldBase8 { }
        class Fold39 : FoldBase8 { }
        class Fold40 : FoldBase8 { }
        class Fold41 : FoldBase8 { }
        class Fold42 : FoldBase8 { }
        class Fold43 : FoldBase8 { }
        class Fold44 : FoldBase8 { }
        class Fold45 : FoldBase8 { }

        [Fact]
        public void Fold()
        {
            Fold2 fold2 = new Fold2();
            Fold3 fold3 = new Fold3();

            var actual = fold2.Match((f2) => 1, f3 => 2);
            var actual2 = fold3.Match((f2) => 1, f3 => 2);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
        }

        [Fact]
        public void FoldThreeSums()
        {
            Fold4 fold4 = new Fold4();
            Fold5 fold5 = new Fold5();
            Fold6 fold6 = new Fold6();

            var actual = fold4.Match((f2) => 1, f3 => 2, f4 => 3);
            var actual2 = fold5.Match((f2) => 1, f3 => 2, f4 => 3);
            var actual3 = fold6.Match((f2) => 1, f3 => 2, f4 => 3);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
        }

        [Fact]
        public void FoldFourSums()
        {
            Fold7 fold7 = new Fold7();
            Fold8 fold8 = new Fold8();
            Fold9 fold9 = new Fold9();
            Fold10 fold10 = new Fold10();

            var actual = fold7.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4);
            var actual2 = fold8.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4);
            var actual3 = fold9.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4);
            var actual4 = fold10.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
        }

        [Fact]
        public void FoldFiveSums()
        {
            Fold11 fold11 = new Fold11();
            Fold12 fold12 = new Fold12();
            Fold13 fold13 = new Fold13();
            Fold14 fold14 = new Fold14();
            Fold15 fold15 = new Fold15();

            var actual = fold11.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5);
            var actual2 = fold12.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5);
            var actual3 = fold13.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5);
            var actual4 = fold14.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5);
            var actual5 = fold15.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
        }

        [Fact]
        public void FoldSixSums()
        {
            Fold16 fold16 = new Fold16();
            Fold17 fold17 = new Fold17();
            Fold18 fold18 = new Fold18();
            Fold19 fold19 = new Fold19();
            Fold20 fold20 = new Fold20();
            Fold21 fold21 = new Fold21();

            var actual = fold16.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6);
            var actual2 = fold17.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6);
            var actual3 = fold18.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6);
            var actual4 = fold19.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6);
            var actual5 = fold20.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6);
            var actual6 = fold21.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
            Assert.Equal(6, actual6);
        }

        [Fact]
        public void FoldSevenSums()
        {
            Fold22 fold22 = new Fold22();
            Fold23 fold23 = new Fold23();
            Fold24 fold24 = new Fold24();
            Fold25 fold25 = new Fold25();
            Fold26 fold26 = new Fold26();
            Fold27 fold27 = new Fold27();
            Fold28 fold28 = new Fold28();

            var actual = fold22.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);
            var actual2 = fold23.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);
            var actual3 = fold24.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);
            var actual4 = fold25.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);
            var actual5 = fold26.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);
            var actual6 = fold27.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);
            var actual7 = fold28.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
            Assert.Equal(6, actual6);
            Assert.Equal(7, actual7);
        }

        [Fact]
        public void FoldEightSums()
        {
            Fold29 fold29 = new Fold29();
            Fold30 fold30 = new Fold30();
            Fold31 fold31 = new Fold31();
            Fold32 fold32 = new Fold32();
            Fold33 fold33 = new Fold33();
            Fold34 fold34 = new Fold34();
            Fold35 fold35 = new Fold35();
            Fold36 fold36 = new Fold36();

            var actual = fold29.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual2 = fold30.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual3 = fold31.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual4 = fold32.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual5 = fold33.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual6 = fold34.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual7 = fold35.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);
            var actual8 = fold36.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8);

            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
            Assert.Equal(6, actual6);
            Assert.Equal(7, actual7);
            Assert.Equal(8, actual8);
        }

        [Fact]
        public void FoldNineSums()
        {
            Fold37 fold37 = new Fold37();
            Fold38 fold38 = new Fold38();
            Fold39 fold39 = new Fold39();
            Fold40 fold40 = new Fold40();
            Fold41 fold41 = new Fold41();
            Fold42 fold42 = new Fold42();
            Fold43 fold43 = new Fold43();
            Fold44 fold44 = new Fold44();
            Fold45 fold45 = new Fold45();

            var actual = fold37.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 =>9);
            var actual2 = fold38.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual3 = fold39.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual4 = fold40.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual5 = fold41.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual6 = fold42.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual7 = fold43.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual8 = fold44.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);
            var actual9 = fold45.Match((f2) => 1, f3 => 2, f4 => 3, f5 => 4, f6 => 5, f7 => 6, f8 => 7, f9 => 8, f10 => 9);


            Assert.Equal(1, actual);
            Assert.Equal(2, actual2);
            Assert.Equal(3, actual3);
            Assert.Equal(4, actual4);
            Assert.Equal(5, actual5);
            Assert.Equal(6, actual6);
            Assert.Equal(7, actual7);
            Assert.Equal(8, actual8);
            Assert.Equal(9, actual9);
        }
    }
}
