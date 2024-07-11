using Models.Dto;
using Models.Entities;
namespace BLL.Mapping
{
    public class TransactionMapping : IMapping<TransactionsEntity, TransactionDto>
    {
        public override TransactionDto ToDto(TransactionsEntity entity)
        {
            return new TransactionDto()
            {
                DateTime = entity.DateTime,
                Amount = entity.Amount,
                Description = entity.Description,   
                OperationTypeID = entity.OperationTypeID,
            };
        }

        public override TransactionsEntity ToEntity(TransactionDto model)
        {
            return new TransactionsEntity()
            {
                Transaction_Id = Guid.NewGuid(),
                DateTime = model.DateTime,
                Amount = model.Amount,
                Description = model.Description,
                OperationTypeID = model.OperationTypeID,
            };
        }

        public override TransactionsEntity ToEntity(TransactionDto model, Guid id)
        {
            return new TransactionsEntity()
            {
                Transaction_Id = id,
                DateTime = model.DateTime,
                Amount = model.Amount,
                Description = model.Description,
                OperationTypeID = model.OperationTypeID,
            };
        }
    }
}
