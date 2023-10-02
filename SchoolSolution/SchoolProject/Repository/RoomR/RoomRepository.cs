using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository.RoomR
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Room room)
        {
            if (room != null)
            {
                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int roomId)
        {
            var room = Find(roomId);
            if (room != null)
            {
                dbContext.Rooms.Remove(room);
                dbContext.SaveChanges();
            }
        }

        public void Edite(Room room)
        {
            dbContext.Rooms.Update(room);
            dbContext.SaveChanges();
        }

        public Room Find(int roomId)
        {
            // find Room base id
            if (roomId > 0)
            {
                return dbContext.Rooms.Where(x => x.RoomId == roomId).First();
            }
            return null!;
        }

        public List<Room> GetRooms()
        {
            return dbContext.Rooms.ToList();
        }
    }
}
