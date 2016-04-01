using Generics.Interfaces;

namespace Generics.Processors
{
    public class Processor
    {
        public static EngineProcessor CreatEngine<TEngine>() where TEngine: IEngine, new()
        {
            return new EngineProcessor(new TEngine());
        }
    }
}
