using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Prototype.ModelMapper
{
    public class AutoMapperModelMapper : IMapper
    {
        public TDest Map<TSrc, TDest>(TSrc source)
        {
            Mapper.CreateMap<TSrc, TDest>();
            return Mapper.Map<TSrc, TDest>(source);
        }

        public TDest Map<TSrc, TDest>(TSrc source, TDest destination)
        {
            Mapper.CreateMap<TSrc, TDest>();
            return Mapper.Map(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public void Map(object source, object destination, Type sourceType, Type destinationType)
        {
            Mapper.Map(source, destination, sourceType, destinationType);
        }

        public void Map<TSrc, TDest>(IList<TSrc> source, IList<TDest> destination)
        {
            Mapper.CreateMap<TSrc, TDest>();

            if (source == null)
            {
                destination = new List<TDest>();
            }
            else
            {
                foreach (TSrc sourceEntity in source)
                {
                    var mappedEntity = Mapper.Map<TSrc, TDest>(sourceEntity);
                    destination.Add(mappedEntity);
                }
            }
        }
    }

}
