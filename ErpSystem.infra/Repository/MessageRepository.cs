using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using ErpSystem.infra.Repository;

namespace ErpSystem.core.Repository
{
    public class MessageRepository:IMessageRepository
    {
        private readonly IDbContext dbContext;
        public MessageRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Delete(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Delete, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.ExecuteAsync("MessagesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<ChatMessageDTO>> GetAll()
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetAll, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<ChatMessageDTO>("MessagesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Message> GetById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetById, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", id, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Message>("MessagesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task<int> Insert(Message message)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Insert, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("ISender",message.Sender, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IReceiver", message.Receiver, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IText", message.Text, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            p.Add("ITime", message.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IStatus", message.Status, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IFilePath", message.Filepath, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return await dbContext.connection.ExecuteAsync("MessagesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> Update(Message message)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Update, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", message.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("ISender", message.Sender, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IReceiver", message.Receiver, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IText", message.Text, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            p.Add("ITime", message.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IStatus", message.Status, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IFilePath", message.Filepath, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return await dbContext.connection.ExecuteAsync("MessagesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<Message>> GetConversation(ConversationDTO conversationDTO)
        {
            var p = new DynamicParameters();
            p.Add("IFirstUser", conversationDTO.FirstUser, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("ISecondUser", conversationDTO.SecondUser, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Message>("MessagesPkg.GetConversation", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Message>> GetMessages(decimal employeeId)
        {
            var p = new DynamicParameters();
            p.Add("IEmployeeId", employeeId, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Message>("MessagesPkg.GetMessages", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
