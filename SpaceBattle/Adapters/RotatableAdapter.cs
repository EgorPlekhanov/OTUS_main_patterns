using SpaceBattle.Contracts;

namespace SpaceBattle.Adapters
{
    /// <summary>
    /// Адаптер для поворачивающихся объектов
    /// </summary>
    public class RotatableAdapter : IRotatable
    {
        private readonly IGameObject gameObject;

        public RotatableAdapter(IGameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public int Direction
        {
            get => (int)gameObject.GetProperty(nameof(Direction));
            set => gameObject.SetProperty(nameof(Direction), value % DirectionsCount);
        }

        public int DirectionsCountPerStep =>
            (int)gameObject.GetProperty(nameof(DirectionsCountPerStep));

        public int DirectionsCount =>
            (int)gameObject.GetProperty(nameof(DirectionsCount));

        public void Execute()
        {
            if (DirectionsCountPerStep < 1)
                throw new Exception("Кол-во поворотов за шаг не может быть меньше 1");
            if (DirectionsCount < 1)
                throw new Exception("Общее кол-во углов не может быть меньше 1");
            gameObject.SetProperty(nameof(Direction), (Direction + DirectionsCountPerStep) % DirectionsCount);
        }
    }
}
