using System.Collections.ObjectModel;
using System.Windows.Input;

namespace web_marketplase_TRiZBD.ViewModels
{ 
    public class StatisticViewModel : ViewModelBase
    {
        public ObservableCollection<WarehouseStatistics> _warehouseStatistics;

        public ObservableCollection<WarehouseStatistics> WarehouseStatistics
        {
            get => _warehouseStatistics;
            set => SetProperty(ref _warehouseStatistics, value);
        }

        public StatisticViewModel()
        {
            WarehouseStatistics = new ObservableCollection<WarehouseStatistics>();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            // Загрузка статистических данных (заглушка)
            WarehouseStatistics.Add(new WarehouseStatistics { WarehouseID = 1, Location = "Warehouse 1", TotalOrders = 150, EmployeeCount = 5 });
            WarehouseStatistics.Add(new WarehouseStatistics { WarehouseID = 2, Location = "Warehouse 2", TotalOrders = 90, EmployeeCount = 3 });
            // В реальном приложении здесь должны быть асинхронные запросы к базе данных
        }
    }

    // Дополнительный класс для хранения статистики склада
    public class WarehouseStatistics
    {
        public int WarehouseID { get; set; }
        public string Location { get; set; }
        public int TotalOrders { get; set; }
        public int EmployeeCount { get; set; }
    }
}