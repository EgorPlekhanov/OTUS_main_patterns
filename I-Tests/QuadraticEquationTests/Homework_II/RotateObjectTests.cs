using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceBattle.Adapters;
using SpaceBattle.Contracts;
using SpaceBattle.GameObjects;
using System;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Набор тестов для домашки № 2 (поворот объекта)
    /// </summary>
    [TestClass]
    public class RotateObjectTests
    {
        [TestInitialize] public void Init() => GC.Collect();

        /// <summary>
        /// Для объекта, повернутого на 45 градусов (значение 1, значит всего 8 углов) 10 поворотов меняет направление на 75 градусов (значение 3)
        /// </summary>
        [TestMethod]
        public void CorrectlyRotateGameObject()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IRotatable.Direction), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCountPerStep), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 8);
            IRotatable rotateCommand = new RotatableAdapter(gameObject);
            int expectedDirection = 3;

            for (int i = 0; i < 10; i++)
                rotateCommand.Execute();

            Assert.AreEqual(expectedDirection, gameObject.GetProperty(nameof(IRotatable.Direction)),
                "Ошибка при вычислении итоговой позиции после 10-ти поворотов с заданным ");
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно прочитать направление, приводит к ошибке
        /// </summary>
        [TestMethod]
        public void DontSetDirection()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IRotatable.DirectionsCountPerStep), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 8);
            IRotatable rotateCommand = new RotatableAdapter(gameObject);

            Assert.ThrowsException<KeyNotFoundException>(rotateCommand.Execute);
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно прочитать кол-во углов за шаг, приводит к ошибке
        /// </summary>
        [TestMethod]
        public void DontSetDirectionsCountPerStep()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IRotatable.Direction), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 8);
            IRotatable rotateCommand = new RotatableAdapter(gameObject);

            Assert.ThrowsException<KeyNotFoundException>(rotateCommand.Execute);
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно прочитать кол-во углов, приводит к ошибке
        /// </summary>
        [TestMethod]
        public void DontSetDirectionsCount()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IRotatable.Direction), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCountPerStep), 1);
            IRotatable rotateCommand = new RotatableAdapter(gameObject);

            Assert.ThrowsException<KeyNotFoundException>(rotateCommand.Execute);
        }

        /// <summary>
        /// Ошибка при задании кол-ва углов меньше 1
        /// </summary>
        [TestMethod]
        public void SetDirectionsCountLessThan1()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IRotatable.Direction), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCountPerStep), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), -2);
            IRotatable rotateCommand = new RotatableAdapter(gameObject);

            Assert.ThrowsException<Exception>(rotateCommand.Execute);
        }

        /// <summary>
        /// Ошибка при задании шага поворота меньше 1
        /// </summary>
        [TestMethod]
        public void SetDirectionsCountPerStepLessThan1()
        {
            IGameObject gameObject = new Spaceship();
            gameObject.SetProperty(nameof(IRotatable.Direction), 1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCountPerStep), -1);
            gameObject.SetProperty(nameof(IRotatable.DirectionsCount), 0);
            IRotatable rotateCommand = new RotatableAdapter(gameObject);

            Assert.ThrowsException<Exception>(rotateCommand.Execute);
        }
    }
}
