using Exercise2;
using Exercise2.Domain;
using Exercise2.IServices;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(cadConex => new string(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IServiceEmployee, ServiceEmployee>();
builder.Services.AddTransient<IRepositoryEmployees, RepositoryEmployees>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/employee/{id}", (int id, IServiceEmployee serviceEmployee) =>
{
	try
	{
		return Results.Ok(serviceEmployee.GetById(id));
	}
    catch (CommonException exCom)
    {
        return Results.BadRequest(new { exCom.Title,exCom.Detail });

    }
    catch (Exception ex)
	{
        return Results.BadRequest(ex.Message);

    }
	
});

app.MapGet("/employees", (IServiceEmployee serviceEmployee) =>
{
    try
    {
        return Results.Ok(serviceEmployee.GetList());
    }
    catch (CommonException exCom)
    {
        return Results.BadRequest(new { exCom.Title, exCom.Detail });

    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }


});

app.MapPost("/employees", ([FromBody] Employee employee, IServiceEmployee serviceEmployee) =>
{
    try
    {
        serviceEmployee.Create(employee);
        return Results.Ok();
    }
    catch (CommonException exCom)
    {
        return Results.BadRequest(new { exCom.Title, exCom.Detail });

    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);

    }

});

app.MapPut("/employees/{id}", (Employee employee,int id, IServiceEmployee serviceEmployee) =>
{
    try
    {
        serviceEmployee.Update(employee, id);
        return Results.Ok();
    }
    catch (CommonException exCom)
    {
        return Results.BadRequest(new { exCom.Title, exCom.Detail });

    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);

    }

});

app.MapDelete("/employees", (int id, IServiceEmployee serviceEmployee) =>
{
    try
    {
        serviceEmployee.Delete(id);
        return Results.Ok();
    }
    catch (CommonException exCom)
    {
        return Results.BadRequest(new { exCom.Title, exCom.Detail });

    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);

    }

});


app.Run();
