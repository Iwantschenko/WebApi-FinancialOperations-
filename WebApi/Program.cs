
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
            
            #region DI 
            builder.Services.AddControllers();
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("BlazorClient" , builder =>
                {
                    builder.WithOrigins("https://localhost:7063")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            #endregion

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("BlazorClient");

            app.MapControllers();

            app.Run();
        }
    }
}
