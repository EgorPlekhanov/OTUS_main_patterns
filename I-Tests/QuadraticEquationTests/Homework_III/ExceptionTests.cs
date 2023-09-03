using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceBattle;
using SpaceBattle.Adapters;
using SpaceBattle.Contracts;
using SpaceBattle.Exceptions;
using SpaceBattle.GameObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Homework_III
{
    /// <summary>
    /// Набор тестов для домашки № 3 (солидная обработка ошибок)
    /// </summary>
    [TestClass]
    public class ExceptionTests
    {
        private IGameObject spaceship;
        private readonly ConcurrentQueue<ICommand> queue = new();
        private readonly IList<string> loggerMessages = new List<string>();
        //private DefaultExceptionHandler defaultExceptionHandler;
        //private AddCommandToQueueExceptionHandler addCommandToQueueExceptionHandler;
        //private RepeatAndLogExceptionHandler repeatAndLogExceptionHandler;

        [TestInitialize]
        public void Init()
        {
            spaceship = new Spaceship();
            spaceship.SetProperty(nameof(IRotatable.Direction), 1);
            // Специально задаём невалидное значение, чтобы вызвать ошибку
            spaceship.SetProperty(nameof(IRotatable.DirectionsCountPerStep), -2);
            spaceship.SetProperty(nameof(IRotatable.DirectionsCount), 8);
            spaceship.SetProperty(nameof(IMovable.Position), (12, 5));
            spaceship.SetProperty(Constants.VELOCITY, 10);

            queue.Enqueue(new MovableAdapter(spaceship));
            queue.Enqueue(new RotatableAdapter(spaceship));
            queue.Enqueue(new MovableAdapter(spaceship));
        }

        [TestCleanup]
        public void Clean()
        {
            queue.Clear();
            loggerMessages.Clear();
        }

        /// <summary>
        /// Вызов команды, которая записывает информацию о выброшенном исключении в лог
        /// </summary>
        [TestMethod]
        public void WriteLogAfterException()
        {
            var commandTypeExceptionHandlers = new Dictionary<Type, IDictionary<Type, Func<Exception, ICommand>>>()
            {
                { typeof(RotatableAdapter),
                    new Dictionary<Type, Func<Exception, ICommand>>()
                    {{ typeof(InvalidInputValueException), (exception) => new LogExceptionCommand(loggerMessages, exception) }}
                }
            };
            DefaultExceptionHandler exceptionHandler = new(commandTypeExceptionHandlers);
            var commandRunner = new CommandRunner(queue, exceptionHandler);

            commandRunner.Execute();

            Assert.IsTrue(queue.IsEmpty);
            Assert.IsTrue(loggerMessages.Any());
        }

        /// <summary>
        /// Добавление в очередь команды для записи в лог ошибки
        /// </summary>
        [TestMethod]
        public void AddWriteLogAfterExceptionCommandInQueue()
        {
            var commandTypeExceptionHandlers = new Dictionary<Type, IDictionary<Type, Func<Exception, ICommand>>>()
            {
                { typeof(RotatableAdapter),
                    new Dictionary<Type, Func<Exception, ICommand>>()
                    {{ typeof(InvalidInputValueException), (exception) => new LogExceptionCommand(loggerMessages, exception) }}
                }
            };
            AddCommandToQueueExceptionHandler exceptionHandler = new(commandTypeExceptionHandlers, queue);
            var commandRunner = new CommandRunner(queue, exceptionHandler);

            commandRunner.Execute();

            Assert.IsTrue(queue.IsEmpty);
            // Такая проверка чтобы убедиться, что команда для записи ошибки в лог вызвалась только 1 раз
            Assert.IsTrue(loggerMessages.Count == 1);
        }
    }
}
