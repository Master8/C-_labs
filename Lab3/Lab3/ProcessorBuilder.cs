using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ProcessorBuilder
    {
        public static ProcessorEngine<TEngine> CreateEngine<TEngine>()
        {
            return new ProcessorEngine<TEngine>();
        }
    }

    class ProcessorEngine<TEngine>
    {
        public ProcessorEntity<TEngine, TEntity> For<TEntity>()
        {
            return new ProcessorEntity<TEngine, TEntity>();
        }
    }

    class ProcessorEntity<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
