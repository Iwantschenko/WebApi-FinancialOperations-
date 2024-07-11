using Models.Dto;
using Models.Entities;
namespace BLL.Mapping
{
    public class OperationMapping : IMapping<OperationTypeEntity, OperationTypeDto>
    {
        public override OperationTypeDto ToDto(OperationTypeEntity entity)
        {
            return  new OperationTypeDto()
            {
                IsIncome = entity.IsIncome,
                Name = entity.Name,
            };
        }

        public override OperationTypeEntity ToEntity(OperationTypeDto model)
        {
            return  new OperationTypeEntity()
            {
                ID = Guid.NewGuid(),
                Name = model.Name,
                IsIncome = model.IsIncome,
            };
            
        }

        public override OperationTypeEntity ToEntity(OperationTypeDto model, Guid id)
        {
            return new OperationTypeEntity()
            {
                ID = id,
                Name = model.Name,
                IsIncome = model.IsIncome,
            };
        }
    }
}
