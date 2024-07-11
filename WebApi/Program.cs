
using BLL.Mapping;
using BLL.Service;
using DAL.DB;
using DAL.Infastructure;
using Microsoft.EntityFrameworkCore;
using Models.Dto;
using Models.Entities;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            // Add services to the container.
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataBaseContext>(
                options => options.UseSqlServer(configuration.GetConnectionString(nameof(DataBaseContext)))
                );
            
            builder.Services.AddScoped<IRepository<OperationTypeEntity>, BaseRepository<OperationTypeEntity>>();
            builder.Services.AddScoped<IRepository<TransactionsEntity> , BaseRepository<TransactionsEntity>>();
            builder.Services.AddScoped<ReportRepository>();

            builder.Services.AddScoped<IMapping<OperationTypeEntity, OperationTypeDto>, OperationMapping>();
            builder.Services.AddScoped<IMapping<TransactionsEntity, TransactionDto>, TransactionMapping>();

            builder.Services.AddScoped<BaseService<OperationTypeEntity , OperationTypeDto>>();
            builder.Services.AddScoped<BaseService<TransactionsEntity , TransactionDto>>();
            builder.Services.AddScoped<ReportService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
