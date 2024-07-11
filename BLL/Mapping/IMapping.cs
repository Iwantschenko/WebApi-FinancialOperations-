using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public abstract class IMapping<Entity,Dto>
        where Entity : class
        where Dto : class
    {
        public abstract Entity ToEntity(Dto model);
        public abstract Entity ToEntity(Dto model , Guid id);
        public abstract Dto ToDto(Entity entity);
        public List<Dto> ToListDto(List<Entity> list)
        {
            var modelList = new List<Dto>();
            foreach (var item in list)
            {
                modelList.Add(ToDto(item));
            }
            return modelList;
        }
        public List<Entity> ToListEntity(List<Dto> list)
        {
            List<Entity> entityList = new List<Entity>();
            foreach (var item in list)
            {
                entityList.Add(ToEntity(item));
            }
            return entityList;
        }

    }
}
