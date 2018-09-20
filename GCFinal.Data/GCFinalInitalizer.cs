using GCFinal.Domain.Models.Items;
using System.Data.Entity;
using GCFinal.Data.Migrations;

namespace GCFinal.Data
{
    class GCFinalInitalizer : MigrateDatabaseToLatestVersion<GCFinalContext, Configuration>
    {
        
    }
}