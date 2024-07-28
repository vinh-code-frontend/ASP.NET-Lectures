using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;
        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId
        {
            get
            {
                return _serviceInstanceId;
            }
        }
        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "Ha Noi",
                "Bac Ninh",
                "Hung Yen"
            };
            // TODO: Add logic to open DB connection
        }
        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            // TODO: Add logic to close DB connection


        }
    }
}