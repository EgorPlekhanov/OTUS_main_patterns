using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceBattle;
using SpaceBattle.Adapters;
using SpaceBattle.Contracts;
using SpaceBattle.GameObjects;
using System;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Набор тестов для домашки № 2 (движение объектов по игровому полю)
    /// </summary>
    [TestClass]
    public class MoveObjectTests
    {
        /// <summary>
        /// Тест на то, что с заданым направлением и заданной скоростью объект будет в правильно посчитаной точке
        /// </summary>
        /// <remarks>Для удобства сделал разделение окружности на 8 частей. По уловиям скорость (-7, 3), 
        /// но тогда нужно задать объекту угол 157 градусов, а там при расчётах будут уже дробные числа.
        /// Поэтому скорость будет (-7, 7) и ожидаемый результат соответственно (5, 12)</remarks>
        [TestMethod]
        public void CorrectlyMoveGameObject()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IMovable.Position), (12, 5));
            gameObject.SetProperty(Constants.VELOCITY, 10);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 8);
            gameObject.SetProperty(nameof(IRotatable.Direction), 3);
            IMovable moveCommand = new MovableAdapter(gameObject);
            ValueTuple<int, int> expectedPosition = (5, 12);

            moveCommand.Execute();

            Assert.AreEqual(expectedPosition, gameObject.GetProperty(nameof(IMovable.Position)),
                "Ошибка при вычислении итоговой позиции после прямолинейного движения с заданной скоростью");
        }

        /// <summary>
        /// Попытка сдвинуть объект, у которого невозможно прочитать положение в пространстве, приводит к ошибке
        /// </summary>
        [TestMethod]
        public void DontSetPosition()
        {
            IGameObject gameObject = new Spaceship();
            IMovable moveCommand = new MovableAdapter(gameObject);

            Assert.ThrowsException<KeyNotFoundException>(moveCommand.Execute);
        }

        /// <summary>
        /// Попытка сдвинуть объект, у которого невозможно прочитать значение мгновенной скорости, приводит к ошибке
        /// </summary>
        [TestMethod]
        public void DontSetVelocity()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IMovable.Position), (12, 5));
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 8);
            gameObject.SetProperty(nameof(IRotatable.Direction), 3);
            IMovable moveCommand = new MovableAdapter(gameObject);

            Assert.ThrowsException<KeyNotFoundException>(moveCommand.Execute);
        }

        /// <summary>
        /// Попытка сдвинуть объект, у которого невозможно изменить положение в пространстве, приводит к ошибке
        /// </summary>
        [TestMethod]
        public void DontChangePosition()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IMovable.Position), (12, 5));
            gameObject.SetProperty(Constants.VELOCITY, 10);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 0);
            gameObject.SetProperty(nameof(IRotatable.Direction), 3);
            IMovable moveCommand = new MovableAdapter(gameObject);

            Assert.ThrowsException<OverflowException>(moveCommand.Execute);
        }
    }
}
