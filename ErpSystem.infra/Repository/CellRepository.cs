using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ErpSystem.infra.Repository
{
    public class CellRepository : ICellRepository
    {
        private readonly IDbContext context;
        public CellRepository (IDbContext dbContext)
        {
            this.context = dbContext;
        }
        public Cell GetImg()
        {
            IEnumerable<Cell> result = context.connection.Query<Cell>("CellPkg.RetriveLastCellImg", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool Update(Cell cell)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IImg1", cell.img1 , dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImg2", cell.img2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImg3", cell.img3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImg4", cell.img4, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImg5", cell.img5, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImg6", cell.img6, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImg7", cell.img7, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.Execute("CellPkg.UpdateImage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
