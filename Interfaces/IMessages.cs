using BrochureAPI.Helpers;
using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IMessages
    {
        Task<List<Messages>> GetAll(MessagesQuery query);
        Task<Messages> SendMessage(Messages messages);
        Task<Messages?> DeleteMessage(int id);

        Task<Messages?> GetMessage(int id);
    }
}
