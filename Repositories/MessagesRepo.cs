using BrochureAPI.Data;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Repositories
{
    public class MessagesRepo : IMessages
    {
        ApplicationDBContext _context;
        public MessagesRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Messages> DeleteMessage(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if(message == null)
            {
                return null;
            };
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<List<Messages>> GetAll(MessagesQuery query)
        {
            var messages = _context.Messages.AsQueryable();
            if (!string.IsNullOrEmpty(query.Email))
            {
                messages = messages.Where(s => s.Email.Contains(query.Email));
            }
            if (!string.IsNullOrEmpty(query.Email))
            {
                messages = messages.Where(s => s.Email.Contains(query.Email));
            }
            // Sorting
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Email", StringComparison.OrdinalIgnoreCase))
                {
                    messages = query.IsDescending ? messages.OrderByDescending(s => s.Email) : messages.OrderBy(s => s.Email);
                }
            }
            // Pagination
            var skipNumber = (query.PageNumber - 1) * query.Limit;

            return await messages.Skip(skipNumber).Take(query.Limit).ToListAsync();
        }

        public async Task<Messages?> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Messages> SendMessage(Messages messages)
        {
            await _context.Messages.AddAsync(messages);
            await _context.SaveChangesAsync();
            return messages;
        }
    }
}
