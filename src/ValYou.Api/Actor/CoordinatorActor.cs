namespace ValYou.Api.Actor
{
    using System.Collections.Generic;

    using Akka.Actor;
    using ValYou.Api.Data;

    public class CoordinatorActor : ReceiveActor
    {
        private IShapeRepository ShapeRepository;

        private IList<Shape> Shapes;

        public CoordinatorActor(IShapeRepository shapeRepository)
        {
            ShapeRepository = shapeRepository;

            Receive<string>(
                x => x == "all",
                x =>
                {
                    Sender.Tell(this.Shapes);
                });
        }

        protected override void PreStart()
        {
            base.PreStart();

            this.Shapes = this.ShapeRepository.Get();
        }


    }
}