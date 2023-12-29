using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlayerAgentManagement.BL;
using PlayerAgentManagement.DAL.EF;
using PlayerAgentManagement.UI_CA;

  
var dbOptionBuilder = new DbContextOptionsBuilder<PlayerAgentDbContext>();
dbOptionBuilder.UseSqlite("Data Source=../../../../playeragent.db");
var ctx = new PlayerAgentDbContext(dbOptionBuilder.Options);
var repository = new Repository(ctx);
var isDatabaseCreated = ctx.CreateDatabase(true);
if (isDatabaseCreated)
{
    DataSeeder.Seed(ctx);
}
var loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
IManager manager = new Manager(repository);
var consoleUi = new ConsoleUi(manager);
consoleUi.Run();


