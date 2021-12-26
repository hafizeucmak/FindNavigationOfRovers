using System;
using System.Linq;

namespace NASANavigateRover
{
    public class Astronaut
    {
        public static Random Random = new Random();

        public Astronaut()
        {
            Position = new Position(0, 0);
            DirectionType = DirectionType.N;
            FullName = Faker.Name.FullName();
            Age = Random.Next(30, 40);
        }

        public string FullName { get; }

        public int Age { get; }

        public Position Position { get; set; }

        public DirectionType DirectionType { get; set; }

        public void Move(string commandString)
        {
            if (commandString.Equals("M"))
            {
                SetPosition();
            }
            else if (Enum.GetNames(typeof(MovementType)).ToList().Contains(commandString))
            {
                var movementType = commandString.Equals(MovementType.R.ToString()) ? MovementType.R : MovementType.L;
                SetDirection(movementType);
            }
        }

        private void SetPosition()
        {
            switch (this.DirectionType)
            {
                case DirectionType.N:
                    Position.YAxis = Position.YAxis + 1;
                    break;
                case DirectionType.E:
                    Position.XAxis = Position.XAxis + 1;
                    break;
                case DirectionType.S:
                    Position.YAxis = Position.YAxis - 1;
                    break;
                case DirectionType.W:
                    Position.XAxis = Position.XAxis - 1;
                    break;
            }
        }

        public void SetInitialPositionAndDirection(string initialInformation)
        {
            if (initialInformation.Length != 3)
            {
                Console.WriteLine("Astroaut initial direction not in correct format");
            }

            this.Position.XAxis = Convert.ToInt32(initialInformation.Substring(0, 1));
            this.Position.YAxis = Convert.ToInt32(initialInformation.Substring(1, 1));
            this.DirectionType = Enum.Parse<DirectionType>(initialInformation.Substring(2, 1), true);
        }

        private void SetDirection(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.R:
                    DirectionType = this.DirectionType.Equals(DirectionType.N) ? DirectionType.E
                                  : this.DirectionType.Equals(DirectionType.E) ? DirectionType.S
                                  : this.DirectionType.Equals(DirectionType.S) ? DirectionType.W
                                  : this.DirectionType.Equals(DirectionType.W) ? DirectionType.N
                                  : DirectionType.N;
                    break;
                case MovementType.L:
                    DirectionType = this.DirectionType.Equals(DirectionType.N) ? DirectionType.W
                                    : this.DirectionType.Equals(DirectionType.E) ? DirectionType.N
                                    : this.DirectionType.Equals(DirectionType.S) ? DirectionType.E
                                    : this.DirectionType.Equals(DirectionType.W) ? DirectionType.S
                                    : DirectionType.N;
                    break;
            }
        }
    }
}
