using Room_Reservation_System.Core.Entites;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private Lazy<IReservationRepository> _Reservation { get; set; }
        private Lazy<IResourcesRepository> _Resources { get; set; }
        private Lazy<IRoomRepository> _Room { get; set; }

        private BaseContext baseContext;
        public RepositoryManager(BaseContext baseContext)
        {
            _Reservation = new Lazy<IReservationRepository>(() => new ReservationRepository(baseContext.Set<Reservation>()));
            _Resources = new Lazy<IResourcesRepository>(() => new ResourceRepository(baseContext.Set<Resource>()));
            _Room = new Lazy<IRoomRepository>(() => new RoomRepository(baseContext.Set<Room>()));          
        }

        public void Save()
        {
            baseContext.SaveChanges();
        }

        public void ReserveRoom(int RoomId,DateTime StartDate,DateTime EndDate)
        {
       
        }
        public IReservationRepository Reservation => _Reservation.Value;
        public IResourcesRepository Resources => _Resources.Value;
        public IRoomRepository Room => _Room.Value;
    }
}
