using Microsoft.Data.SqlClient;
using Dapper;
using Dap.Model;

const string connectionString = "Data Source=DESKTOP-G18LE98;Initial Catalog=balta;Integrated Security=True;Encrypt=False;";

using(var connections = new SqlConnection(connectionString))
{
   ListCategories(connections);
   UpdateCategory(connections);

   //CreateCategory(connections);
    
}

static void ListCategories(SqlConnection sqlConnection)
{
   var categories = sqlConnection.Query<Category>("SELECT [Id],[Title] FROM [CATEGORY]");
     //System.Console.WriteLine($"{rows} linhas inseridas");

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