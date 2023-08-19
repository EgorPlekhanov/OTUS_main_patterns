using SpaceBattle.Contracts;
using System.Numerics;

namespace SpaceBattle.Adapters
{
    /// <summary>
    /// Адаптер для движущихся объектов
    /// </summary>
    public class MovableAdapter : IMovable
    {
        private readonly IGameObject gameObject;
        public MovableAdapter(IGameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public Vector<double> Position
        {
            get => (Vector<double>)gameObject.GetProperty(nameof(Position));
            set => gameObject.SetProperty(nameof(Position), value);
        }

        public Vector<double> Velocity
        {
            get
            {
                int currentDirection = (int)gameObject.GetProperty(nameof(IRotatable.Direction));
                int speed = (int)gameObject.GetProperty(Constants.VELOCITY);
                int directionsCount = (int)gameObject.GetProperty(nameof(IRotatable.DirectionsCount));
                return new(new[] {
                    speed * Math.Cos((double)currentDirection / 360 * directionsCount),
                    speed * Math.Sin((double)currentDirection / 360 * directionsCount)
                });
            }
        }

        public void Execute() =>
            gameObject.SetProperty(nameof(Position), Position + Velocity);
    }
}
