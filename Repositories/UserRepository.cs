using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<int, User> _users = new();
        private int _nextId = 1;

        public UserRepository()
        {
            var u1 = new User { Id = GetNextId(), Name = "Alice", Email = "alice@example.com", Age = 30 };
            var u2 = new User { Id = GetNextId(), Name = "Bob", Email = "bob@example.com", Age = 28 };
            _users.TryAdd(u1.Id, u1);
            _users.TryAdd(u2.Id, u2);
        }

        private int GetNextId() => System.Threading.Interlocked.Increment(ref _nextId) - 1;

        public IEnumerable<User> GetAll() => _users.Values.OrderBy(u => u.Id);

        public User? GetById(int id)
        {
            _users.TryGetValue(id, out var user);
            return user;
        }

        public User Create(User user)
        {
            var id = GetNextId();
            user.Id = id;
            _users.TryAdd(id, user);
            return user;
        }

        public bool Update(int id, User user)
        {
            if (!_users.ContainsKey(id)) return false;
            user.Id = id;
            _users[id] = user;
            return true;
        }

        public bool Delete(int id)
        {
            return _users.TryRemove(id, out _);
        }
    }
}
