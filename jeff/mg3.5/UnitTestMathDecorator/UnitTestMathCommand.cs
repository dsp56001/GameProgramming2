using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorSample;

namespace UnitTestMathDecorator
{
    [TestClass]
    public class UnitTestMathCommand
    {
        MathDecorator md;
        IMathComponent a1;
        IMathComponent a2;
        IMathComponent a3;

        public UnitTestMathCommand()
        {
            md = new MathDecorator();
            a1 = new AddOne();
            a2 = new AddTwo();
            a3 = new AddThree();

        }


        [TestMethod]
        public void TestMathCommandAddComponent()
        {
            //Arrange
            int addOneResult, addTwoResult, addThreeResult;
            int addOneExpected, addTwoExpected, addThreeExpected;
            addOneExpected = 1;
            addTwoExpected = 2;
            addThreeExpected = 3;
            //Act
            md = new MathDecorator();
            md.AddComponent(a1);
            addOneResult = md.Calculate();
            md = new MathDecorator();
            md.AddComponent(a2);
            addTwoResult = md.Calculate();
            md = new MathDecorator();
            md.AddComponent(a3);
            addThreeResult = md.Calculate();

            //Assert
            Assert.AreEqual(addOneExpected, addOneResult);
            Assert.AreEqual(addTwoExpected, addTwoResult);
            Assert.AreEqual(addThreeExpected, addThreeResult);
        }

        [TestMethod]
        public void TestMathCommandAddRemoveComponent()
        {
            //Arrange
            int addOneResult, addTwoResult, addThreeResult;
            int addOneExpected, addTwoExpected, addThreeExpected;
            addOneExpected = 1;
            addTwoExpected = 2;
            addThreeExpected = 3;
            //Act
            md = new MathDecorator();
            md.AddComponent(a1);
            md.AddComponent(a1);
            md.RemoveComponetn(a1);
            addOneResult = md.Calculate();
            md = new MathDecorator();
            md.AddComponent(a1);
            md.RemoveComponetn(a1);
            md.AddComponent(a2);
            addTwoResult = md.Calculate();
            md = new MathDecorator();
            md.AddComponent(a1);
            md.AddComponent(a2);
            md.AddComponent(a3);
            md.RemoveComponetn(a1);
            md.RemoveComponetn(a2);
            addThreeResult = md.Calculate();

            //Assert
            Assert.AreEqual(addOneExpected, addOneResult);
            Assert.AreEqual(addTwoExpected, addTwoResult);
            Assert.AreEqual(addThreeExpected, addThreeResult);
        }

        [TestMethod]
        public void TestMathCommandAddMultipleComponent()
        {
            //Arrange
            int addAllResult;
            int addAllExpected;
            
            addAllExpected = 1+2+3;
            //Act
            md = new MathDecorator();
            md.AddComponent(a1);
            md.AddComponent(a2);
            md.AddComponent(a3);
            addAllResult = md.Calculate();

            //Assert
            Assert.AreEqual(addAllExpected, addAllResult);
        }
    }
}
