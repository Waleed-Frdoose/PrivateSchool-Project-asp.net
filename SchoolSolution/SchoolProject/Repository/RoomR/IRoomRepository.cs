using SchoolProject.Models;

namespace SchoolProject.Repository.RoomR
{
    public interface IRoomRepository
    {
        public List<Room> GetRooms();

        public void Create(Room room);

        public void Edite(Room room);

        public void Delete(int roomId);

        public Room Find(int roomId);
    }
}
