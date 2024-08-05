using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "Select top(3) MessageID,Name,Subject,Detail,SendDate,IsRead,UserImageUrl from Message Inner Join AppUser On Message.Sender=AppUser.UserID Where Receiver=@receiverID order by MessageID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverID", id);
            using var connection = _context.CreateConnection();
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
