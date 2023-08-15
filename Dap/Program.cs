﻿using Microsoft.Data.SqlClient;
using Dapper;
using Dap.Model;

const string connectionString = "Data Source=DESKTOP-G18LE98;Initial Catalog=balta;Integrated Security=True;Encrypt=False;";

using(var connections = new SqlConnection(connectionString))
{
   //ListCategories(connections);
   //UpdateCategory(connections);
   //CreateManyCategory(connections); 
   //CreateCategory(connections);
   //ExecuteProcedure(connections);
   ExecuteReadProcedure(connections);
    
}

static void ListCategories(SqlConnection sqlConnection)
{
   var categories = sqlConnection.Query<Category>("SELECT [Id],[Title] FROM [CATEGORY]");
    foreach(var item in categories)
    {
        System.Console.WriteLine($"{item.Id} {item.Title}");
    }
}

static void CreateCategory(SqlConnection sqlConnection)
{
    var insertSql = @"INSERT INTO 
  [CATEGORY]
   VALUES (
    @Id,
    @Title,
    @Url,
    @Summary,
    @Order,
    @Description,
    @Featured
    )" ;

Category category = new Category();
category.Id = Guid.NewGuid();   
category.Title = "AmazonAws";
category.Url = "Amazon";
category.Description = "Categoria destinada a servicos do aws";
category.Order = 8;
category.summary = "AWS Cloud";
category.Featured = false;

 var rows = sqlConnection.Execute(insertSql, new {
        category.Id,
        category.Title,
        category.Url,
        category.summary,
        category.Order,
        category.Description,
        category.Featured

    });
}

static void UpdateCategory(SqlConnection sqlConnection)
{
    var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id ";
    var rows = sqlConnection.Execute(updateQuery, new { 
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        title = "Front End 2023"
    });
    System.Console.WriteLine($"{rows} Registros atualizados");
       
}
static void DeleteCategory(SqlConnection sqlConnection)
{

}

static void CreateManyCategory(SqlConnection sqlConnection)
{
    var insertSql = @"INSERT INTO 
  [CATEGORY]
   VALUES (
    @Id,
    @Title,
    @Url,
    @Summary,
    @Order,
    @Description,
    @Featured
    )" ;

Category category = new Category();
category.Id = Guid.NewGuid();   
category.Title = "AmazonAws";
category.Url = "Amazon";
category.Description = "Categoria destinada a servicos do aws";
category.Order = 8;
category.summary = "AWS Cloud";
category.Featured = false;

Category categoryTwo = new Category();
categoryTwo.Id = Guid.NewGuid();   
categoryTwo.Title = "Azure Cloud";
categoryTwo.Url = "Azure";
categoryTwo.Description = "Categoria destinada a servicos do Azure";
categoryTwo.Order = 9;
categoryTwo.summary = "Azure Cloud";
category.Featured = false;
 var rows = sqlConnection.Execute(insertSql, new[] {
    new {
        category.Id,
        category.Title,
        category.Url,
        category.summary,
        category.Order,
        category.Description,
        category.Featured
    },
    new
     {
        categoryTwo.Id,
        categoryTwo.Title,
        categoryTwo.Url,
        categoryTwo.summary,
        categoryTwo.Order,
        categoryTwo.Description,
        categoryTwo.Featured

     }

    });
}

static void ExecuteProcedure(SqlConnection sqlConnection)
{
    string procedure = "[spDeleteStudent]";
    var parameters =  new{ StudentId = "88d6907b-7715-48e9-a3f3-580fea13914b"};
    var AffectedRows = sqlConnection.Execute(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
    System.Console.WriteLine($"{AffectedRows}  Linhas Afetadas");
}

static void ExecuteReadProcedure(SqlConnection sqlConnection)
{
    string procedure = "[spGetCoursesByCategory]";
    var parameters =  new{ CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142"};
    var courses = sqlConnection.Query(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
    System.Console.WriteLine($"{courses.Count()}  Linhas Afetadas");

    foreach (var item in courses)
    {
        System.Console.WriteLine($"{item.Title}");

    }
}